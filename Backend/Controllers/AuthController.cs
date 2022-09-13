using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;

namespace Gaby.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthRepository repository;
        private readonly IHelpers helper;
        private readonly UsuarioSettings settings;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly Messages messages;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IConfiguration Configuration;
        private readonly IEquipoRepository equipoRepository;
        // private readonly DbSeeder dbSeeder;

        public AuthController(IAuthRepository _repository,
            UserManager<ApplicationUser> _userManager,
            IOptions<UsuarioSettings> _settings,
            IHelpers _helper,
            RoleManager<ApplicationRole> _roleManager,
            IUnitOfWork _unitOfWork,
            IMapper _mapper,
            IOptions<Messages> _messages,
            IConfiguration configuration,
            IEquipoRepository _equipoRepository)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            repository = _repository;
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            messages = _messages.Value;
            Configuration = configuration;
            helper = _helper;
            settings = _settings.Value;
            equipoRepository = _equipoRepository;
            // dbSeeder = _dbSeeder;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserViewModel model)
        {
            var Now = helper.GetCurrentDateTime();

            // dbSeeder.SeedAsync().Wait();
            ApplicationUser user = await repository.FindUserByEmailAsync(model.Email);

            if (user == null)
                return NotFound(Configuration["Messages:ErrorUsuarioPasswordInvalido"]);

            if (await userManager.IsLockedOutAsync(user))
                return NotFound(Configuration["Messages:ErrorCuentaBloqueda"]);

            if (!await userManager.CheckPasswordAsync(user, model.Password))
            {
                await userManager.AccessFailedAsync(user);

                if (user.LockoutEnd.HasValue)
                    await userManager.SetLockoutEnabledAsync(user, user.LockoutEnd > Now);

                return NotFound(Configuration["Messages:ErrorUsuarioPasswordInvalido"]);
            }

            if (user.Usuario == null)
                return NotFound(Configuration["Messages:ErrorIdUsuario"]);

            user.AccessFailedCount = 0;
            user.LockoutEnabled = false;
            user.LockoutEnd = null;
            user.LastLoginTime = Now;

            if (!user.FirstLogin)
                user.FirstLoginDate = helper.GetCurrentDateTime();

            await userManager.UpdateAsync(user);

            bool ExpiredPassword = false;

            if (user.LastPasswordChangedDate.HasValue)
            {
                var Caducidad = settings.DiasCaducidadPassword;
                var PasswordChangeDate = user.LastPasswordChangedDate.Value.AddDays(Caducidad);

                ExpiredPassword = PasswordChangeDate < Now;
            }

            string id = user.Id.ToString();

            var claims = new List<Claim> {
                new Claim("Id", id),
                new Claim("UserName", user.UserName),
                new Claim("Nombre", user.Usuario.Nombre),
                new Claim("Apellido", user.Usuario.Apellido),
                new Claim("ExpiredPassword", ExpiredPassword.ToString(), ClaimValueTypes.Boolean),
                //new Claim("Rol", "")
            };

            List<String> roles = await repository.GetRolesAsync(user);

            foreach (var Rol in roles)
            {
                claims.Add(new Claim("Rol", Rol));
            }

            int time = Convert.ToInt32(Configuration["Jwt:Time"]);

            var token = JwtProvider.GenerateToken(claims, Configuration["Jwt:Key"], Configuration["Jwt:Issuer"],
                time, Configuration["Jwt:Audience"]);

            return Ok(new { Token = token });

        }

        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = Roles.ADM)]
        [HttpPost("Register")]
        public async Task<object> Registro([FromBody] SaveUserViewModel model)
        {

            ApplicationUser user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
                return BadRequest(Configuration["Messages:ErrorUsuarioExistente"]);

            DT usuario = mapper.Map<SaveUserViewModel, DT>(model);

            ApplicationUser newUser = mapper.Map<SaveUserViewModel, ApplicationUser>(model);

            List<ApplicationRole> roles = await repository.SetApplicationUser(newUser, model.Email, "USER");

            newUser.Usuario = repository.SetUsuariosRolesByIdentitiesRoles(roles, usuario);
            newUser.Usuario = repository.SetDefaultDataDT(newUser.Usuario, usuario.IdEquipo);
            newUser.Usuario.Equipo = await equipoRepository.FindEquipoByIdAsync(usuario.IdEquipo);

            string newPassword = model.Password;
            var identityResult = await repository.CreateUserAsync(newUser, newPassword);

            if (!identityResult.Succeeded)
                return NotFound(Configuration["Messages:ErrorRegister"]);

            await userManager.SetLockoutEnabledAsync(newUser, usuario.Enabled);

            await repository.AddRoleAsync(newUser, roles[0]);

            equipoRepository.SetUser(newUser.Usuario.Equipo, usuario.Id);

            return Ok(mapper.Map<DT, SaveUserViewModel>(usuario));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = Roles.USUARIO)]
        [HttpPost("MUsuario")]
        public async Task<IActionResult> MUsuario(string email, [FromBody] SaveUserViewModel model)
        {
            ApplicationUser userDB = await userManager.FindByEmailAsync(email);

            if (userDB == null)
                return NotFound(Configuration["Messages:ErrorIdUsuario"]);

            DT usuario = mapper.Map<SaveUserViewModel, DT>(model);

            DT usuarioDB = await repository.FindManagerByEmailAsync(email);

            if (usuarioDB == null)
                return NotFound(Configuration["Messages:ErrorIdUsuario"]);

            ApplicationUser user = mapper.Map<SaveUserViewModel, ApplicationUser>(model);

            repository.MUsuario(usuario, usuarioDB);

            userDB = repository.MUser(userDB, user, settings.Time).Result;

            await userManager.UpdateAsync(userDB);

            DT usuarioFront = await repository.FindManagerByEmailAsync(userDB.Email);

            return Ok(mapper.Map<DT, SaveUserViewModel>(usuarioFront));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
                return NotFound(Configuration["Messages:ErrorUsuarioExistente"]);

            bool passwordIsValid = await userManager.CheckPasswordAsync(user, model.CurrentPassword);

            if (!passwordIsValid)
                return NotFound(Configuration["Messages:ErrorPasswordActual"]);

            if (model.NewPassword == model.CurrentPassword)
                return NotFound(Configuration["Messages:ErrorPasswordActualNueva"]);

            var identityResult = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (!identityResult.Succeeded)
                return NotFound(Configuration["Messages:ErrorCambioPassword"]);

            user.LastPasswordChangedDate = helper.GetCurrentDateTime();
            await userManager.UpdateAsync(user);

            return Ok(mapper.Map<ApplicationUser, UserViewModel>(user));
        }

    }
}

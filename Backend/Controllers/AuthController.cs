// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using AutoMapper;
// using Microsoft.Extensions.Options;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Identity;
// using System.Security.Claims;
// using System.Text;

// namespace Gaby.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class AuthController : ControllerBase
//     {

//         private readonly IContactRepository repository;
//         private readonly IUnitOfWork unitOfWork;
//         private readonly IMapper mapper;
//         private readonly Messages messages;
//         private readonly UserManager<User> userManager;
//         private readonly RoleManager<IdentityRole> roleManager;
//         private readonly IConfiguration Configuration;


//         public AuthController(IContactRepository _repository,
//             UserManager<User> _userManager,
//             RoleManager<IdentityRole> _roleManager,
//             IUnitOfWork _unitOfWork,
//             IMapper _mapper,
//             IOptions<Messages> _messages,
//             IConfiguration configuration)
//         {
//             userManager = _userManager;
//             roleManager = _roleManager;
//             repository = _repository;
//             unitOfWork = _unitOfWork;
//             mapper = _mapper;
//             messages = _messages.Value;
//             Configuration = configuration;
//         }

//         [HttpPost("Login")]
//         public async Task<IActionResult> Login([FromBody] UserViewModel model)
//         {
//             var Now = DateTime.UtcNow;

//             //dbSeeder.SeedAsync().Wait();
//             User user = await repository.FindByNameAsync(model.UserName);

//             if (user == null)
//                 return NotFound(Configuration["Messages:ErrorUsuarioPasswordInvalido"]);

//             if (await userManager.IsLockedOutAsync(user))
//                 return NotFound(Configuration["Messages:ErrorCuentaBloqueda"]);

//             if (!await userManager.CheckPasswordAsync(user, model.Password))
//             {
//                 await userManager.AccessFailedAsync(user);

//                 if (user.LockoutEnd.HasValue)
//                     await userManager.SetLockoutEnabledAsync(user, user.LockoutEnd > Now);

//                 return NotFound(Configuration["Messages:ErrorUsuarioPasswordInvalido"]);
//             }

//             if (user.Usuario == null)
//                 return NotFound(Configuration["Messages:ErrorIdUsuario"]);

//             user.AccessFailedCount = 0;
//             user.LockoutEnabled = false;
//             user.LockoutEnd = null;
//             user.LastLoginTime = Now;

//             if (!user.FirstLogin)
//                 user.FirstLoginDate = Helpers.GetCurrentDateTime();

//             await userManager.UpdateAsync(user);

//             bool ExpiredPassword = false;

//             if (user.LastPasswordChangedDate.HasValue)
//             {
//                 var Caducidad = settings.DiasCaducidadPassword;
//                 var PasswordChangeDate = user.LastPasswordChangedDate.Value.AddDays(Caducidad);

//                 ExpiredPassword = PasswordChangeDate < Now;
//             }

//             var claims = new List<Claim> {
//                 new Claim("Id", user.Id),
//                 new Claim("UserName", user.UserName),
//                 new Claim("Nombre", user.Usuario.Nombre),
//                 new Claim("Apellido", user.Usuario.Apellido),
//                 new Claim("ExpiredPassword", ExpiredPassword.ToString(), ClaimValueTypes.Boolean),
//                 //new Claim("Rol", "")
//             };

//             List<String> roles = await repository.GetRolesAsync(user);

//             foreach (var Rol in roles)
//             {
//                 claims.Add(new Claim("Rol", Rol));

//             }

//             var token = JwtProvider.GenerateToken(claims, settings.PrivateKey, settings.Issuer,
//                 settings.Time, settings.Audience);

//             return Ok(new { Token = token });

//         }

//         [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = Roles.ADM)]
//         [HttpPost("Register")]
//         public async Task<object> Registro([FromBody] SaveUserViewModel model)
//         {

//             User user = await userManager.FindByNameAsync(model.UserName);
//             DT usuario = mapper.Map<SaveUserViewModel, Usuario>(model);
//             User newUser = new User();
//             string newPassword = "";

//             if (user != null)
//             {
//                 if (repository.GetUsuarioByUsuario(usuario) != null)
//                 {
//                     return BadRequest(Configuration["Messages:ErrorUsuarioExistente"]);
//                 }

//                 usuario.FechaCreacion = Helpers.GetCurrentDateTime();
//                 newPassword = repository.GenerateRandomPassword();
//                 newUser = await userManager.FindByNameAsync(model.UserName);
//             }
//             else
//             {

//                 newUser = mapper.Map<SaveUserViewModel, User>(model);
//                 usuario.FechaCreacion = Helpers.GetCurrentDateTime();
//                 newUser.Usuario = repository.SetUsuariosRolesByIdentitiesRoles(model.Perfil, usuario);

//                 newPassword = repository.GenerateRandomPassword();
//                 var identityResult = await repository.CreateUserAsync(newUser, newPassword);

//                 if (!identityResult.Succeeded)
//                     return NotFound(Configuration["Messages:ErrorRegister"]);

//                 await userManager.SetLockoutEnabledAsync(newUser, model.Bloqueado);

//             }

//             await repository.AddRolesAsync(newUser, model.Perfil);

//             var usuarioFront = repository.GetUsuarioByUsuario(usuario);

//             return Ok(mapper.Map<DT, SaveUserViewModel>(usuarioFront));
//         }

//         [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = Roles.ADM)]
//         [HttpPost("MUsuario")]
//         public async Task<IActionResult> MUsuario(string userName, [FromBody] SaveUserViewModel model)
//         {
//             User userDB = await userManager.FindByNameAsync(userName);

//             if (userDB == null)
//                 return NotFound(Configuration["Messages:ErrorIdUsuario"]);

//             DT usuario = mapper.Map<SaveUserViewModel, DT>(model);
//             usuario.id = userName;
//             usuario = repository.SetUsuariosRolesByIdentitiesRoles(model.Perfil, usuario);
//             DT usuarioDB = repository.GetUsuarioByUserName(usuario.id);

//             if (usuarioDB == null)
//                 return NotFound(Configuration["Messages:ErrorIdUsuario"]);

//             User user = mapper.Map<SaveUserViewModel, User>(model);

//             await repository.AddRoles(usuario, usuarioDB);
//             repository.MUsuario(usuarioDB.Codigo, usuario, usuarioDB);
//             await repository.RemoveRoles(usuario, usuarioDB);

//             userDB = repository.MUser(userDB, user, settings.Time).Result;

//             await userManager.UpdateAsync(userDB);

//             DT usuarioFront = repository.GetUsuarioByUserName(usuario.id);

//             return Ok(mapper.Map<DT, SaveUserViewModel>(usuarioFront));
//         }

//         [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
//         [HttpPost("ChangePassword")]
//         public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
//         {
//             var user = await userManager.FindByIdAsync(model.Id);

//             if (user == null)
//                 return NotFound(Configuration["Messages:ErrorUsuarioExistente"]);

//             bool passwordIsValid = await userManager.CheckPasswordAsync(user, model.CurrentPassword);

//             if (!passwordIsValid)
//                 return NotFound(Configuration["Messages:ErrorPasswordActual"]);

//             if (model.NewPassword == model.CurrentPassword)
//                 return NotFound(Configuration["Messages:ErrorPasswordActualNueva"]);

//             var identityResult = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

//             if (!identityResult.Succeeded)
//                 return NotFound(Configuration["Messages:ErrorCambioPassword"]);

//             user.LastPasswordChangedDate = Helpers.GetCurrentDateTime();
//             await userManager.UpdateAsync(user);

//             return Ok(mapper.Map<User, UserViewModel>(user));
//         }

//     }
// }

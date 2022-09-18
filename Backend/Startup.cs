using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;


public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

    public void ConfigureServices(IServiceCollection services)
    {

        services.AddDbContext<ApplicationDbContext>(
        //     options =>
        // {
        //     var connection = Configuration.GetConnectionString("dBConnection");

        //     options.UseSqlServer(connection);
        // }
        );

        services.AddIdentity<ApplicationUser, ApplicationRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireDigit = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
                config.SignIn.RequireConfirmedEmail = true;
                config.Lockout.MaxFailedAccessAttempts = 5;
                // config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(Convert.ToDouble(sesionCaducada));
            })
                    // .AddRoles<ApplicationRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

        services
       // .AddTransient<IContactRepository, ContactRepository>()
       .AddTransient<IUnitOfWork, UnitOfWork>()
       .AddTransient<IAuthRepository, AuthRepository>()
       .AddTransient<IEquipoRepository, EquipoRepository>()
       .AddTransient<ISoFifaRepository, SoFifaRepository>()
       // .AddTransient<DbSeeder>()
       .AddTransient<IHelpers, Helpers>();

        services
        .Configure<Settings>(Configuration.GetSection("Settings"))
        .Configure<Messages>(Configuration.GetSection("Messages"))
        .Configure<UsuarioSettings>(Configuration.GetSection("Usuario"));

        services
            .AddHttpContextAccessor()
            // .AddAuthorization()
            .AddAuthorization(options =>
                {
                    var claiName = "Rol";

                    options.AddPolicy(Roles.ADM, policy =>
                        policy.RequireClaim(claiName, Roles.ADM));

                    options.AddPolicy(Roles.USER, policy =>
                        policy.RequireClaim(claiName, Roles.USER));

                })
            // .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

        services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                        {
                            builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                        });
            });

        var mappingConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new DomainToViewModelMappingProfile());
        mc.AddProfile(new ViewModelToDomainMappingProfile());
    });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });


        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddControllers();

        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // app.UseHttpsRedirection();
        app.UseMiddleware<ExceptionMiddleware>();

        app.UseRouting();
        app.UseCors(MyAllowSpecificOrigins);

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

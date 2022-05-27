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

        services
        .AddTransient<IContactRepository, ContactRepository>()
        .AddTransient<IUnitOfWork, UnitOfWork>()
        .AddTransient<IHelpers, Helpers>();

        services.AddIdentity<User, IdentityRole>(config =>
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
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

        services
        .Configure<Settings>(Configuration.GetSection("Settings"))
        .Configure<Messages>(Configuration.GetSection("Messages"));

        services
            .AddHttpContextAccessor()
            .AddAuthorization()
            // .AddAuthorization(options => 
            //     {
            //         var claiName = "Rol";

            //         options.AddPolicy(Roles.ADM, policy =>
            //             policy.RequireClaim(claiName, Roles.ADM));

            //         options.AddPolicy(Roles.CONSULTA, policy =>
            //             policy.RequireClaim(claiName, Roles.CONSULTA));

            //         options.AddPolicy(Roles.ADMVENTASDISTRIBUIDORVENDEDOR, policy =>
            //             policy.RequireAssertion(context => { return 
            //                 context.User.HasClaim(claiName, Roles.ADMVENTAS) || 
            //                 context.User.HasClaim(claiName, Roles.DISTRIBUIDOR) || 
            //                 context.User.HasClaim(claiName, Roles.VENDEDOR) ;
            //             }
            //         ));

            //         options.AddPolicy(Roles.ADMyADMVENTAS, policy =>
            //             policy.RequireAssertion(context => { return 
            //                 context.User.HasClaim(claiName, Roles.ADMVENTAS) || 
            //                 context.User.HasClaim(claiName, Roles.ADM) ;
            //             }
            //         ));

            //     })
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            // .AddAuthentication(options =>
            // {
            //     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            // })
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

        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // app.UseHttpsRedirection();

        app.UseRouting();
        app.UseCors(MyAllowSpecificOrigins);

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

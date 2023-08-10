using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ResiPay.API.Infrastructure;
using ResiPay.DB;
using ResiPay.Model.Apartment;
using ResiPay.Model.Bill;
using ResiPay.Model.User;
using ResiPay.Service.Apartment;
using ResiPay.Service.Bill;
using ResiPay.Service.User;
using ResiPay.Service.Validations.Apartment;
using ResiPay.Service.Validations.Bill;
using ResiPay.Service.Validations.User;
using ResiPay.Service.Mail;
using ResiPay.Service.Message;
using ResiPay.Model.Message;
using ResiPay.Service.Validations.Message;
using ResiPay.DB.DbClientService;
using ResiPay.DB.DbConfigurations.CardConfig;
using ResiPay.Service.CardService;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ResiPay.Service.Token;

namespace ResiPay
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {


            services.AddControllers();

            services.AddControllers().AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<UserInsertValidator>());

            services.AddDbContext<ResiPayDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlConnection"));

            });


            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());

            });


            var jwtSettings = Configuration.GetSection("JwtSettings");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidAudience = jwtSettings["Audience"],
                            ValidIssuer = jwtSettings["Issuer"],
                            ValidateAudience = true,
                            ValidateIssuer = true,
                            ValidateLifetime = true,
                            IssuerSigningKey = secret
                        };
                    });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ResiPay Resident Payment System", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "ResiPay Payment Management System",
                    Description = "Enter JWT Bearer token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme

                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}

                });
            });



            services.AddSingleton(config.CreateMapper());

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMailJobService, MailJobService>();
            services.AddScoped<ICardService, CardService>(); 
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IDbClient, DbClient>();
            services.Configure<CardConfig>(Configuration);

            services.AddScoped<IValidator<UserInsertModel>, UserInsertValidator>();
            services.AddScoped<IValidator<ApartmentInsertModel>, ApartmentInsertValidator>();
            services.AddScoped<IValidator<BillInsertModel>, BillInsertValidator>();
            services.AddScoped<IValidator<MessageInsertModel>, MessageInsertValidator>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ResiPay v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

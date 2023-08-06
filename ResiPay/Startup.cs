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
using ResiPay.Service.Token;
using ResiPay.Service.Mail;
using ResiPay.Service.Message;
using ResiPay.Model.Message;
using ResiPay.Service.Validations.Message;
using ResiPay.DB.DbClientService;
using ResiPay.DB.DbConfigurations.CardConfig;
using ResiPay.Service.CardService;

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


            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<ITokenService, TokenService>();

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

            services.AddSingleton(config.CreateMapper());

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IMailJobService, MailJobService>();
            services.AddScoped<ICardService, CardService>(); 
            services.AddScoped<IDbClient, DbClient>();
            services.Configure<CardConfig>(Configuration);

            services.AddScoped<IValidator<UserInsertModel>, UserInsertValidator>();
            services.AddScoped<IValidator<ApartmentInsertModel>, ApartmentInsertValidator>();
            services.AddScoped<IValidator<BillInsertModel>, BillInsertValidator>();
            services.AddScoped<IValidator<MessageInsertModel>, MessageInsertValidator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ResiPay", Version = "v1" });
            });
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


            app.UseAuthorization();
            
            app.UseMiddleware<JwtMiddleware>();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

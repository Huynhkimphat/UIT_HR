using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;
using HR_UIT.Data;
using HR_UIT.Data.Models;
using HR_UIT.Services.Employee;
using HR_UIT.Services.EmployeeAccount;
using HR_UIT.Services.EmployeeAddress;
using HR_UIT.Services.EmployeeDayOff_Letter;
using HR_UIT.Services.EmployeeDayOffService;
using HR_UIT.Services.EmployeeType;
using HR_UIT.Services.Holiday;
using HR_UIT.Services.HolidayCreate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Microsoft.IdentityModel.Tokens;

namespace HR_UIT.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = "https://hr-uit.com",
                ValidAudience = "https://hr-uit.com",
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ")),
                ClockSkew = TimeSpan.Zero
            };

            services
                .AddAuthentication(options => { options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(cfg => { cfg.TokenValidationParameters = TokenValidationParameters; });

            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("Admin", policy => policy.RequireClaim("type", "Admin"));
                cfg.AddPolicy("Staff", policy => policy.RequireClaim("type", "Staff"));
            });
            
            services.AddCors();
            
            services.AddControllers().AddNewtonsoftJson(opts =>
            {
                opts.SerializerSettings.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };
            });

            services
                .AddDbContext<HrUitDbContext>(opts =>
                {
                    opts.EnableDetailedErrors();
                    opts
                        .UseNpgsql(Configuration
                            .GetConnectionString("hr.uit.dev"));
                });

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeAddressService, EmployeeAddressService>();
            services.AddTransient<IEmployeeTypeService, EmployeeTypeService>();
            services.AddTransient<IEmployeeAccountService, EmployeeAccountService>();
            services.AddTransient<IEmployeeDayOffService, EmployeeDayOffService>();
            services.AddTransient<IEmployeeDayOffLetterService, EmployeeDayOffLetterService>();
            services.AddTransient<IHolidayService, HolidayService>();
            services.AddTransient<IHolidayCreateService, HolidayCreateService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "HR_UIT.Web", Version = "v1"});

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        new string[] { }
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HR_UIT.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();
            
            app.UseCors(builder =>
                builder
                    .WithOrigins("http://localhost:8080", "http://localhost:8081", "http://localhost:8082")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            );

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
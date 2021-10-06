using ConnectionTool;
using DAL.Repositories;
using DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Repositories;
using BLL.Interfaces;
using AunDevAPI.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AunDevAPI
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

            services.AddControllers();

            services.AddSingleton(sp => new Connection(Configuration.GetConnectionString("default")));
            
            services.AddScoped<IClientDALRepo, ClientDALRepo>();
            services.AddScoped<IClientBLLRepo, ClientBLLRepo>();

            services.AddScoped<ISkillDALRepo, SkillDALRepo>();
            services.AddScoped<ISkillBLLRepo, SkillBLLRepo>();

            services.AddScoped<IDevDALRepo, DevDALRepo>();
            services.AddScoped<IDevBLLRepo, DevBLLRepo>();

            services.AddScoped<IContractDALRepo,ContractDALRepo>();
            services.AddScoped<IContractBLLRepo,ContractBLLRepo>();

            services.AddSingleton<TokenManager>();


            services.AddSwaggerGen(c =>
            {
                OpenApiSecurityScheme openApiSecurityScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                };
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AunDevAPI", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n                       Enter 'Bearer' [space] and then your token in the text input below.                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            });

            services.AddAuthorization(option =>
            {
                option.AddPolicy("DevRequired", policy => policy.RequireAuthenticatedUser().RequireRole("DevBLL"));
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenManager.secret)),
                        ValidateIssuer = true,
                        ValidIssuer = TokenManager.myIssuer,
                        ValidateAudience = true,
                        ValidAudience = TokenManager.myAudience
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AunDevAPI v1"));
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

using AutoWrapper;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.API.Data;
using CorporateWebSite.API.Services;
using CorporateWebSite.Shared.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using TanvirArjel.EFCore.GenericRepository;

namespace CorporateWebSite.API
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
            var authSettings = Configuration.GetSection("AuthSettings").Get<AuthSettings>();
            services.AddAuthLayer(authSettings,
                x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                y => y.MigrationsAssembly("CorporateWebSite.API")));

            services.AddDbContext<DataContext>(
                x => x.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddCors();
            services.AddGenericRepository<DataContext>();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CorporateWebSite.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
           "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            #region Dependencies

            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ISliderService, SliderService>();
            services.AddTransient<IPartnerService, PartnerService>();
            services.AddTransient<IEmployeesService, EmployeesService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ICustomInfoService, CustomInfoService>();
            services.AddTransient<IAboutUsService, AboutUsService>();
            services.AddTransient<IImageUploadService, ImageUploadService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IServiceSettingService, ServiceSettingService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IMeetService, MeetService>();
            services.AddTransient<IHomePageService, HomePageService>();

            #endregion
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "CorporateWebSite.API v1"));
            }

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseHttpsRedirection();


            app.UseApiResponseAndExceptionWrapper();
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

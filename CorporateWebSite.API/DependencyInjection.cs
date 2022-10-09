using CorporateWebSite.API.Contracts;
using CorporateWebSite.API.Data;
using CorporateWebSite.API.Services;
using CorporateWebSite.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebSite.API
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Bu modül için 
        /// app.UseAuthentication();
        /// app.UseApiResponseAndExceptionWrapper();
        /// aktif etmeniz gerekiyor.
        /// </summary>
        /// <param name="authSettings">Auth ayarlarını yollamak gerekiyor </param>
        public static void AddAuthLayer(
            this IServiceCollection services,
            AuthSettings authSettings,
            Action<DbContextOptionsBuilder> authDbOptionsBuilder)
        {
            services.AddDbContext<DataContext>(authDbOptionsBuilder);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(
                                authSettings.SigningKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            services.AddTransient<IAuthService, AuthService>();

        }
    }
}

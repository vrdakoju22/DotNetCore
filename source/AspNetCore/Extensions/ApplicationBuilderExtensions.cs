using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCore.AspNetCore
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCorsAllowAny(this IApplicationBuilder application)
        {
            application.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        }

        public static void UseExceptionMiddleware(this IApplicationBuilder application, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                application.UseDatabaseErrorPage();
                application.UseDeveloperExceptionPage();
            }

            application.UseMiddleware<ExceptionMiddleware>();
        }

        public static void UseHttps(this IApplicationBuilder application)
        {
            application.UseHsts();
            application.UseHttpsRedirection();
        }

        public static void UseSpaAngularServer(this IApplicationBuilder application, IHostingEnvironment environment, string sourcePath, string npmScript)
        {
            application.UseSpaStaticFiles();

            application.UseSpa(configuration =>
            {
                configuration.Options.SourcePath = sourcePath;

                if (environment.IsDevelopment())
                {
                    configuration.UseAngularCliServer(npmScript);
                }
            });
        }

        public static void UseSpaProxyServer(this IApplicationBuilder application, IHostingEnvironment environment, string sourcePath, string baseUri)
        {
            application.UseSpaStaticFiles();

            application.UseSpa(configuration =>
            {
                configuration.Options.SourcePath = sourcePath;

                if (environment.IsDevelopment())
                {
                    configuration.UseProxyToSpaDevelopmentServer(baseUri);
                }
            });
        }

        public static void UseSwaggerDefault(this IApplicationBuilder application)
        {
            application.UseSwagger();
            application.UseSwaggerUI(cfg => cfg.SwaggerEndpoint("/swagger/api/swagger.json", string.Empty));
        }
    }
}

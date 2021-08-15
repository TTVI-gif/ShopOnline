using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopOnline.ApiIntegration;
using ShopOnline.ViewModels.System.Users;
using System;

namespace ShopOnline.AdminApp
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
            services.AddHttpClient();
            services.AddMvc().AddFluentValidation()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());
            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<IRoleApiClient, RoleApiClient>();
            services.AddTransient<ILanguageApiClient, LanguageApiClient>();
            services.AddTransient<IProductApiClient, ProductApiClient>();
            services.AddTransient<ICategoryApiClient, CategoryApiClient>();
            services.AddTransient<IValidator<RegisterRequest>, RegisterRequestValidator>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Login/Index";
                    option.AccessDeniedPath = "/Home/Forbidden";
                });

           /* services.ConfigureApplicationCookie(options => {
                // options.Cookie.HttpOnly = true;
                // options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/Login/Index";
                // options.LogoutPath = $"/logout/";
                options.AccessDeniedPath = "/User/Forbidden";
            });*/

            services.AddSession(options =>
            {
                options.Cookie.Name = "shopOnline.BootShop";
                options.IdleTimeout = TimeSpan.FromMinutes(2);
                
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            /*         IMvcBuilder builder = services.AddRazorPages();
                     var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
         #if DEBUG
                     if (environment == Environments.Development)
                     {
                         builder.AddRazorRuntimeCompilation();
                     }
         #endif*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
               app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

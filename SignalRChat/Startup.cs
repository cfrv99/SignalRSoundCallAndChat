using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalRChat.Hubs;
using SignalRChat.Middlewares;

namespace SignalRChat
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
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddSignalR();
            services.AddControllersWithViews();
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
            app.UseSession();
            //app.UseMiddleware<FileAuthMiddleware>();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    if (ctx.Context.Request.Path.StartsWithSegments("/chat.html"))
                    {
                        ctx.Context.Response.Headers.Add("Cache-Control", "no-store");
                        var sessionData = ctx.Context.Session.GetString("UserName");
                        if (string.IsNullOrWhiteSpace(sessionData))
                        {
                            // respond HTTP 401 Unauthorized with empty body.
                            //ctx.Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            //ctx.Context.Response.ContentLength = 0;
                            //ctx.Context.Response.Body = Stream.Null;

                            // - or, redirect to another page. -
                            ctx.Context.Response.Redirect("/");
                        }
                    }

                }
            });
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapFallbackToFile("/chat.html");
                endpoints.MapHub<ChatHub>("/chatHub");

            });
            //app.UseSignalR(opt => opt.MapHub<ChatHub>("/chatHub"));
        }
    }
}

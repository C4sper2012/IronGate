using Auth0.AspNetCore.Authentication;
using Blazored.LocalStorage;
using Irongate.Service.Interfaces;
using Irongate.Service.Models;
using Irongate.Service.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using uPLibrary.Networking.M2Mqtt;

namespace Irongate.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddScoped<IWaterLevelSevice, WaterLevelService>();
            builder.Services.AddScoped<IMotionSensorService, MotionSensorService>();
            builder.Services.AddScoped<IWindowService, WindowService>();
            builder.Services.AddScoped<IClimateService, ClimateService>();
            builder.Services.AddScoped<ILogService, LogService>();

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddAuth0WebAppAuthentication(options =>
            {
                options.Domain = builder.Configuration["Auth0:Domain"];
                options.ClientId = builder.Configuration["Auth0:ClientId"];
                options.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
                options.Scope = "openid profile email roles";
                options.CallbackPath = "/callback";
            }).WithAccessToken(options =>
            {
                options.Audience = builder.Configuration["Auth0:Audience"];
            });

            builder.Services.AddHttpContextAccessor();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
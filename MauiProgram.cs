using CommunityToolkit.Maui;
using MAUI.Common;
using MAUI.Services;
using MAUI.View;
using MAUI.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Reflection;

namespace Matt
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream("Matt.launchSettings.json");

            AppSettings appSettings = new();

            if (stream != null)
            {
                var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

                builder.Configuration.Bind("AppSettings", config);

                var baseWebUri = config.GetRequiredSection("AppSettings:BaseWebUri").Get<string>();
                var apis = config.GetRequiredSection("AppSettings:APIs").Get<List<WebApi>>();

                if (baseWebUri != null)
                {
                    appSettings.BaseWebUri = baseWebUri;
                }

                if (apis != null)
                {
                    appSettings.APIs = apis;

                    foreach (var api in apis)
                    {
                        if (string.IsNullOrWhiteSpace(api.BaseUri)) continue;

                        builder.Services.AddHttpClient(api.Name, client => client.BaseAddress = new Uri(api.BaseUri));
                    }
                }

            }

            //Registering SERVICES

            builder.Services.AddScoped<IApiRequestHelper, ApiRequestHelper>();
            builder.Services.AddSingleton<AppSettings>(appSettings);

            // Services
            builder.Services.AddScoped<IUserService, UserService>();


            //Pages
            builder.Services.AddSingleton<MainPage>();


            //ViewModel
            builder.Services.AddSingleton<SampleViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");    

            return builder.Build();
        }
    }
}

using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Kama.Organization.API.Startup))]
[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Kama.Organization.API.Startup), "Started")]

namespace Kama.Organization.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            ConfigureIoC(config);

            SwaggerConfig.Register(config);

            WebApiConfig.Register(config);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
            //app.Use<UserRoleMiddleware>(IOC.Activator.Container);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var accessTokenExpireTimeSpan = 60;
            if (System.Web.Configuration.WebConfigurationManager.AppSettings["AccessTokenExpireTimeSpan"] != null)
                accessTokenExpireTimeSpan = int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["AccessTokenExpireTimeSpan"]);

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(accessTokenExpireTimeSpan),
                Provider = new Providers.AuthorizationServerProvider(),
                RefreshTokenProvider = new Providers.RefreshTokenProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

        public void ConfigureIoC(HttpConfiguration config)
        {
            var container = IOC.Activator.Instance.ActiveWebApi(config, System.Reflection.Assembly.GetExecutingAssembly());

            RegisterTools(container);

            AppCore.IOC.Loader.Load(container, System.Web.Hosting.HostingEnvironment.MapPath("~/bin"));

            RegisterFilters(container, config);
        }

        public static void Started()
        {
            var errorCodeFilename = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/ErrorCode.xml");

            var resultMessageProvider = IOC.Activator.Container.TryResolve<Core.IResultMessageProvider>();

            resultMessageProvider?.Init(errorCodeFilename);
        }

        public static void Stop()
            => IOC.Activator.Instance.Deactivate();

        private static void RegisterTools(AppCore.IOC.IContainer container)
        {
            container.RegisterType<AppCore.IObjectSerializer, Tools.ObjectSerializer>();
            container.RegisterType<Core.IEventLogger, Tools.Logger>();
            container.RegisterType<Core.IRequestInfo, Tools.RequestInfo>();
            container.RegisterType<Core.IAppSetting, Tools.AppSetting>();
        }

        private static void RegisterFilters(AppCore.IOC.IContainer container, HttpConfiguration httpConfig)
        {
        }
    }
}
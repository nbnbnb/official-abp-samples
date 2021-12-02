using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace PublicWebSite.Host
{
    public class PublicWebSiteMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public PublicWebSiteMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name != StandardMenus.Main)
            {
                await Task.CompletedTask;
            }

            //TODO: Localize menu items
            context.Menu.AddItem(new ApplicationMenuItem("App.Home", "Home", "/"));
            context.Menu.AddItem(new ApplicationMenuItem("App.Products", "Products", "/Products"));
            context.Menu.AddItem(new ApplicationMenuItem("App.Blog", "Blog", "/blog/abp"));

            if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }

            await Task.CompletedTask;
        }

        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();

            var identityServerUrl = _configuration["AuthServer:Authority"] ?? "";

            if (currentUser.IsAuthenticated)
            {
                //TODO: Localize menu items
                context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", "Manage Your Profile", $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage", icon: "fa fa-cog", order: 1000, null, "_blank"));
                context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", "Logout", url: "/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000));
            }

            return Task.CompletedTask;
        }
    }
}

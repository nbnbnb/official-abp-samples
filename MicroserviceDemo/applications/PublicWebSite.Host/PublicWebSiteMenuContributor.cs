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
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            //TODO: Localize menu items
            context.Menu.AddItem(new ApplicationMenuItem("App.Home", "Home", "/"));
            context.Menu.AddItem(new ApplicationMenuItem("App.Products", "Products", "/Products"));
            context.Menu.AddItem(new ApplicationMenuItem("App.Blog", "Blog", "/blog/abp"));

            return Task.CompletedTask;
        }

    }
}

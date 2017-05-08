using Abp.Application.Navigation;
using Abp.Localization;
using Pannexus.PsNutrac.Authorization;

namespace Pannexus.PsNutrac.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class SampleLTENavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", SampleLTEConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Tenants",
                        L("Tenants"),
                        url: "#tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Users",
                        L("Users"),
                        url: "#users",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Users
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", SampleLTEConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Administration",
                        L("Administration"),
                        icon: "fa fa-desktop",
                        requiredPermissionName: PermissionNames.Pages_Admin
                    ).AddItem(new MenuItemDefinition(
                        "Schemes",
                        L("Schemes"),
                        url: "#schemes",
                        icon: "fa fa-tree"
                     )).AddItem(new MenuItemDefinition(
                        "Banks",
                        L("Banks"),
                        url: "#banks",
                        icon: "fa fa-bank"
                     ))
                     .AddItem(new MenuItemDefinition(
                        "Crops",
                        L("Crops"),
                        url: "#crops",
                        icon: "fa fa-plant"
                     ))
                     .AddItem(new MenuItemDefinition(
                        "PaymentPeriods",
                        L("PaymentPeriods"),
                        url: "#payment-periods",
                        icon: "fa fa-money"
                     ))
                     .AddItem(new MenuItemDefinition(
                        "Tenors",
                        L("Tenors"),
                        url: "#tenors",
                        icon: "fa fa-clock"
                     ))
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SampleLTEConsts.LocalizationSourceName);
        }
    }
}

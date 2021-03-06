using Prism.Ioc;
using Prism.Modularity;
using QuickLaunch.Modules.Applications;
using QuickLaunch.Services;
using QuickLaunch.Services.Interfaces;
using QuickLaunch.Views;
using System.Windows;

namespace QuickLaunch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationService, ApplicationService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ApplicationModule>();
        }
    }
}

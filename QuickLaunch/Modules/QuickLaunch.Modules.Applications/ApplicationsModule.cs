using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using QuickLaunch.Core;

namespace QuickLaunch.Modules.Applications
{
    public class ApplicationsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ApplicationsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            //_regionManager.RequestNavigate(RegionNames.ContentRegion, "ViewA");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}
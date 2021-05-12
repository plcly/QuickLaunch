using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using QuickLaunch.Core.Mvvm;
using QuickLaunch.Infrastructure;
using QuickLaunch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickLaunch.Modules.Applications.ViewModels
{
    public class ApplicationViewModel : RegionViewModelBase
    {
        public ApplicationViewModel(IRegionManager regionManager, IApplicationService applicationsService) : base(regionManager)
        {
            ApplicationDtoList = applicationsService.GetAllApplications();
        }
        private List<ApplicationDto> applicationDtoList;
        public List<ApplicationDto> ApplicationDtoList
        {
            get { return applicationDtoList; }
            set { SetProperty(ref applicationDtoList, value); }
        }
        private DelegateCommand<ApplicationDto> excuteApplication;
        public DelegateCommand<ApplicationDto>  ExcuteApplication =>
            excuteApplication ?? (excuteApplication = new DelegateCommand<ApplicationDto>(ExecuteApplicationCommand));

        void ExecuteApplicationCommand(ApplicationDto applicationDto)
        {
            if (applicationDto!=null)
            {
                applicationDto.Run();
            }
        }
    }
}

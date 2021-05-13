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
        private List<ApplicationDto> localApplicationDtos;
        public ApplicationViewModel(IRegionManager regionManager, IApplicationService applicationsService) : base(regionManager)
        {
            localApplicationDtos = applicationsService.GetAllApplications();
            if (localApplicationDtos != null)
            {
                Categories = localApplicationDtos.GroupBy(p => p.Category).Select(p => new ApplicationDto
                {
                    Category = p.Key,
                    CategoryIcon = p.FirstOrDefault()?.CategoryIcon
                }).ToList();
                ApplicationDtoList = localApplicationDtos.Where(p => p.Category == Categories.First().Category).ToList();
            }

        }

        private List<ApplicationDto> categories;
        public List<ApplicationDto> Categories
        {
            get { return categories; }
            set { SetProperty(ref categories, value); }
        }

        private List<ApplicationDto> applicationDtoList;
        public List<ApplicationDto> ApplicationDtoList
        {
            get { return applicationDtoList; }
            set { SetProperty(ref applicationDtoList, value); }
        }
        private DelegateCommand<ApplicationDto> excuteApplication;
        public DelegateCommand<ApplicationDto> ExcuteApplication =>
            excuteApplication ?? (excuteApplication = new DelegateCommand<ApplicationDto>(ExecuteApplicationCommand));

        void ExecuteApplicationCommand(ApplicationDto applicationDto)
        {
            if (applicationDto != null)
            {
                applicationDto.Run();
            }
        }

        private DelegateCommand<ApplicationDto> selectCategory;
        public DelegateCommand<ApplicationDto> SelectCategory =>
            selectCategory ?? (selectCategory = new DelegateCommand<ApplicationDto>(ExecuteCommandSelectCategory));

        void ExecuteCommandSelectCategory(ApplicationDto category)
        {
            ApplicationDtoList = localApplicationDtos.Where(p => p.Category == category.Category).ToList();
        }
    }
}

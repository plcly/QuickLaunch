using QuickLaunch.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLaunch.Services.Interfaces
{
    public interface IApplicationsService
    {
        List<ApplicationDto> GetAllApplications();
    }
}

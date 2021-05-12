using QuickLaunch.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLaunch.Services.Interfaces
{
    public interface IApplicationService
    {
        List<ApplicationDto> GetAllApplications();
    }
}

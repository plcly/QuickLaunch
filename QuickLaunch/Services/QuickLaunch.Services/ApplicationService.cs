using Newtonsoft.Json;
using QuickLaunch.Infrastructure;
using QuickLaunch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLaunch.Services
{
    public class ApplicationService : IApplicationService
    {
        private List<ApplicationDto> _appList;
#if DEBUG
        const string jsonFile = "LocalApplications.json";
#else
        const string jsonFile = "Applications.json";
#endif
        public List<ApplicationDto> GetAllApplications()
        {
            if (File.Exists(jsonFile))
            {
                if (_appList == null)
                {
                    var json = File.ReadAllText(jsonFile);
                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            _appList = JsonConvert.DeserializeObject<List<ApplicationDto>>(json);
                            _appList.ForEach(app =>
                            {
                                app.IconPath = Path.Combine(Directory.GetCurrentDirectory(), app.IconPath);
                                app.CategoryIcon = Path.Combine(Directory.GetCurrentDirectory(), app.CategoryIcon);
                            });
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
                return _appList;
            }
            return null;
        }
    }
}

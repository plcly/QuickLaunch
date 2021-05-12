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
    public class ApplicationsService: IApplicationsService
    {
        private List<ApplicationDto> _appList;
        const string jsonFile = "Applications.json";
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

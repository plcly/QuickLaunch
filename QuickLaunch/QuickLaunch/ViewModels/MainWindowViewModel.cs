using Prism.Mvvm;

namespace QuickLaunch.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "快速导航工具";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}

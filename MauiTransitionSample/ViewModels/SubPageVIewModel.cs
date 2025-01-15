using System.Windows.Input;

namespace MauiNavigationSample.ViewModels
{
    public class SubPageViewModel : ViewModelBase
    {
        private readonly IServiceProvider _serviceProvider;

        private string _title = "Sub Page";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ICommand GoBackCommand { get; }

        public SubPageViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            GoBackCommand = new Command(async () =>
            {
                var navigation = Application.Current?.MainPage?.Navigation;
                if (navigation != null)
                {
                    await navigation.PopAsync(animated: true);
                }
            });
            
        }
    }
}
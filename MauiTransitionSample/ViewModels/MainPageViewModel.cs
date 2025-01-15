using MauiNavigationSample.ViewModels;
using MauiTransitionSample.Views;
using System.Windows.Input;

namespace MauiTransitionSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IServiceProvider _serviceProvider;
        
        private string _title = "Main Page";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ICommand NavigateToSubPageCommand { get; }

        public MainPageViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            
            NavigateToSubPageCommand = new Command(async () =>
            {
                var navigation = Application.Current?.MainPage?.Navigation;
                if (navigation != null)
                {
                    var subPage = _serviceProvider.GetRequiredService<SubPage>();
                    await navigation.PushAsync(subPage, animated: true);
                }
            });
        }
    }
}
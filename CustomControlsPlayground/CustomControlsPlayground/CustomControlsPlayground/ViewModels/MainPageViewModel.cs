using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CustomControlsPlayground.Services;

namespace CustomControlsPlayground.ViewModels;

public partial class MainPageViewModel : ViewModelBase
{
    [ObservableProperty] private IAsyncRelayCommand _navigateToChartPage;
    public MainPageViewModel(INavigationService navigationService)
    {
        Title = "Custom controls playground";
        _navigateToChartPage = new AsyncRelayCommand(async () => await navigationService.NavigateToChartPage());
    }
}
using CustomControlsPlayground.Views;

namespace CustomControlsPlayground.Services;

public interface INavigationService
{
    Task NavigateToChartPage();
    Task NavigateToGaugeChartPage();
}

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _services;
    private INavigation Navigation => Application.Current?.MainPage?.Navigation;

    public NavigationService(IServiceProvider services)
    {
        _services = services;
    }

    private async Task NavigateToPage<T>() where T : Page
    {
        await Navigation.PushAsync(_services.GetService<T>());
    }

    public async Task NavigateToChartPage() => await NavigateToPage<ChartPage>();
    public async Task NavigateToGaugeChartPage() => await NavigateToPage<GaugeChartPage>();
}


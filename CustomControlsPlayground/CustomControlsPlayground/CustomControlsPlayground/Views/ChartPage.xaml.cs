using CustomControlsPlayground.ViewModels;

namespace CustomControlsPlayground.Views;

public partial class ChartPage : ContentPage
{
    public ChartPage(ChartViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
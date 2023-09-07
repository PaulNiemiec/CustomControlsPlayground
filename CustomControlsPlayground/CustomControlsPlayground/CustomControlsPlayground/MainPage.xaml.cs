using CustomControlsPlayground.VIewModels;

namespace CustomControlsPlayground;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
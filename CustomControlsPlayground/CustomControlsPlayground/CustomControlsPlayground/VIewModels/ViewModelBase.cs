using CommunityToolkit.Mvvm.ComponentModel;

namespace CustomControlsPlayground.VIewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty] private bool _isBusy;
    [ObservableProperty] private string _title;

    public virtual Task OnNavigatingTo(object parameter)
    {
        return Task.CompletedTask;
    }

    public virtual Task OnNavigatedTo()
    {
        return Task.CompletedTask;
    }
}
using Bindables.Maui;

namespace CustomControlsPlayground.Controls.Chart;

public partial class Chart : ContentView
{
    [BindableProperty(typeof(ChartDataPoint[]), OnPropertyChanged = nameof(OnDataSetPropertyChanged))]
    public static readonly BindableProperty DataSet;
}
using CustomControlsPlayground.Controls.Chart;

namespace CustomControlsPlayground.VIewModels;

public partial class MainPageViewModel : ViewModelBase
{
    public ChartDataPoint[] DataSet { get; } = 
    {
        new() { Name = "Name1", Value = 15 },
        new ChartDataPoint() { Name = "Name2", Value = 5 },
        new ChartDataPoint() { Name = "Name3", Value = 26 },
        new ChartDataPoint() { Name = "Name4", Value = 13 },
        new() {Name = "Name5", Value = 31}
    };

    public double[] YAxisValues { get; } = { 0, 10, 20, 30, 40, 50 };
    public int YGraduation { get; } = 6;
    public MainPageViewModel()
    {
        Title = "Custom controls playground";
    }
}
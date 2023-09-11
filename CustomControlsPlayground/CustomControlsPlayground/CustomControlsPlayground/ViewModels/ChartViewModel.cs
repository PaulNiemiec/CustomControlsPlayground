using CustomControlsPlayground.Controls.Chart;

namespace CustomControlsPlayground.ViewModels;

public partial class ChartViewModel : ViewModelBase
{
    public ChartDataPoint[] DataSet { get; } = 
    {
        new() { Name = "Name1", Value = 15 },
        new ChartDataPoint() { Name = "Name2", Value = 5 },
        new ChartDataPoint() { Name = "Name3", Value = 26 },
        new ChartDataPoint() { Name = "Name4", Value = 13 },
        new() {Name = "Name5", Value = 31}
    };
    
    public ChartViewModel()
    {
        Title = "Custom controls playground";
    }
}
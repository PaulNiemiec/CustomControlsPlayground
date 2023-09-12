namespace CustomControlsPlayground.Controls.GaugeChart;

public partial class GaugeChart : ContentView
{
    public GaugeChart()
    {
        InitializeComponent();
    }
    
    private static void OnChartColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is GaugeChart chart && newValue is Color color)
        {
            ((GaugeChartDrawable)chart.GaugeChartGraphicsView.Drawable).ChartColor = color;
            chart.GaugeChartGraphicsView.Invalidate();
        }
    }

    private static void OnCurrentValuePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is GaugeChart chart && newvalue is double currentValue)
        {
            ((GaugeChartDrawable)chart.GaugeChartGraphicsView.Drawable).CurrentValue = currentValue;
            chart.GaugeChartGraphicsView.Invalidate();
        }
    }
}
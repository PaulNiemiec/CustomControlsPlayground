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
}
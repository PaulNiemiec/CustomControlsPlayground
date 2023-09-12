namespace CustomControlsPlayground.Controls.GaugeChart;

public partial class GaugeChart
{
    public Color ChartColor
    {
        get => (Color)GetValue(ChartColorProperty);
        set => SetValue(ChartColorProperty, value);
    }
    
    public static readonly BindableProperty ChartColorProperty = BindableProperty.Create(
        nameof(ChartColor),
        typeof(Color),
        typeof(GaugeChart),
        Colors.Black,
        propertyChanged: OnChartColorPropertyChanged);
    
    public double CurrentValue
    {
        get => (double)GetValue(CurrentValueProperty);
        set => SetValue(CurrentValueProperty, value);
    }
    
    public static readonly BindableProperty CurrentValueProperty = BindableProperty.Create(
        nameof(CurrentValue),
        typeof(double),
        typeof(GaugeChart),
        0d,
        propertyChanged: OnCurrentValuePropertyChanged);
}
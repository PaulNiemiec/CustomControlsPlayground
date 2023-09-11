namespace CustomControlsPlayground.Controls.Chart;

public partial class Chart : ContentView
{
    public ChartType ChartType
    {
        get => (ChartType)GetValue(ChartTypeProperty);
        set => SetValue(ChartTypeProperty, value);
    }
    
    public static readonly BindableProperty ChartTypeProperty = BindableProperty.Create(
        nameof(DataSet),
        typeof(ChartType),
        typeof(Chart),
        propertyChanged: OnChartTypePropertyChanged);

    public ChartDataPoint[] DataSet
    {
        get => (ChartDataPoint[])GetValue(DataSetProperty);
        set => SetValue(DataSetProperty, value);
    }
    
    public static readonly BindableProperty DataSetProperty = BindableProperty.Create(
        nameof(DataSet),
        typeof(ChartDataPoint[]),
        typeof(Chart),
        propertyChanged: OnDataSetPropertyChanged);

    public Color ChartColor
    {
        get => (Color)GetValue(ChartColorProperty);
        set => SetValue(ChartColorProperty, value);
    }
    
    public static readonly BindableProperty ChartColorProperty = BindableProperty.Create(
        nameof(ChartColor),
        typeof(Color),
        typeof(Chart),
        Colors.Black,
        propertyChanged: OnChartColorPropertyChanged);
}
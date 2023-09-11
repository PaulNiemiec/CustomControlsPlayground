namespace CustomControlsPlayground.Controls.Chart;

public partial class Chart : ContentView
{
    private const int YAxisGraduation = 5;
    public Chart()
    {
        InitializeComponent();
    }

    private void GenerateXAxisLabels()
    {
        for(var i = 0; i < DataSet.Length; i++)
        {
            XAxisGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
            
            var label = new Label { Text = DataSet[i].Name, VerticalTextAlignment = TextAlignment.Center };
            XAxisGrid.Add(label, i);
        }
    }
    
    private void GenerateYAxisLabels()
    {
        var orderedYAxisValues = GenerateYAxisValues().ToList();

        for(var i = 0; i < orderedYAxisValues.Count; i++)
        {
            YAxisGrid.RowDefinitions.Add(new RowDefinition(GridLength.Star));
            
            var label = new Label { Text = orderedYAxisValues[i].ToString(), HorizontalTextAlignment = TextAlignment.Center };
            YAxisGrid.Add(label, 0,i);
        }
    }

    private IEnumerable<int> GenerateYAxisValues()
    {
        var values = new List<int>();

        var maxAvailableValue = (int)DataSet.Max(dataSet => dataSet.Value);
        var step = (int)Math.Ceiling(maxAvailableValue / (double)(YAxisGraduation - 1));

        for (var i = 0; i < YAxisGraduation; i ++)
        {
            values.Add(i == 0 ? 0 : step * i);
        }

        return values.OrderByDescending(v => v);
    }

    private void TryToInvalidate()
    {
        if (DataSet != null)
        {
            ChartGraphicsView.Invalidate();
        }
    }

    #region PropertyChangedMethods

    private static void OnDataSetPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is Chart chart && newValue is ChartDataPoint[] dataSet)
        {
            chart.GenerateXAxisLabels();
            chart.GenerateYAxisLabels();
            ((ChartDrawable)chart.ChartGraphicsView.Drawable).DataSet = dataSet;
            chart.ChartGraphicsView.Invalidate();
        }
    }
    
    private static void OnChartTypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is Chart chart && newValue is ChartType chartType)
        {
            ((ChartDrawable)chart.ChartGraphicsView.Drawable).ChartType = chartType;
            chart.TryToInvalidate();
        }
    }

    private static void OnChartColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is Chart chart && newValue is Color color)
        {
            ((ChartDrawable)chart.ChartGraphicsView.Drawable).ChartColor = color;
            chart.TryToInvalidate();
        }
    }

    #endregion
}
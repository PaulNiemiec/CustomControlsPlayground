namespace CustomControlsPlayground.Controls.Chart;

public class ChartDrawable : IDrawable
{
    private const int YAxisGraduation  = 5;
    private const int StrokeSize = 15;
    
    public ChartDataPoint[] DataSet { get; set; }
    public ChartType ChartType { get; set; }
    public Color ChartColor { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        switch (ChartType)
        {
            case ChartType.Bar:
                DrawBarChart(canvas, dirtyRect);
                break;
            case ChartType.Linear:
                DrawLinearChart(canvas, dirtyRect);
                break;
            default:
                DrawBarChart(canvas, dirtyRect);
                break;
        }
    }

    #region LinearChart

    private void DrawLinearChart(ICanvas canvas, RectF dirtyRect)
    {
        
    }

    #endregion
    #region BarChart

    private void DrawBarChart(ICanvas canvas, RectF dirtyRect)
    {
        var yPositions =
            CreateEqualPositionsBetweenStartAndEnd(dirtyRect.Y, dirtyRect.Y + dirtyRect.Height, YAxisGraduation, false)
                .ToList();
        var xPositions =
            CreateEqualPositionsBetweenStartAndEnd(dirtyRect.X, dirtyRect.X + dirtyRect.Width, DataSet.Length, false)
                .ToArray();

        canvas.StrokeColor = Colors.LightGray;
        canvas.StrokeSize = 1;

        DrawHorizontalLines(canvas, yPositions, dirtyRect);
        canvas.DrawLine(dirtyRect.X, dirtyRect.Y, dirtyRect.X, yPositions.Max());

        DrawBars(canvas, xPositions, yPositions.Max(), yPositions.Min());
    }

    private void DrawBars(ICanvas canvas, float[] xPositions, float yMax, float yMin)
    {
        canvas.StrokeSize = StrokeSize;
        canvas.StrokeColor = ChartColor;

        var chartHeight = yMax - yMin;
        var max = (int)Math.Ceiling(DataSet.Max(dataSet => dataSet.Value) / ((double)YAxisGraduation - 1)) *
                  (YAxisGraduation - 1);

        for (var i = 0; i < xPositions.Length && i < DataSet.Length; i++)
        {
            var barHeight = yMax - DataSet[i].Value / max * chartHeight;
            canvas.DrawLine(xPositions[i], yMax,xPositions[i], barHeight);
        }
    }

    #endregion
    
    private IEnumerable<float> CreateEqualPositionsBetweenStartAndEnd(float start, float end, int factor, bool shouldStartAtTheBeginning = true)
    {
        var length = end - start;
        var step = length / factor;

        var positions = new float[(int)Math.Ceiling(length / step)];
        
        for (var i = 0; i < positions.Length; i++)
        {
            positions[i] = i == 0 ? shouldStartAtTheBeginning ? start : start + step : positions[i-1] + step;
        }
        for (var i = 0; i < positions.Length; i++)
        {
            positions[i] -= step / 2.0f;
        }

        return positions;
    }
    
    private void DrawHorizontalLines(ICanvas canvas, IEnumerable<float> yPositions, RectF dirtyRect)
    {
        foreach (var yPosition in yPositions)
        {
            canvas.DrawLine(dirtyRect.X, yPosition, dirtyRect
                .X + dirtyRect.Width, yPosition);
        }
    }
}
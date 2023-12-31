namespace CustomControlsPlayground.Controls.Chart;

public class ChartDrawable : IDrawable
{
    private const int YAxisGraduation  = 5;
    private const int StrokeSize = 15;
    
    public ChartDataPoint[] DataSet { get; set; }
    public ChartType ChartType { get; set; }
    public Color ChartColor { get; set; }
    
    private float MaxValue => (int)Math.Ceiling(DataSet.Max(dataSet => dataSet.Value) / ((double)YAxisGraduation - 1)) *
                              (YAxisGraduation - 1);

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        var yPositions =
            CreateEqualPositionsBetweenStartAndEnd(dirtyRect.Y, dirtyRect.Y + dirtyRect.Height, YAxisGraduation, false)
                .ToArray();
        var xPositions =
            CreateEqualPositionsBetweenStartAndEnd(dirtyRect.X, dirtyRect.X + dirtyRect.Width, DataSet.Length, false)
                .ToArray();

        canvas.StrokeColor = Colors.LightGray;
        canvas.StrokeSize = 1;

        DrawHorizontalLines(canvas, yPositions, dirtyRect);
        
        switch (ChartType)
        {
            case ChartType.Bar:
                DrawBarChart(canvas, dirtyRect, yPositions, xPositions);
                break;
            case ChartType.Linear:
                DrawLinearChart(canvas, dirtyRect, yPositions, xPositions);
                break;
            default:
                DrawBarChart(canvas, dirtyRect, yPositions ,xPositions);
                break;
        }
    }

    private void DrawLinearChart(ICanvas canvas, RectF dirtyRect, IReadOnlyList<float> yPositions, IReadOnlyList<float> xPositions)
    {
        canvas.StrokeSize = 4;
        canvas.StrokeColor = Color.FromRgba(ChartColor.Red, ChartColor.Green, ChartColor.Blue, 0.2);
        
        var chartHeight = yPositions.Max() - yPositions.Min();

        canvas.FillColor = ChartColor;

        for(var i = 1; i < yPositions.Count && i < DataSet.Length; i++)
        {
            var previousHeight = yPositions.Max() - DataSet[i - 1].Value / MaxValue * chartHeight;
            var currentHeight = yPositions.Max() - DataSet[i].Value / MaxValue * chartHeight;
            
            if (i == 1)
            {
                canvas.FillEllipse(xPositions[i - 1] - 4, previousHeight - 4, 8,8);
            }
            canvas.FillEllipse(xPositions[i] - 4, currentHeight - 4, 8,8);
            
            canvas.DrawLine(xPositions[i - 1],previousHeight, xPositions[i], currentHeight);
        }
    }

    private void DrawBarChart(ICanvas canvas, RectF dirtyRect, IReadOnlyCollection<float> yPositions, IReadOnlyList<float> xPositions)
    {
        canvas.DrawLine(dirtyRect.X, dirtyRect.Y, dirtyRect.X, yPositions.Max());
        
        canvas.StrokeColor = ChartColor;
        canvas.StrokeSize = StrokeSize;

        var chartHeight = yPositions.Max() - yPositions.Min();

        for (var i = 0; i < xPositions.Count && i < DataSet.Length; i++)
        {
            var barHeight = yPositions.Max() - DataSet[i].Value / MaxValue * chartHeight;
            canvas.DrawLine(xPositions[i], yPositions.Max(),xPositions[i], barHeight);
        }
    }

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
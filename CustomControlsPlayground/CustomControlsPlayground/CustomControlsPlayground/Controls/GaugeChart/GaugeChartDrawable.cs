
namespace CustomControlsPlayground.Controls.GaugeChart;

public class GaugeChartDrawable : IDrawable
{
    private const int GaugeWidth = 32;

    public Color ChartColor { get; set; } = Colors.Aqua;

    private readonly string[] _labelsValues = CreateLabelsValues();
    private PointF? _arcCenter;

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        _arcCenter ??= new PointF(dirtyRect.Width / 2.0f, dirtyRect.Height/ 2.0f);

        //canvas.FillRectangle(dirtyRect.X, dirtyRect.Y, dirtyRect.Width, dirtyRect.Height);
        //canvas.DrawString("Text", 0, 0, dirtyRect.Width, dirtyRect.Height, HorizontalAlignment.Left, VerticalAlignment.Top, textFlow: TextFlow.OverflowBounds);
        DrawLabels(canvas, dirtyRect);
    }

    private void DrawLabels(ICanvas canvas, RectF dirtyRect)
    {
        canvas.FontSize = 10;
        canvas.FontColor = Colors.White;
        
        var radius = dirtyRect.Width < dirtyRect.Height ? dirtyRect.Width / 2f - 10 : dirtyRect.Height / 2f - 10;

        var angleStep = 180 / (float)_labelsValues.Length;
        var currentAngle = 0f;

        foreach (var labelValue in _labelsValues)
        {
            var angleInRadians = currentAngle * Math.PI / 180;
            
            var x = _arcCenter!.Value.X + radius * (float)Math.Cos(angleInRadians);
            var y = _arcCenter!.Value.X + radius * (float)Math.Sin(angleInRadians);
            
            canvas.DrawString(labelValue, x,y,dirtyRect.Width, dirtyRect.Height, HorizontalAlignment.Left, VerticalAlignment.Top, TextFlow.OverflowBounds);
            currentAngle += angleStep;
        }
    }

    private static string[] CreateLabelsValues()
    {
        var labels = new string[11];

        for (var i = 0; i < labels.Length; i++)
        {
            labels[i] = (i*10).ToString();
        }

        return labels;
    }
}
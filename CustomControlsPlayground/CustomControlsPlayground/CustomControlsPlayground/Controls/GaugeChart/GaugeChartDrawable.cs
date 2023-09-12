
using Font = Microsoft.Maui.Font;

namespace CustomControlsPlayground.Controls.GaugeChart;

public class GaugeChartDrawable : IDrawable
{
    public Color ChartColor { get; set; } = Colors.Aqua;
    public double CurrentValue { get; set; }
    
    private PointF _center;
    private const float Margin = 20;

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (CurrentValue == 0)
        {
            return;
        }
        
        if (_center == default)
        {
            _center = dirtyRect.Center;
        }

        var radius = dirtyRect.Width > dirtyRect.Height ? dirtyRect.Height / 2f : dirtyRect.Width / 2f;
        radius -= Margin;

        canvas.StrokeSize = 32;
        canvas.StrokeColor = Colors.LightGray;
        canvas.DrawCircle(_center, radius);

        var currentValueRadius = 360f * (float)(CurrentValue * 0.01) + 90;

        canvas.StrokeColor = ChartColor;
        canvas.DrawArc(dirtyRect.X + Margin, dirtyRect.Y + Margin, radius * 2, radius * 2, 90,
            currentValueRadius, false, false);

        canvas.FontSize = 32;
        canvas.DrawString($"{Math.Round(CurrentValue)}%", dirtyRect, HorizontalAlignment.Center, VerticalAlignment.Center);
    }
}
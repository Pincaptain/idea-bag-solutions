using System.Drawing;

namespace NewtonianGravitySimulation.Presentation.Extensions
{
    public static class GraphicsExtensions
    {
        public static void DrawCircle(this Graphics graphics, Pen pen, float x, float y, float radius)
        {
            var diameter = radius + radius;
            
            graphics.DrawEllipse(pen, x - radius, y - radius, diameter, diameter);
        }

        public static void FillCircle(this Graphics graphics, Brush brush, float x, float y, float radius)
        {
            var diameter = radius + radius;
            
            graphics.FillEllipse(brush, x - radius, y - radius, diameter, diameter);
        }
    }
}
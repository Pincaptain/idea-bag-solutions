using System;
using System.Drawing;

namespace NewtonianGravitySimulation.Presentation.Extensions
{
    public static class ColorExtensions
    {
        public static Color GenerateColor()
        {
            var random = new Random();
            
            var red = random.Next(255);
            var green = random.Next(255);
            var blue = random.Next(255);

            return Color.FromArgb(red, green, blue);
        }
    }
}
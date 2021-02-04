using System.Drawing;
using NewtonianGravitySimulation.Model;

namespace NewtonianGravitySimulation.Presentation.Extensions
{
    public static class EntityExtensions
    {
        public static Brush GetBrush(this Entity entity)
        {
            return new SolidBrush(entity.Color);
        }
    }
}
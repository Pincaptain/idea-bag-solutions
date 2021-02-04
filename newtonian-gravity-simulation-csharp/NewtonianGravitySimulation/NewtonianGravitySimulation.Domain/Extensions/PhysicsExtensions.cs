using System;
using NewtonianGravitySimulation.Model;

namespace NewtonianGravitySimulation.Domain.Extensions
{
    public static class PhysicsExtensions
    {
        private const int MassLimit = 10;

        public static float GenerateMass()
        {
            var random = new Random();
            
            return random.Next(1, MassLimit);
        }

        private static float CalculateDistance(Entity xEntity, Entity yEntity)
        {
            return (float) Math.Sqrt(Math.Pow(yEntity.X - xEntity.X, 2) + Math.Pow(yEntity.Y - xEntity.Y, 2));
        }
        
        public static float CalculateGravitationalForce(Entity xEntity, Entity yEntity)
        {
            return xEntity.Mass * yEntity.Mass / CalculateDistance(xEntity, yEntity);
        }
    }
}
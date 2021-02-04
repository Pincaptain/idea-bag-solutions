using System;
using System.Collections.Generic;
using System.Linq;
using NewtonianGravitySimulation.Model;

namespace NewtonianGravitySimulation.Domain.Extensions
{
    public static class EntityExtensions
    {
        public static void NewtonianMove(this Entity entity, List<Entity> entities)
        {
            if (entities.Count == 1) return;

            var strongestEntity = entities
                .Where(e => !e.Equals(entity))
                .OrderBy(e => PhysicsExtensions.CalculateGravitationalForce(entity, e))
                .FirstOrDefault();

            if (strongestEntity == null) return;

            var velocity = PhysicsExtensions.CalculateGravitationalForce(entity, strongestEntity);
            
            Console.WriteLine(velocity);
            Console.WriteLine(entity);
            Console.WriteLine(strongestEntity);
            
            var xVelocity = entity.X > strongestEntity.X ? -velocity : velocity;
            var yVelocity = entity.Y > strongestEntity.Y ? -velocity : velocity;

            entity.X += xVelocity;
            entity.Y += yVelocity;
        }
        
        public static void Move(this Entity entity, List<Entity> entities)
        {
            if (entities.Count == 1)
            {
                return;
            }
            
            var closestEntity = entities
                .Where(other => !other.Equals(entity))
                .Where(other => entity.Radius < other.Radius)
                .OrderBy(other => Math.Pow(entity.X - other.X, 2) + Math.Pow(entity.Y - other.Y, 2))
                .FirstOrDefault();

            if (closestEntity == null)
            {
                return;
            }
            
            var xVelocity = entity.X > closestEntity.X ?
                -1 : Math.Abs(entity.X - closestEntity.X) < 0.1f ? 0 : 1;
            var yVelocity = entity.Y > closestEntity.Y ?
                -1 : Math.Abs(entity.Y - closestEntity.Y) < 0.1f ? 0 : 1;

            entity.X += xVelocity;
            entity.Y += yVelocity;
        }

        public static bool IsColliding(this Entity entity, Entity other)
        {
            return Math.Pow(other.X - entity.X, 2) + Math.Pow(entity.Y - other.Y, 2) <=
                   Math.Pow(entity.Radius + other.Radius, 2);
        }
    }
}
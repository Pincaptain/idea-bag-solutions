using System.Collections.Generic;
using NewtonianGravitySimulation.Model;

namespace NewtonianGravitySimulation.Domain
{
    public class EntityService
    {
        private readonly List<Entity> _entities;

        public EntityService()
        {
            _entities = new List<Entity>();
        }

        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            _entities.Remove(entity);
        }

        public List<Entity> GetEntities()
        {
            return _entities;
        }
    }
}
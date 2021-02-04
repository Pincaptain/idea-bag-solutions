#nullable enable
using System;
using System.Drawing;

namespace NewtonianGravitySimulation.Model
{
    public class Entity
    {
        private readonly Guid _guid = Guid.NewGuid();
        public float X { get; set; }
        public float Y { get; set; }
        public float Radius => Mass;
        public Color Color { get; set; }
        public float Mass { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            var other = (Entity) obj;

            return _guid.Equals(other._guid);
        }

        public override int GetHashCode()
        {
            return _guid.GetHashCode();
        }

        public override string ToString()
        {
            return $"{_guid} (X: {X}, Y: {Y}, Color: {Color}, Mass: {Mass})";
        }
    }
}
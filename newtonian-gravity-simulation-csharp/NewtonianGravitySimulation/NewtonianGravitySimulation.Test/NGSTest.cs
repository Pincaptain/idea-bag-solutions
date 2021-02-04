using System;
using System.Collections.Generic;
using System.Drawing;
using NewtonianGravitySimulation.Domain.Extensions;
using NewtonianGravitySimulation.Model;
using NewtonianGravitySimulation.Presentation.Extensions;
using NUnit.Framework;

namespace NewtonianGravitySimulation.Test
{
    // ReSharper disable once InconsistentNaming
    public class NGSTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGravitationalForceCalculation()
        {
            var xEntity = new Entity()
            {
                X = 800,
                Y = 800,
                Color = ColorExtensions.GenerateColor(),
                Mass = 1f
            };
            
            var yEntity = new Entity()
            {
                X = 0,
                Y = 0,
                Color = ColorExtensions.GenerateColor(),
                Mass = 1f
            };
            
            TestContext.WriteLine(PhysicsExtensions.CalculateGravitationalForce(xEntity, yEntity));
            
            Assert.Greater(PhysicsExtensions.CalculateGravitationalForce(xEntity, yEntity), 0);
        }

        [Test]
        public void TestStrongestEntity()
        {
            var entity = new Entity()
            {
                X = 15,
                Y = 100,
                Color = Color.Red,
                Mass = 20f
            };
            
            var entities = new List<Entity>
            {
                entity,
                new Entity() {X = 10, Y = 10, Color = Color.Aqua, Mass = 10f},
                new Entity() {X = 19, Y = 10, Color = Color.Beige, Mass = 9f}
            };
        }
    }
}
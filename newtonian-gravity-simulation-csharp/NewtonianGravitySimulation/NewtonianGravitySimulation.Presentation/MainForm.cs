using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using NewtonianGravitySimulation.Domain;
using NewtonianGravitySimulation.Domain.Extensions;
using NewtonianGravitySimulation.Model;
using NewtonianGravitySimulation.Presentation.Extensions;

namespace NewtonianGravitySimulation.Presentation
{
    public partial class MainForm : Form
    {
        private readonly EntityService _entityService = new EntityService();
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void AddEntity(float x, float y)
        {
            _entityService.AddEntity(new Entity()
            {
                X = x,
                Y = y,
                Mass = PhysicsExtensions.GenerateMass(),
                Color = ColorExtensions.GenerateColor()
            });
        }

        private void CheckCollisions()
        {
            var entities = _entityService.GetEntities();
            
            for (var i = 0; i < entities.Count; i++)
            {
                for (var j = i + 1; j < entities.Count; j++)
                {
                    if (!entities[i].IsColliding(entities[j])) continue;
                    
                    if (entities[i].Mass > entities[j].Mass)
                    {
                        entities[i].Mass += entities[j].Mass / 2;
                            
                        _entityService.RemoveEntity(entities[j]);
                    }
                    else
                    {
                        entities[j].Mass += entities[i].Mass / 2;
                            
                        _entityService.RemoveEntity(entities[i]);
                    }
                }
            }
        }

        private void UpdateEntities(Graphics graphics)
        {
            foreach (var entity in _entityService.GetEntities())
            {
                entity.NewtonianMove(_entityService.GetEntities());
                graphics.FillCircle(entity.GetBrush(), entity.X, entity.Y, entity.Radius);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UpdateEntities(e.Graphics);
            CheckCollisions();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            AddEntity(e.X, e.Y);
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Invalidate();
        }
    }
}
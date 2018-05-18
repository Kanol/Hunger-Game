using System;
using System.Drawing;

namespace Hunger_Game.GameObjects
{
    public abstract class GameObject
    {
        protected int mass;
        public int Mass
        {
            get { return mass; }
            set
            {
                mass = value;
                UpdateRectangle();
            }
        }
        public Rectangle ObjectRectangle { get; set; }
        public string ImageName { get; set; }
        private Point center;
        public Point Center
        {
            get { return center; }
            set { center = value;
                UpdateRectangle();
            }
        }
        public double SizeCoefficient { get; set; }
        public float RotationDegree { get; set; }
        public abstract Image GetImage();
        public abstract void PlaySound();
        public static Random random = new Random();
        protected void UpdateRectangle()
        {
            int width = Convert.ToInt32(Mass / 8 * SizeCoefficient);
            int height = Convert.ToInt32(Mass / 8 * SizeCoefficient * GetImage().Height / GetImage().Width);
            ObjectRectangle = new Rectangle(Center.X - width / 2, Center.Y - height / 2, width, height);
        }
    }
}

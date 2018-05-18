using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hunger_Game
{
    public class MouseController
    {
        public Point PositionShift = new Point(0, 0);
        public double Angle = 0;
        private Point ScreenCenter = new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
        private const int RadiusOfInactivity = 15;
        private const int RadiusOfActivity = 50;
        public bool IsActive;
        public MouseController(bool isActive = true)
        {
            IsActive = isActive;
            Cursor.Position = ScreenCenter;
            Cursor.Hide();
        }
        public void UpdatePositionShift()
        {
            CheckCursorPosition();
            int speedCoofficient = 2;
            if (GetDistance(ScreenCenter, Cursor.Position) <= RadiusOfInactivity)
                PositionShift = new Point(0, 0);
            else
                PositionShift = new Point((Cursor.Position.X - ScreenCenter.X) / speedCoofficient,
                    (Cursor.Position.Y - ScreenCenter.Y) / speedCoofficient);
        }
        public void CheckCursorPosition()
        {
            Angle = GetAngle(ScreenCenter, Cursor.Position);
            if (IsActive)
            {
                if (GetDistance(ScreenCenter, Cursor.Position) > RadiusOfActivity)
                {
                    var point = GetCoords(Angle, RadiusOfActivity);
                    Cursor.Position = new Point(point.X + ScreenCenter.X, point.Y + ScreenCenter.Y);
                }
            }
        }
        public static double GetAngle(Point center, Point point) =>
            Math.Atan2(point.Y - center.Y, point.X - center.X);
        public static Point GetCoords(double angle, double radius) =>
            new Point(Convert.ToInt32(Math.Cos(angle) * radius), Convert.ToInt32(Math.Sin(angle) * radius));
        public static double GetDistance(Point p1, Point p2) =>
            Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
    }
}

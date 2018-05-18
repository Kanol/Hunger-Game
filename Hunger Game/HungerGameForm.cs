using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hunger_Game
{
    public partial class HungerGameForm : Form
    {
        public HungerGameModel Model;
        public MouseController Controller;
        public static Point ScreenCenter { get; } = new Point(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width / 2),
                Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height / 2));

        public HungerGameForm()
        {
            Controller = new MouseController();
            Model = new HungerGameModel(Controller);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            KeyDown += (sender, args) =>
            {
                if (args.KeyCode == Keys.Escape) Close();
            };
            Paint += (sender, args) =>
            {
                args.Graphics.TranslateTransform(Model.Offset.X, Model.Offset.Y);
                args.Graphics.DrawImage(Model.Level.LevelBackground, Model.Level.LevelBorder);
                foreach (var objectToDraw in Model.Level.LevelObjects)
                    DrawGameObject(objectToDraw, args);
                DrawGameObject(Model.Player, args);
            };
            MouseMove += (sender, args) =>
            {
                Controller.UpdatePositionShift();
            };
            var timer = new Timer();
            timer.Interval = 30;
            timer.Tick += (sender, args) =>
            {
                Model.UpdatePlayer();
                Model.UpdateLevel();
                Invalidate();
            };
            timer.Start();
        }
        public void DrawGameObject(GameObjects.GameObject gameObject, PaintEventArgs args)
        {
            RotateForm(gameObject.RotationDegree, args, gameObject.Center);
            args.Graphics.DrawImage(gameObject.GetImage(), gameObject.ObjectRectangle);
            RotateForm(-gameObject.RotationDegree, args, gameObject.Center);
        }
        public void RotateForm(float angle, PaintEventArgs args, Point center)
        {
            args.Graphics.TranslateTransform(center.X, center.Y);
            args.Graphics.RotateTransform(angle);
            args.Graphics.TranslateTransform(-center.X, -center.Y);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Hunger_Game
{
    public class HungerGameModel
    {
        public MouseController Controller;
        public GameObjects.Player Player;
        public Levels.Level Level;
        public Point Offset = new Point(0, 0);
        public Queue<Levels.Level> Levels = new Queue<Levels.Level>
            (new Levels.Level[] { new Levels.Level1(), new Levels.Level2()
            });
        public HungerGameModel(MouseController controller)
        {
            Controller = controller;
            LoadLevel();
        }
        public void UpdateLevel()
        {
            if (Player.Mass >= Level.MassToPassTheLevel)
            {
                LoadLevel();
            }
            var newObjects = new List<GameObjects.GameObject>();
            foreach (var objectToCheck in Level.LevelObjects)
            {
                if ((CanPlayerEatObject(Player, objectToCheck)) && (Player.Mass >= objectToCheck.Mass * 1.5))
                {
                    Player.Mass += objectToCheck.Mass / 24;
                    objectToCheck.PlaySound();
                }
                else newObjects.Add(objectToCheck);
            }
            Level.LevelObjects = newObjects;
            Offset = new Point(HungerGameForm.ScreenCenter.X - Player.Center.X, HungerGameForm.ScreenCenter.Y - Player.Center.Y);
        }
        public void LoadLevel()
        {
            Level = Levels.Dequeue();
            Player = new GameObjects.Player(new Point(0, 0));
        }
        public void UpdatePlayer()
        {
            Player.Center += new Size(Controller.PositionShift);
            Player.RotationDegree = Convert.ToSingle(Controller.Angle * 180 / Math.PI) + 90;

            if (Player.ObjectRectangle.Left < Level.LevelBorder.Left)
            {
                var leftExtra = Math.Abs(Player.ObjectRectangle.Left - Level.LevelBorder.Left);
                Player.Center = new Point(Player.Center.X + leftExtra, Player.Center.Y);
            }
            else if (Player.ObjectRectangle.Right > Level.LevelBorder.Right)
            {
                var rightExtra = Math.Abs(Player.ObjectRectangle.Right - Level.LevelBorder.Right);
                Player.Center = new Point(Player.Center.X - rightExtra, Player.Center.Y);
            }
            if (Player.ObjectRectangle.Top < Level.LevelBorder.Top)
            {
                var topExtra = Math.Abs(Player.ObjectRectangle.Top - Level.LevelBorder.Top);
                Player.Center = new Point(Player.Center.X, Player.Center.Y + topExtra);
            }
            else if (Player.ObjectRectangle.Bottom > Level.LevelBorder.Bottom)
            {
                var bottomExtra = Math.Abs(Player.ObjectRectangle.Bottom - Level.LevelBorder.Bottom);
                Player.Center = new Point(Player.Center.X, Player.Center.Y - bottomExtra);
            }
        }
        public static bool CanPlayerEatObject(GameObjects.GameObject player, GameObjects.GameObject objectToCheck) =>
            IsRectangleInRectangle(player.ObjectRectangle, objectToCheck.ObjectRectangle);
        public static bool IsRectangleInRectangle(Rectangle r1, Rectangle r2)
        {
            var r3 = Rectangle.Intersect(r1, r2);
            return !((r3.Height == 0) && (r3.Width == 0));
        }
    }

}

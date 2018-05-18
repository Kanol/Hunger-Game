using System;
using System.Collections.Generic;
using System.Drawing;

namespace Hunger_Game.Levels
{
    public class Level1 : Level
    {
        public Level1()
        {
            LevelBorder = new Rectangle(-2500, -2500, 5000, 5000);
            var LevelObjectsTypes = new List<Tuple<Type, int>>
            {
                Tuple.Create(typeof(GameObjects.Apple_Stump), 10),
                Tuple.Create(typeof(GameObjects.Sock), 5),
                Tuple.Create(typeof(GameObjects.Can), 20),
                Tuple.Create(typeof(GameObjects.Napkin), 50),
                Tuple.Create(typeof(GameObjects.Potato_Chip), 50),
                Tuple.Create(typeof(GameObjects.Bread_Crumbs), 50),
                Tuple.Create(typeof(GameObjects.Sneaker), 2)
            };
            LevelBackground = GetImageFromName("floor.png");
            LevelObjects = new List<GameObjects.GameObject>();
            MassToPassTheLevel = 6500;
            var random = new Random();
            foreach(var tuple in LevelObjectsTypes)
            {
                for (var i = 0; i < tuple.Item2; i++)
                {
                    var x = random.Next(LevelBorder.X, LevelBorder.X + LevelBorder.Width);
                    var y = random.Next(LevelBorder.Y, LevelBorder.Y + LevelBorder.Height);
                    LevelObjects.Add((GameObjects.GameObject)Activator.CreateInstance(tuple.Item1, new Point(x, y)));
                }
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Hunger_Game.Levels
{
    public class Level
    {
        public Image LevelBackground;
        public List<GameObjects.GameObject> LevelObjects;
        public int MassToPassTheLevel;
        public Rectangle LevelBorder;
        protected Image GetImageFromName(string imageName)
        {
            return Image.FromFile(new DirectoryInfo("Images").GetFiles(imageName)[0].FullName);
        }
    }
}

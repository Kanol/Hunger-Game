using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunger_Game.GameObjects
{
    public class Player : GameObject
    {
        private static Image[] ObjectImages = GetImages();
        private int imageCount = 0;
        public Player(Point center)
        {
            Center = center;
            Mass = 1000;
            SizeCoefficient = 1.0;
            UpdateRectangle();
            RotationDegree = 0;
        }
        public override Image GetImage()
        {
            int speed = 5;
            imageCount++;
            imageCount = imageCount == ObjectImages.Length * speed ? 0 : imageCount;
            return ObjectImages[imageCount / speed];
        }
        private static Image[] GetImages()
        {
            var imageFiles = new DirectoryInfo("Images").GetFiles("Player*.png");
            var ObjectImage = new Image[imageFiles.Length];
            for (var i = 0; i < imageFiles.Length; i++)
                ObjectImage[i] = Image.FromFile(imageFiles[i].FullName);
            return ObjectImage;
        }
        public override void PlaySound()
        {
        }

    }
}

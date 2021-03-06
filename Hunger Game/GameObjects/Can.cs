﻿using System;
using System.Drawing;
using System.IO;
using System.Media;

namespace Hunger_Game.GameObjects
{
    class Can : GameObject
    {
        private static Image ObjectImage = Image.FromFile(new DirectoryInfo("Images").GetFiles("Can.png")[0].FullName);
        private static SoundPlayer[] Sounds;

        public Can(Point center)
        {
            Center = center;
            Mass = 1800;
            SizeCoefficient = 1.0;
            UpdateRectangle();
            RotationDegree = random.Next(-360, 360);
            var files = new DirectoryInfo("Sounds").GetFiles("Can*.wav");
            Sounds = new SoundPlayer[files.Length];
            for (var i = 0; i < files.Length; i++)
                Sounds[i] = new SoundPlayer(files[i].FullName);
        }
        public override Image GetImage() => ObjectImage;
        public override void PlaySound() => Sounds[random.Next(0, Sounds.Length)].Play();
    }
}

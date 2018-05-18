using System;
using NUnit.Framework;
using Hunger_Game;
using System.Drawing;

namespace Hunger_Game
{
    [TestFixture]
    public class ModelTest
    {
        [Test]
        public void TestRectangleInRectangle()
        {
            Assert.True(HungerGameModel.IsRectangleInRectangle(new Rectangle(0, 0, 10, 10), new Rectangle(0, 0, 1, 1)));
        }
        [Test]
        public void TestRectangleNotInRectangle()
        {
            Assert.False(HungerGameModel.IsRectangleInRectangle(new Rectangle(0, 0, 1, 1), new Rectangle(2, 2, 1, 1)));
        }
    }
}

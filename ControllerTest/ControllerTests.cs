using System;
using NUnit.Framework;
using Hunger_Game;
using System.Drawing;

namespace ControllerTest
{
    [TestFixture]
    public class ControllerTests
    {
        [Test]
        public void TestAngle90()
        {
            Assert.AreEqual(Math.PI / 2, MouseController.GetAngle(new Point(0, 0), new Point(0, 1)));
        }
        [Test]
        public void TestAngle45()
        {
            Assert.AreEqual(Math.PI / 4, MouseController.GetAngle(new Point(0, 0), new Point(1, 1)));
        }
        [Test]
        public void TestCoords()
        {
            Assert.AreEqual(new Point(1, 1), MouseController.GetCoords(Math.PI / 4, 1));
        }
        [Test]
        public void TestDistance()
        {
            Assert.AreEqual(2, MouseController.GetDistance(new Point(0, 0), new Point(0, 2)));
        }

    }
}

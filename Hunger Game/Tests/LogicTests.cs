using System;
using System.Linq;
using NUnit.Framework;
using System.Windows.Forms;
using System.Drawing;

namespace Hunger_Game
{
    [TestFixture]
    public class LogicTests
    {
        public MouseController Controller = new MouseController(false);
        public Point ScreenCenter = new Point(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width / 2),
                Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height / 2));
        [Test]
        public void TestPlayerMoves()
        {
            var model = new HungerGameModel(Controller);
            Cursor.Position = new Point(ScreenCenter.X + 16, ScreenCenter.Y + 16);
            Controller.UpdatePositionShift();
            Assert.AreEqual(new Point(8, 8), Controller.PositionShift);
        }
        [Test]
        public void TestPlayerNotMoves()
        {
            var model = new HungerGameModel(Controller);
            Cursor.Position = new Point(ScreenCenter.X + 14, ScreenCenter.Y);
            Controller.UpdatePositionShift();
            Assert.AreEqual(new Point(0, 0), Controller.PositionShift);
        }
        [Test]
        public void TestPlayerEatObject()
        {
            var model = new HungerGameModel(Controller);
            var levelObjectsCount = model.Level.LevelObjects.Count();
            model.Level.LevelObjects.Add(new GameObjects.Apple_Stump(new Point(0, 0)));
            model.UpdateLevel();
            Assert.AreEqual(levelObjectsCount - 1, model.Level.LevelObjects.Count());
        }
    }
}

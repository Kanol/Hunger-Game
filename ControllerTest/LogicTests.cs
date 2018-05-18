using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunger_Game;
using NUnit.Framework;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ControllerTest
{
    [TestFixture]
    class LogicTests
    {
        public MouseController Controller = new MouseController(false);
        public Point ScreenCenter = new Point(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width / 2),
                Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height / 2));
        [Test]
        public void TestPlayerMoves()
        {
            var model = new HungerGameModel(Controller);
            Cursor.Position = new Point(ScreenCenter.X + 2, ScreenCenter.Y + 2);
            Controller.UpdatePositionShift();
            Assert.AreEqual(Controller.PositionShift, new Point(1, 1));
            
        }
    }
}

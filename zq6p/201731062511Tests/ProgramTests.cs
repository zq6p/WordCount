using Microsoft.VisualStudio.TestTools.UnitTesting;
using _201731062511;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _201731062511.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void CountCharTest()
        {
            Assert.AreEqual(Program.CountChar("abcdefghijklmnopqrstuvwxyz"), 26);
        }
    }
}
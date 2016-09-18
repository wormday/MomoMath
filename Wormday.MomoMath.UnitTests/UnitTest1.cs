using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;

namespace Wormday.MomoMath.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Expression<Func<int, int, int, int, int, int>> funcExc3 = (a, b, c, d, e) => (a + b) * (c + d + e);
            var q = funcExc3.Compile();
            int r = q(1, 1, 1, 1, 1);
            Assert.AreEqual(r, 6);
            
        }
    }
}

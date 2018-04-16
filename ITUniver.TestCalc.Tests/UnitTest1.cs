using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITUniver.TeleCalc.ConCalc;

namespace ITUniver.TestCalc.Tests
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestSum()
        {
            //arrange
            var calc = new Calc();
            var x = 1;
            var y = 2;

            //act
            var result1 = calc.Sum(x, y);
            var result2 = calc.Sum(10, 0);

            //assert
            Assert.AreEqual(3, result1);
            Assert.AreEqual(10, result2);
        }
    }
}

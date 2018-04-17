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
            double x1 = 11; double x2 = 33;
            double y1 = 22; double y2 = 0;

            //act
            //сумма
            var result1 = calc.Sum(x1, y1);
            var result2 = calc.Sum(x2, y2);
            //разность
            var result3 = calc.Diff(x1, y1);
            var result4 = calc.Diff(x2, y2);
            //произведение
            var result5 = calc.Mult(x1, y1);
            var result6 = calc.Mult(x2, y2);
            //деление
            var result7 = calc.Div(x1, y1);
            var result8 = calc.Div(x2, y2);
            //xor
            var result9 = calc.XOR(x1, y1);     //42
            var result10 = calc.XOR(x2, y2);    //22

            //assert
            //сумма
            Assert.AreEqual(33, result1);
            Assert.AreEqual(33, result2);
            //разность
            Assert.AreEqual(-11, result3);
            Assert.AreEqual(33, result4);
            //умножение
            Assert.AreEqual(242, result5);
            Assert.AreEqual(0, result6);
            //деление
            Assert.AreEqual(0.5, result7);
            //Assert.AreEqual(error, result8);
			//правильно
			Assert.AreEqual(Double.PositiveInfinity, result8);
            //xor
            Assert.AreEqual(29, result9);
            Assert.AreEqual(33, result10);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITUniver.TeleCalc.ConCalc
{
    public class Calc
    {
        public double Sum(double x, double y)
        {
            return x + y;
        }
        public double Diff(double x, double y)
        {
            return x - y;
        }
        public double Mult(double x, double y)
        {
            return x * y;
        }
        public double Div(double x, double y)
        {
           return x / y;
        }
        public double XOR(double x, double y)
        {
            return (int)x ^ (int)y;
        }
    }
}

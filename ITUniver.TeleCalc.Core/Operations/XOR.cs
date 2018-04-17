using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITUniver.TeleCalc.Core.Operations
{
    public class XOR : IOperation
    {
        //public string Name { get { return "sum"; } }
        public string Name => "xor";
        public double[] Args
        {
            set
            {
                var sum = value.ElementAt(0);
                sum = value.Select((x, i) => (int)sum ^ (int)value[i]).Last();
                Result = sum;
            }
            get { return new double[0]; }
        }
        public double? Result { get; private set; }
        public string Error { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITUniver.TeleCalc.Core.Operations
{
    public class Mult : IOperation
    {
        public string Name => "mult";
        public double[] Args
        {
            set
            {
                var sum = value.ElementAt(0);
                sum = value.Select((x, i) => sum * value[i]).Last();
                Result = sum;
            }
            get { return new double[0]; }
        }
        public double? Result { get; private set; }
        public string Error { get; }
    }
}

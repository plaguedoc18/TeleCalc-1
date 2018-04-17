using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITUniver.TeleCalc.Core.Operations
{
    public class Sub : IOperation
    {
        //public string Name { get { return "sum"; } }
        public string Name => "sub";
        public double[] Args
        {
            set
            {
                /*var sum = (double)value[0];
                for (int i = 1; i < value.Length; i++) sum = sum - value[i];
                Result = sum;*/
                //int i = 0;
                var sum = value.ElementAt(0);
                sum = value.Select((x,i) => sum - value[i] ).Last();
                Result = sum;

            }
            get { return new double[0]; }
        }
        public double? Result { get; private set; }
        public string Error { get; }
    }
}

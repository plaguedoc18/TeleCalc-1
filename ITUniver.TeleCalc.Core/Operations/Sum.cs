using System.Linq;

namespace ITUniver.TeleCalc.Core.Operations
{
    public class Sum : IOperation
    {
        //public string Name { get { return "sum"; } }
        public string Name => "sum";
        public double[] Args
        {
            set
            {
                /*var sum = (double)value[0];
                for (int i = 1; i < value.Length; i++) sum = sum + value[i];
                Result = sum;*/
                var sum = value.ElementAt(0);
                sum = value.Select((x, i) => sum + value[i]).Last();
                Result = sum;
            }
            get { return new double[0]; }
        }
        public double? Result { get; private set; }
        public string Error { get; }
    }
}

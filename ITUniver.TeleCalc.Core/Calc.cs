using ITUniver.TeleCalc.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ITUniver.TeleCalc.Core
{
    public class Calc
    {
        private IOperation[] operations { get; set; }
        private string[] opernames { get; set; }
        public string[] GetOpers { get { return opernames; } }
        public Calc()
        {
            var opers = new List<IOperation>();
            var opernamesint = new List<string>();
            //получить текущую сборку
            var assembly = Assembly.GetExecutingAssembly();
            //получить типы в ней
            var classes = assembly.GetTypes();
            foreach (var item in classes)
            {
                //получаем интерфейсы, которые реализует класс
                var interfaces = item.GetInterfaces();
                var isOperation = interfaces.Any(i => i == typeof(IOperation));
                if (isOperation)
                {
                    var obj = System.Activator.CreateInstance(item) as IOperation;
                    if (obj != null) opers.Add(obj);
                    opernamesint.Add(item.Name);
                }
            }
            operations = opers.ToArray();
            opernames = opernamesint.ToArray();
        }
        
        public double Exec(string operName,double? x, double? y)
        {
            IOperation operation = null;
            operation = operations
                .FirstOrDefault(o => o.Name == operName);
            if (operation == null)
                return double.NaN;
            operation.Args = new double[] { (double)x, (double)y };
            return (double)operation.Result;
        }
    #region old
        public double Sqr(double x)
        {
            return Math.Pow(x, 2);
        }
        //правильно оставить с интом
        public int Sum(int x, int y)
        {
            return x+y;
        }
        public double Sum(double x, double y)
        {
            var sum = new Sum();
            sum.Args = new double[] { x, y };
            return (double)sum.Result;
        }
        public double Sub(double x, double y)
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
        #endregion
    }
}

using ITUniver.TeleCalc.Core.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ITUniver.TeleCalc.Core
{
    public class Calc
    {
        private IOperation[] operations { get; set; }
        private string[] opernames { get; set; }
        public IEnumerable<string> GetOpers()
        {
            return operations.Select(o => o.Name);
        }
        /*public Calc()
        {
            var opers = new List<IOperation>();
            //получить сборки из папки
            const String _path = @"Z:\ITUniver\dlls\";
            string[] files = Directory.GetFiles(_path);
            Assembly assembly;
            Type[] classes;
            Type[] interfaces;
            bool isOperation;
            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    assembly = Assembly.LoadFrom(file);
                    //получить типы в ней
                    classes = assembly.GetTypes();
                    foreach (var item in classes)
                    {
                        //получаем интерфейсы, которые реализует класс
                        interfaces = item.GetInterfaces();
                        isOperation = interfaces.Any(i => i == typeof(IOperation));

                        if (isOperation)
                        {
                            var obj = System.Activator.CreateInstance(item) as IOperation;
                            if (obj != null)
                            {
                                opers.Add(obj);
                            }
                        }
                    }
                }
            }
            operations = opers.ToArray();
        }*/
        public Calc()
        {
            var opers = new List<IOperation>();
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
                    if (obj != null)
                    {
                        opers.Add(obj);
                    }
                }
            }
            operations = opers.ToArray();
        }

        [Obsolete("Используйте метод Exec(operNames, args)")]
        public double Exec(string operName, double x, double y)
        {
            return Exec(operName, new double[] { x, y });
        }

        public double Exec(string operName, IEnumerable<double> Args)
        {
            IOperation operation = operations
                .FirstOrDefault(o => o.Name == operName);
            if (operation == null)
            {
                return double.NaN;
            }
            operation.Args = Args.ToArray();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITUniver.TeleCalc.ConCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0) Console.WriteLine("Аргументов нет");
                else if (args.Length < 3) Console.WriteLine("Мало аргументов.");
                else
                {
                    double x = Convert.ToDouble(args[1]);
                    double y = Convert.ToDouble(args[2]);
                    args[0] = args[0].ToLower();
                    Calc action = new Calc();
                    switch (args[0])
                    {
                        case "sum":
                            Console.WriteLine($"{action.Sum(x,y)}");
                            break;
                        case "diff":
                            Console.WriteLine($"{action.Diff(x, y)}");
                            break;
                        case "mult":
                            Console.WriteLine($"{action.Mult(x, y)}");
                            break;
                        case "div":
                            {
                                if (y != 0) Console.WriteLine($"{action.Div(x, y)}");
                                else Console.WriteLine("На 0 делить нельзя");
                                break;
                            }
                        case "xor":
                            Console.WriteLine($"{action.XOR(x, y)}");
                            break;
                        default:
                            Console.WriteLine("Неверная команда!");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Что-то пошло не так!\n" + ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key for continue...");
                Console.ReadKey();
            }
        }
    }
}

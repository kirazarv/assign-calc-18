using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab18
{
    public class Calc
    {
        public static double a, b, c, x;
        //public static double[] numsNums = {0, 0, 0, 0};
        public static string[] strNums = { "a", "b", "c","x" };
        public static string reply;

        public static void Main(string[] args)
        {
            // Запрос у пользователя чисел a, b, c,x
            var numsNums = GetUserInput();

            // Вычисление и вывод на экран значения функции F
            try
            {
                double result = Calculate(numsNums[0], numsNums[1], numsNums[2], numsNums[3]);
                Console.WriteLine($"Результат функции F: {result}");
                Console.ReadKey();
            }
            catch (DivideByZeroException ex)
            {
                // Обработка исключения деления на ноль
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                Console.ReadKey();
            }
        }

        public static double[] GetUserInput()
        {
            double[] numsNums = new double[4];
            string[] strNums = { "a", "b", "c", "x" };

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Введите число {strNums[i]} ");

                double num;
                if (double.TryParse(Console.ReadLine(), out num))
                {
                    numsNums[i] = num;
                    continue;
                }
                else
                {
                    reply = Console.ReadLine();
                    Console.WriteLine($"Некорректный ввод данных. Число не может содержать точки, пробелы, буквы " +
                                      $"и символы кроме минуса. Вы ввели:{reply}");
                    Console.ReadKey();

                    break;
                }
            }

            return numsNums;
        }

        public static double Calculate(double a, double b, double c, double x)
        {
            if (x < 1 && c != 0)
            {
                return a * Math.Pow(x, 2) + b / c;
            }
            else if (x > 1.5 && c == 0)
            {
                return (x - a) / Math.Pow(x - c, 2);
            }
            else if (c == 0) // Проверка на деление на ноль
            {

                throw new DivideByZeroException("Деление на ноль невозможно");

            }
            else
            {
                return Math.Pow(x, 2) / Math.Pow(c, 2);
            }
        }
    }
}

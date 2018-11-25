using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_2.Extend
{
    class CheckAndInput
    {
        // метод для проверки желания повтора ввода данных
        public static bool CheckExit(string str = "повторить ввод данных")
        {
            Console.Write("\nЖелаете " + str + "?\n1 - да\n0 - нет\nВаш выбор: ");
            string answer = Console.ReadLine();
            if (answer == "1")
                return true;
            else
                return false;
        }
        // метод для ввода целочисленных данных
        public static bool InputData(ref int x, string query, int lessThen = int.MinValue, int moreThen = int.MaxValue)
        {
            bool repeated = true;
            bool result = false;
            while (repeated)
            {
                repeated = false;
                //Console.Clear();
                if (query != "")
                    Console.Write(query);
                try
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    if (x < lessThen)
                        throw new Exception("Значение не может быть меньше " + lessThen + "!");
                    if (x > moreThen)
                        throw new Exception("Значение не может быть больше " + moreThen + "!");
                    result = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы ввели не целое число!");
                    repeated = CheckExit();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Вы ввели слишком малое или слишком большое число!");
                    repeated = CheckExit();
                }
                catch (Exception ex) when (ex.Message == "Значение не может быть меньше " + lessThen + "!" ||
                ex.Message == "Значение не может быть больше " + moreThen + "!")
                {
                    Console.WriteLine(ex.Message);
                    repeated = CheckExit();
                }
            }
            return result;
        }
    }
}

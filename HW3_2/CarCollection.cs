using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_2
{
    class CarCollection
    {
        public static void SelectColor(int x)
        {
            switch (x)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 11:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 12:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 13:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    break;
            }
        }
        public static void Show(Car car)
        {
            if (car.Status)         // если исправна
            {
                SelectColor(car.Color);
                Console.SetCursorPosition(car.X, car.Y);
                Console.WriteLine("╔╩═══╩╗");
                Console.SetCursorPosition(car.X, car.Y + 1);
                Console.WriteLine("║  " + car.Number + "  ╠═");
                Console.SetCursorPosition(car.X, car.Y + 2);
                Console.WriteLine("╚╦═══╦╝");
                Console.ResetColor();
            }
            else                // если неисправна
            {
                SelectColor(car.Color);
                Console.SetCursorPosition(car.X, car.Y);
                Console.WriteLine("╔╩═══╩╗");
                Console.SetCursorPosition(car.X, car.Y + 1);
                Console.WriteLine("║░░" + car.Number + "░░╠═");
                Console.SetCursorPosition(car.X, car.Y + 2);
                Console.WriteLine("╚╦═══╦╝");
                Console.ResetColor();
                //throw new Exception("Поломка машины №" + car.Number + "!");
            }
        }
    }
}

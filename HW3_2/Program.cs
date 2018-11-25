//                                                  Задание 2.
//      Написать приложение «Автомобильные гонки». В гонке участвует от 2 до 7 автомобилей 
//  (количество задается пользователем перед началом каждой гонки). 
//      Автомобили двигаются по экрану консоли от левого края к правому с переменной скоростью.
//      Победителем гонки считается автомобиль, который первым достиг правого края консоли.
//      Автомобили отображать в консоли с помощью символов псевдографики. 
//      Для решения задачи необходимо реализовать класс «Автомобиль», который имеет цвет 
//  (красный, синий и т.д. – назначается автомобилю случайным образом в конструкторе), номер(1, 2, и т.д. – задается программой). 
//      Предусмотреть возможность поломки автомобиля во время гонок – вероятность поломки – 5%. 
//      В случае поломки объект «Автомобиль» генерирует исключительную ситуацию, 
//  которая должна быть обработана в программе – поломанный автомобиль перестает двигаться, 
//  но остается на экране(отображается на экране как поломанный), и выбывает из гонок.
//      Пользователь перед началом гонок может сделать ставку на один из автомобилей. 
//      В случае, если побеждает автомобиль пользователя – программа сообщает «Вы выиграли», иначе – «Вы проиграли». 
//      Программа должна иметь меню, предлагающее пользователю сделать ставку и начать новую гонку или выйти из программы.

//                                                  Замечания:
//  1.	Для задания цвета фона используйте свойство BackgroundColor, цвета текста – ForegroundColor.
//                                                  Например:
//  Console.BackgroundColor = ConsoleColor.Blue;
//  Console.ForegroundColor = ConsoleColor.Red;
//  2.	Для задания позиции курсора на экране используйте метод SetCursorPosition.
//                                                  Например:
//  Console.SetCursorPosition(30, 23);
//  3.	Для для определения какая управляющая или символьная клавиша была нажата создайте объект структуры ConsoleKeyInfo, используйте метод ReadKey.
//                                                  Например:
//  ConsoleKeyInfo cki;
//  cki = Console.ReadKey();
//  if (cki.KeyChar == 'y' || cki.KeyChar == 'Y')
//  {
//  	. . . . .
//  }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW3_2.Extend;

namespace HW3_2
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                int balance = 1000;     // баланс игрока
                int bet = 0;            // размер ставки игрока
                int betNumberCar = 0;   // номер машины на которую поставил игрок
                while (balance>0)
                {
                    Console.Clear();
                    int countCar = 0;
                    if (!CheckAndInput.InputData(ref countCar, "Введите количество автомобилей: ", 2, 7))
                        throw new Exception("Ошибка! Неправильный ввод количества автомобилей!");
                    if (countCar > 5)
                        Console.SetWindowSize(120, 35);
                    else
                        Console.SetWindowSize(120, 30);
                    Car[] car = new Car[countCar];
                    Random random = new Random();
                    // инициализируем машины со случайным неодинаковым цветом
                    for (int i = 0, rand = 0; i < countCar; i++)
                    {
                        if (i != 0)
                        {
                            rand = random.Next(1, 13);
                            for (int j = i - 1; j >= 0; j--)
                            {
                                if (rand == car[j].Color)
                                {
                                    rand = random.Next(1, 13);
                                    j = i;
                                }
                            }
                            car[i] = new Car(i + 1, rand);
                        }
                        else
                            car[i] = new Car(i + 1, random.Next(1, 13));
                    }
                    bool releaseBet = false;   // флаг сделаны ли ставки
                    bool releaseGame = false;  // флаг сыграна ли игра
                    int winCarNumber = 0;      // номер победившей машины
                    while (!releaseBet || !releaseGame)
                    {
                        Console.Clear();
                        Console.WriteLine("Баланс игрока: " + balance + "\t\tКоличество автомобилей участвующих в гонке: " + countCar);
                        Console.WriteLine("\n1 - сделать ставку");
                        Console.WriteLine("2 - начать новую гонку");
                        Console.WriteLine("0 - выход");
                        Console.Write("Ваш выбор: ");
                        int menu = 0;
                        if (!CheckAndInput.InputData(ref menu, "", 0, 2))
                            throw new Exception("Ошибка! Неправильный ввод номера пункта меню!");
                        switch (menu)
                        {
                            case 1: // 1 - сделать ставку
                                if (!releaseBet)
                                {
                                    Console.Clear();
                                    if (!CheckAndInput.InputData(ref bet, "Введите размер ставки: ", 1, balance))
                                        throw new Exception("Ошибка! Неправильный ввод ставки!");
                                    if (!CheckAndInput.InputData(ref betNumberCar, "Введите номер машины: ", 1, countCar))
                                        throw new Exception("Ошибка! Неправильный ввод номера машины!");
                                    releaseBet = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nСтавки уже сделаны.");
                                    Console.ReadKey();
                                }
                                break;
                            case 2: // 2 - начать новую гонку
                                // показываем машины
                                if (releaseBet)
                                {
                                    Console.Clear();
                                    Random randomX = new Random();
                                    int xMax = 0;
                                    int loose = 0;
                                    int finish = Console.WindowWidth - 7;
                                    for (int i = 0; i < countCar; i++)
                                    {
                                        car[i].Y = 3 + i * 4;
                                    }
                                    try
                                    {
                                        while (xMax + 7 < finish)
                                        {
                                            for (int j = 0; j < countCar; j++)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Ставка игрока: " + bet + "\t\tAвтомобилей в гонке: " + (countCar - loose));
                                                Console.WriteLine("Номер машины игрока: " + betNumberCar);
                                                Console.WriteLine();
                                                for (int i = 0; i < countCar; i++)
                                                {
                                                    CarCollection.Show(car[i]);
                                                }
                                                if (car[j].Status)
                                                {
                                                    int move = randomX.Next(0, 2);
                                                    car[j].X += move;
                                                    car[j].GenerationBreak(finish, move);
                                                    if (!car[j].Status)
                                                        loose++;
                                                    Console.WriteLine();
                                                    if (xMax < car[j].X + 7)
                                                    {
                                                        xMax = car[j].X;
                                                        if (xMax >= finish)
                                                        {
                                                            winCarNumber = j + 1;
                                                            break;
                                                        }
                                                    }
                                                }
                                                System.Threading.Thread.Sleep(35);
                                                if (j == countCar - 1 && loose == countCar)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Ставка игрока: " + bet + "\t\tAвтомобилей в гонке: " + (countCar - loose));
                                                    Console.WriteLine("Номер машины игрока: " + betNumberCar);
                                                    Console.WriteLine();
                                                    for (int i = 0; i < countCar; i++)
                                                    {
                                                        CarCollection.Show(car[i]);
                                                    }
                                                    throw new Exception("Все машины сломались!");
                                                }
                                                if (j == countCar - 1)
                                                    j = -1;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    releaseGame = true;
                                    if (winCarNumber != 0)
                                        Console.WriteLine("Победила машина №" + winCarNumber);
                                    if (winCarNumber == betNumberCar)
                                    {
                                        Console.WriteLine("Вы выиграли");
                                        balance += bet;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Вы проиграли");
                                        balance -= bet;
                                    }
                                }
                                else
                                    Console.WriteLine("\nПожалуйста сделайте вашу ставку");
                                Console.ReadKey();
                                break;
                            case 0:
                                return 0;
                        }
                    }
                }
                if (balance <= 0)
                    throw new Exception("Вы проиграли все деньги!");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Выход из программы");
                Console.ReadKey();
                return 0;
            }
        }
    }
}

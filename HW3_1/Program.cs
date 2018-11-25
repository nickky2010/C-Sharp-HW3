//                                              Задание 1.
//  Написать приложение, выполняющее следующие функции:
//      Ввод с клавиатуры данных о студентах в массив объектов класса Student.
//      Вывод списка всех студентов с указанием среднего балла каждого студента в порядке возрастания среднего балла.
//      Определение количества студентов, получивших больше двух оценок 10 в массиве.
//      Вывод списка двоечников в заданной группе (если таких студентов нет, вывести соответствующее сообщение).
 
//  Класс Student должен содержать закрытые поля: фамилия, номер группы, успеваемость (массив оценок) и все необходимые для решения задачи свойства и методы.
//  Можно также создать класс – контейнер для студентов(по желанию).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW3_1.Extend;

namespace HW3_1
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                int countStudent = 0;
                if (!CheckAndInput.InputData(ref countStudent, "Введите количество студентов: ", 1))
                    throw new Exception("Ошибка! Неправильный ввод количества студентов!");
                Student[] student = new Student[countStudent];
                for (int i = 0; i < countStudent; i++)
                {
                    Console.Clear();
                    Console.WriteLine("Ввод данных о " + (i + 1) + " студенте:");
                    Console.Write("\nВведите фамилию: ");
                    string tmpLastName = Console.ReadLine();
                    Console.Write("Введите номер группы: ");
                    string tmpGroupNumber = Console.ReadLine();
                    int countGrade = 0;
                    if (!CheckAndInput.InputData(ref countGrade, "Введите количество оценок: ", 1))
                        throw new Exception("Ошибка! Неправильный ввод количества оценок!");
                    student[i] = new Student(countGrade)
                    {
                        LastName = tmpLastName,
                        GroupNumber = tmpGroupNumber
                    };
                    Console.WriteLine("Введите оценки: ");
                    for (int j = 0; j < countGrade; j++)
                    {
                        if (!CheckAndInput.InputData(ref student[i].Grade[j], "Оценка " + (j + 1) + ": ", 1, 10))
                            throw new Exception("Ошибка! Неправильный ввод " + (j + 1) + " оценки " + (i + 1) + " студента!");
                    }
                }
                StudentCollection studentCollection = new StudentCollection("", student);
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("1 - Вывод списка всех студентов с указанием среднего балла каждого студента в порядке возрастания среднего балла");
                    Console.WriteLine("2 - Определение количества студентов, получивших больше двух оценок 10 в массиве");
                    Console.WriteLine("3 - Вывод списка двоечников");
                    Console.WriteLine("0 - выход");
                    Console.Write("Ваш выбор: ");
                    int menu = 0;
                    if (!CheckAndInput.InputData(ref menu, "", 0, 3))
                        throw new Exception("Ошибка! Неправильный ввод номера пункта меню!");
                    switch (menu)
                    {
                        case 1: // 1 - Вывод списка всех студентов с указанием среднего балла каждого студента в порядке возрастания среднего балла
                            Console.Clear();
                            studentCollection.ShowByGrowingAverageGrade();
                            Console.ReadKey();
                            break;
                        case 2: // 2 - Определение количества студентов, получивших больше двух оценок 10 в массиве
                            Console.Clear();
                            Console.WriteLine("Количество студентов, получивших больше двух оценок 10 = "+ studentCollection.CountGetGrade());
                            Console.ReadKey();
                            break;
                        case 3: // 3 - Вывод списка двоечников
                            Console.Clear();
                            studentCollection.ShowStudentsByAcademicAchievement();
                            Console.ReadKey();
                            break;
                        case 0:
                            return 0;
                    }
                }
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

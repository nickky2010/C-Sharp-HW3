//  Для решения задачи необходимо реализовать класс «Автомобиль», который имеет цвет 
//  (красный, синий и т.д. – назначается автомобилю случайным образом в конструкторе), номер(1, 2, и т.д. – задается программой). 
//      Предусмотреть возможность поломки автомобиля во время гонок – вероятность поломки – 5%. 
//      В случае поломки объект «Автомобиль» генерирует исключительную ситуацию, 
//  которая должна быть обработана в программе – поломанный автомобиль перестает двигаться, 
//  но остается на экране(отображается на экране как поломанный), и выбывает из гонок.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_2
{
    class Car
    {
        public int Number { get; set; }         // номер машины
        public bool Status { get; set; }        // состояние машины (работает = true, не работает = false)
        public int Color { get; set; }          // цвет машины
        public int X { get; set; }              // координата по x
        public int Y { get; set; }              // координата по Y
        public Car (int number, int color)
        {
            Number = number;
            Status = true;
            Color = color;
            X = 0;
            Y = 0;
        }
        public void GenerationBreak(int way, int move)
        {
            if (move != 0)
            {
                int countValue = 20*way;         // количество возможных значений * на длину пути
                int countChance = 1;             // количество возможных значений неудачи
                Random randomNumber = new Random();
                int[] numberBreak = new int[countChance];
                for (int i = 0, r = 0; i < countChance; i++)
                {
                    if (i != 0)
                    {
                        r = randomNumber.Next(1, countValue);
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (r == numberBreak[j])
                            {
                                r = randomNumber.Next(1, countValue);
                                j = i;
                            }
                        }
                        numberBreak[i] = r;
                    }
                    else
                        numberBreak[i] = randomNumber.Next(1, countValue);
                }
                int rand = randomNumber.Next(1, countValue);
                for (int i = 0; i < countChance; i++)
                {
                    if (numberBreak[i] == rand)
                    {
                        Status = false;
                    }
                }
            }
        }
    }
}

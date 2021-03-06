﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    //  Создать класс «Таблица», описывающий объекты-таблицы из двух столбцов, содержащий следующие элементы:
    class Table
    {
        //  Создаем класс «Столбец», описывающий объекты-столбцы
        public class Column
        {
            public string HeadCol { get; set; }  // заголовок столбца
            public int LenghtCol { get; set; }   // ширина столбца
                                                 //  Конструктор с параметрами
            public Column(string headCol = "", int lenghtCol = 1)
            {
                HeadCol = headCol;
                if (lenghtCol>1)
                    LenghtCol = lenghtCol;
                else if (headCol.Length >= lenghtCol) // если количество букв больше ширины колонки, и ширина колонки не задавалась
                    LenghtCol = headCol.Length;                   // то ширина колонки = кол-ву букв
                else 
                    LenghtCol = lenghtCol;
            }
        }
        //  Закрытые поля: заголовок таблицы, заголовки столбцов, ширина первого столбца, ширина второго столбца.
        public string HeadTable { get; set; }       // заголовок таблицы
        public int TotalLenghtCol { get; set; }     // общая длина колонок
        public int CountCol { get; set; }           // количество колонок
        public int LenghtTable { get; set; }        // длина таблицы (без учета 2 боковых линий=+2)
        public Column[] column;
        //  Конструктор с параметрами.
        public Table(string headTable = "", params Column[] column)
        {
            HeadTable = headTable;
            // считаем данные по колонкам
            CountCol = column.Count();
            this.column = new Column[CountCol];
            for (int i = 0; i < CountCol; i++)
            {
                this.column[i] = new Column();
                this.column[i] = column[i];
                TotalLenghtCol += this.column[i].LenghtCol;
            }
            LenghtTable = TotalLenghtCol + CountCol - 1;
        }
        //  Метод для вывода шапки таблицы.
        public void PrintHead(bool printHeadTable = true)
        {
            // первая строчка
            if (printHeadTable)
            {
                Console.Write("╔");
                for (int i = 0; i < LenghtTable; i++)
                    Console.Write("═");
                Console.WriteLine("╗");
                // вторая строчка - заголовок таблицы
                ShowCol(LenghtTable - ShowColLeft(LenghtTable, HeadTable) - HeadTable.Length, HeadTable, LenghtTable);
                Console.WriteLine("║");
                // третья строчка
                Console.Write("╠");
            }
            else
                Console.Write("╔");
            for (int i = 0; i < CountCol; i++)
            {
                for (int m = 0; m < column[i].LenghtCol; m++)
                    Console.Write("═");
                if (i!= CountCol-1)
                    Console.Write("╦");
            }
            if (printHeadTable)
                Console.WriteLine("╣");
            else
                Console.WriteLine("╗");
            // четвертая строчка заголовки столбцов
            for (int i = 0; i < CountCol; i++)
            {
                ShowCol(column[i].LenghtCol - ShowColLeft(column[i].LenghtCol, column[i].HeadCol) - column[i].HeadCol.Length, column[i].HeadCol, column[i].LenghtCol);
            }
            Console.WriteLine("║");
            // пятая строчка
            Console.Write("╠");
            for (int i = 0; i < CountCol; i++)
            {
                for (int m = 0; m < column[i].LenghtCol; m++)
                    Console.Write("═");
                if (i != CountCol - 1)
                    Console.Write("╬");
                else
                    Console.WriteLine("╣");
            }
        }

        //  Метод для вывода строки таблицы (возможные входные параметры: string, int, double, decimal).
        /// <summary>
        /// Метод для вывода строки таблицы (возможные входные параметры: string, int, double, decimal).
        /// </summary>
        /// <param name="value"></param>
        public void PrintString(params string [] value)
        {
            int countValue = value.Count();
            for (int i = 0; i < CountCol; i++)
            {
                // если количество колонок меньше или равно количеству переданных значений то записываем все значения (остальные будут отброшены)
                if(i< countValue)
                    ShowCol(column[i].LenghtCol - ShowColLeft(column[i].LenghtCol, value[i]) - value[i].Length, value[i], column[i].LenghtCol);
                // если количество переданных значений меньше количества колонок, то колонки пустые
                else
                    ShowCol(column[i].LenghtCol - ShowColLeft(column[i].LenghtCol, "") - 0, "", column[i].LenghtCol);
            }
            Console.WriteLine("║");
        }

        public void PrintString(params int[] value)
        {
            int countValue = value.Count();
            for (int i = 0; i < CountCol; i++)
            {
                if (i < countValue)
                    ShowCol(column[i].LenghtCol - ShowColLeft(column[i].LenghtCol, value[i].ToString()) - value[i].ToString().Length, value[i].ToString(), column[i].LenghtCol);
                else
                    ShowCol(column[i].LenghtCol - ShowColLeft(column[i].LenghtCol, "") - 0, "", column[i].LenghtCol);
            }
            Console.WriteLine("║");
        }

        //  Переопределенный метод для вывода строки таблицы (входные параметры – double).
        public void PrintString(params double[] value)
        {
            int countValue = value.Count();
            for (int i = 0; i < CountCol; i++)
            {
                if (i < countValue)
                    ShowCol(column[i].LenghtCol - ShowColLeft(column[i].LenghtCol, value[i].ToString()) - value[i].ToString().Length, value[i].ToString(), column[i].LenghtCol);
                else
                    ShowCol(column[i].LenghtCol - ShowColLeft(column[i].LenghtCol, "") - 0, "", column[i].LenghtCol);
            }
            Console.WriteLine("║");
        }

        //  Переопределенный метод для вывода строки таблицы (входные параметры – decimal).
        public void PrintString(params decimal[] value)
        {
            int countValue = value.Count();
            for (int i = 0; i < CountCol; i++)
            {
                if (i < countValue)
                    ShowCol(column[i].LenghtCol - ShowColLeft(column[i].LenghtCol, value[i].ToString()) - value[i].ToString().Length, value[i].ToString(), column[i].LenghtCol);
                else
                    ShowCol(column[i].LenghtCol - ShowColLeft(column[i].LenghtCol, "") - 0, "", column[i].LenghtCol);
            }
            Console.WriteLine("║");
        }

        //  Метод для вывода низа таблицы.
        public void PrintBottom()
        {
            Console.Write("╚");
            for (int i = 0; i < CountCol; i++)
            {
                for (int m = 0; m < column[i].LenghtCol; m++)
                    Console.Write("═");
                if (i != CountCol - 1)
                    Console.Write("╩");
            }
            Console.WriteLine("╝");
        }

        // находим количество пробелов слева, печатаем их и возвращаем их количество
        static int ShowColLeft(int COL, string str)
        {
            int spLeft = (COL - str.Length) / 2;
            Console.Write("║");
            for (int i = 0; i < spLeft; i++)
                Console.Write(" ");
            return spLeft;
        }

        // печатаем значение и пробелы справа
        static void ShowCol(int spRight, string str, int COL)
        {
            if (str.Length > COL)
                Console.Write(str.Substring(0, COL));
            else
                Console.Write(str);
            for (int i = 0; i < spRight; i++)
                Console.Write(" ");
        }
    }
}

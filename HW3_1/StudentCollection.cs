using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW3_1.Extend;

namespace HW3_1
{
    class StudentCollection
    {
        Student[] students;
        public string Institution { get; set; }     // учебное заведение
        // конструктор для коллекции студентов
        public StudentCollection (string institution = "IT Step", params Student[]students)
        {
            this.students = students;
            Institution = institution;
        }
        // количество студентов
        public int Count => students.Length;
        // индексатор 
        public Student this[int i] { get => students[i]; set => students[i] = value; }
        // методы для добавления студентов
        public void Add (Student student)               // добавление 1 студента
        {
            Array.Resize(ref students, students.Length + 1);
            students[Count - 1] = student;
        }   
        public void Add(Student[] student)              // добавление в массив студентов нового массива (слияние 2-х массивов)
        {
            int oldLenght = students.Length;
            Array.Resize(ref students, students.Length + student.Length);
            for (int i = oldLenght - 1, j = 0; i < students.Length; i++, j++)
            {
                students[i] = student[j];
            }
        }
        void LenghtCol(ref int col1, ref int col2, ref int col3)
        {
            // определяем размер 1 колонки (для красоты :) )
            int n = students.Length;
            col1 = 0;
            while (n != 0)
            {
                n /= 10;
                col1++;
            }
            // определяем размер 2 колонки
            col2 = 0;
            for (int i = 0, tmp = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    tmp = students[i].LastName.Length;
                    if (col2 < tmp)
                        col2 = tmp;
                }
            }
            // определяем размер 3 колонки
            col3 = 0;
            for (int i = 0, tmp = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    tmp = students[i].GroupNumber.Length;
                    if (col3 < tmp)
                        col3 = tmp;
                }
            }
        }

        // Вывод списка всех студентов с указанием среднего балла каждого студента в порядке возрастания среднего балла.
        public void ShowByGrowingAverageGrade(string head = "Список студентов в порядке возрастания среднего балла")
        {
            Array.Sort(students, CompareByAverageGrade);
            int col1=0;
            int col2=0;
            int col3=0;
            int col4 = "Средний балл".Length;
            LenghtCol(ref col1, ref col2, ref col3);
            if (head.Length > col1 + col2 + col3 + col4)
                col4 = head.Length - col1 - col2 - col3 - col4;
            Table table = new Table(head, new Table.Column("№", col1), new Table.Column("Фамилия", col2), 
                new Table.Column("Номер группы", col3), new Table.Column("Средний балл", col4));
            table.PrintHead();
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    table.PrintString((i + 1).ToString(), students[i].LastName, students[i].GroupNumber, students[i].Grade.Average().ToString());
                }
            }
            table.PrintBottom();
        }

        // Средний балл всех студентов коллекции
        public double AverageGrade()
        {
            double sum = 0;
            int n = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    sum += students[i].Grade.Average();
                    n++;
                }
            }
            return (sum / n);
        }

        // Определение количества студентов, получивших больше двух оценок 10 в массиве.
        public int CountGetGrade(string operand = ">", int countGrade = 2, int grade = 10)
        {
            int countGetGrade = 0;
            for (int i = 0, j = 0; i < students.Length; i++)
            {
                j = 0;
                if (students[i] != null)
                {
                    for (int k = 0; k < students[i].Grade.Length; k++)
                    {
                        if (students[i].Grade[k] == grade)
                            j++;
                    }
                    if (operand == ">" && j > countGrade)
                        countGetGrade++;
                    else if (operand == "<" && j < countGrade)
                        countGetGrade++;
                    else if (operand == "=" && j == countGrade)
                        countGetGrade++;
                    else if (operand == "<=" && j <= countGrade)
                        countGetGrade++;
                    else if (operand == ">=" && j >= countGrade)
                        countGetGrade++;
                }
            }
            return (countGetGrade);
        }

        // Вывод списка двоечников в заданной группе (если таких студентов нет, вывести соответствующее сообщение).
        public void ShowStudentsByAcademicAchievement(string operand = "<", double grade = 4.0)
        {
            int col1 = 0;
            int col2 = 0;
            int col3 = 0;
            int col4 = "Средний балл".Length;
            LenghtCol(ref col1, ref col2, ref col3);
            string achiev = "";
            if (operand == ">")
                achiev = " более ";
            else if (operand == "<")
                achiev = " менее ";
            else if (operand == "=")
                achiev = " равным ";
            else if (operand == "<=")
                achiev = " менее или равным ";
            else if (operand == ">=")
                achiev = " более или равным ";
            // поиск хотя бы одного с заданными параметрами 
            bool successSearch = false;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    double GradeAver = students[i].Grade.Average();
                    if (operand == ">" && GradeAver > grade - 1e-5)
                    {
                        successSearch = true;
                        break;
                    }
                    else if (operand == "<" && GradeAver < grade + 1e-5)
                    {
                        successSearch = true;
                        break;
                    }
                    else if (operand == "=" && GradeAver == grade - 1e-5)
                    {
                        successSearch = true;
                        break;
                    }
                    else if (operand == "<=" && GradeAver <= grade + 1e-5)
                    {
                        successSearch = true;
                        break;
                    }
                    else if (operand == ">=" && GradeAver >= grade - 1e-5)
                    {
                        successSearch = true;
                        break;
                    }
                }
            }
            if (successSearch)
            {
                string head = "Список студентов со средним баллом" + achiev + grade.ToString();
                if (head.Length > col1 + col2 + col3 + col4)
                    col4 = head.Length - col1 - col2 - col3 - col4;
                Table table = new Table(head, new Table.Column("№", col1), new Table.Column("Фамилия", col2),
                    new Table.Column("Номер группы", col3), new Table.Column("Средний балл", col4));
                table.PrintHead();
                for (int i = 0; i < students.Length; i++)
                {
                    if (students[i] != null)
                    {
                        double GradeAver = students[i].Grade.Average();
                        if (operand == ">" && GradeAver > grade - 1e-5)
                            table.PrintString((i + 1).ToString(), students[i].LastName, students[i].GroupNumber, GradeAver.ToString());
                        else if (operand == "<" && GradeAver < grade + 1e-5)
                            table.PrintString((i + 1).ToString(), students[i].LastName, students[i].GroupNumber, GradeAver.ToString());
                        else if (operand == "=" && GradeAver == grade - 1e-5)
                            table.PrintString((i + 1).ToString(), students[i].LastName, students[i].GroupNumber, GradeAver.ToString());
                        else if (operand == "<=" && GradeAver <= grade + 1e-5)
                            table.PrintString((i + 1).ToString(), students[i].LastName, students[i].GroupNumber, GradeAver.ToString());
                        else if (operand == ">=" && GradeAver >= grade - 1e-5)
                            table.PrintString((i + 1).ToString(), students[i].LastName, students[i].GroupNumber, GradeAver.ToString());
                    }
                }
                table.PrintBottom();
            }
            else
                Console.WriteLine("Студентов со средним баллом" + achiev + grade.ToString()+" не найдено!");
        }

        // сравнение студентов по среднему баллу
        static int CompareByAverageGrade(Student student1, Student student2)
        {
            if (student1 == null && student2 == null)
                return 0;
            if (student1 == null)
                return -1;
            if (student2 == null)
                return 1;
            return student1.Grade.Average().CompareTo(student2.Grade.Average()); // если знак-, то переворот
        }
    }
}

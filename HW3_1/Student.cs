//  Класс Student должен содержать закрытые поля: фамилия, номер группы, успеваемость (массив оценок) и все необходимые для решения задачи свойства и методы.
//  Можно также создать класс – контейнер для студентов(по желанию).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_1
{
    class Student
    {
        public string LastName { get; set; }       // фамилия
        public string GroupNumber { get; set; }    // номер группы
        public int[] Grade { get; set; }           // массив оценок
        public Student(int countGrade)
        {
            Grade = new int[countGrade];
        }
    }
}

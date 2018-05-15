using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_7.Models
{
    public class Instructor
    {
        public int InstructorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Midname { get; set; }
        public int Experience { get; set; }
        public string Aducation { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public override string ToString()
        {
            return  "ID инструктора: " + InstructorID + " Имя: " + Name + " Фамилия: " + Surname + " Отчество: " + Midname + " Опыт: " + Experience + " Образование: " + Aducation;
        }
    }
}

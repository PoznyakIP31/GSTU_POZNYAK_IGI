using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1.Models
{
    public class Visitor
    {
        public int VisitorID { get; set; }
        public int GroupID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Midname { get; set; }
        public string Passport { get; set; }

        public virtual Group Group { get; set; }
        public override string ToString()
        {
            return "ID посетителя: " + GroupID + " ID группы: " + GroupID + " Имя: " + Name + " Фамилия: " + Surname+ " Отчество: " + Midname+ " Паспортные данные: " + Passport;
        }
    }
}

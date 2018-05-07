using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public int InstructorID { get; set; }
        public string Name { get; set; }
        public int Count_of_visitor { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<Visitor> Visitors { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }
        public override string ToString()
        {
            return "ID группы: " + GroupID + " ID инструктора: " + InstructorID + " Имя: " + Name + " Количество посетителей: " + Count_of_visitor;
        }
    }

}

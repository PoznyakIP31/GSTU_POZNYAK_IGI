using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3.Models
{
    public class TimeTable
    {
        public int TimeTableID { get; set; }
        public int GroupID { get; set; }
        public string Time_visits { get; set; }
        public int Days_of_the_week { get; set; }
        public virtual Group Group { get; set; }
        public override string ToString()
        {
            return "ID расписания: " + TimeTableID + " ID группы: " + GroupID + " Время посещения: " + Time_visits + " Дней в неделю: " + Days_of_the_week;
        }
    }
}

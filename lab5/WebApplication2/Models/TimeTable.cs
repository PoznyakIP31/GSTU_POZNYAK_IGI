using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab_1.Models
{
    public class TimeTable
    {
        public int TimeTableID { get; set; }
        public int GroupID { get; set; }
        [Required]
        public string Time_visits { get; set; }
        [Required]
        public int Days_of_the_week { get; set; }
        public virtual Group Group { get; set; }
        public override string ToString()
        {
            return "ID расписания: " + TimeTableID + " ID группы: " + GroupID + " Время посещения: " + Time_visits + " Дней в неделю: " + Days_of_the_week;
        }
    }
}

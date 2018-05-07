using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab_1.Models
{
    public class Instructor
    {
        public int InstructorID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
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

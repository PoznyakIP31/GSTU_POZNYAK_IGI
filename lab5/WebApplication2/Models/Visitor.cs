﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lab_1.Models
{
    public class Visitor
    {
        public int VisitorID { get; set; }
        public int GroupID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Midname { get; set; }
        [Required]
        public string Passport { get; set; }

        public virtual Group Group { get; set; }
        public override string ToString()
        {
            return "ID посетителя: " + GroupID + " ID группы: " + GroupID + " Имя: " + Name + " Фамилия: " + Surname+ " Отчество: " + Midname+ " Паспортные данные: " + Passport;
        }
    }
}

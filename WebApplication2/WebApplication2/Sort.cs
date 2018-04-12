using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_1.Models;

namespace WebApplication2
{
    public enum  Sort
    { 
    GroupIDAsc,InstructorIDAsc, NameAsc, Count_of_visitorAsc, GroupIDDesc, InstructorIDDesc, NameDesc, Count_of_visitorDesc,
             SurnameAsc, MidnameAsc, ExperienceAsc, AducationAsc,  SurnameDesc, MidnameDesc, ExperienceDesc, AducationDesc,
        TimeTableIDAsc, Time_visitsAsc, Days_of_the_weekAsc, TimeTableIDDesc, Time_visitsDesc, Days_of_the_weekDesc,
        VisitorIDAsc, PassportAsc, VisitorIDDesc, PassportDesc
    }
}

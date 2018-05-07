using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_1.Models;

namespace Lab_1
{
    public class HomeViewModel
    {
        
            public IEnumerable<Group> Groups { get; set; }
            public IEnumerable<Visitor> Visitors { get; set; }
            public IEnumerable<Instructor> Instructors { get; set; }
            public IEnumerable<TimeTable> TimeTables { get; set; }

    }
}

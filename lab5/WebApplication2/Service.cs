using System.Collections.Generic;
using System.Linq;
using Lab_1.Models;

namespace Lab_1
{
    // Класс выборки 10 записей из всех таблиц 
    public class Service
    {
        private  SportContext _context = new SportContext();
        
        public HomeViewModel GetHomeViewModel()
        {
            var visitors = _context.Visitors.ToList();
            var groups = _context.Groups.ToList();
            var instructors = _context.Instructors.ToList();
            var timetables = _context.Timetables.ToList();


            HomeViewModel homeViewModel = new HomeViewModel
            {
                Visitors = visitors,
                Groups = groups,
                Instructors = instructors,
                TimeTables=timetables
            };
            return homeViewModel;
        }

    }
}

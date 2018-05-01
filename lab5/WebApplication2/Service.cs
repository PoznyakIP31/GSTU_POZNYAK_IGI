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
            var visitors = _context.Visitors.Take(10).ToList();
            var groups = _context.Groups.Take(10).ToList();
            var instructors = _context.Instructors.Take(10).ToList();
            var timetables = _context.Timetables.Take(10).ToList();


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

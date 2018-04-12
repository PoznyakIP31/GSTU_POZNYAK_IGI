using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_1.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private SportContext _db;
        public HomeController(SportContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var instructor = _db.Instructors.Take(10).ToList();
            var group = _db.Groups.Take(10).ToList();
            var timetable = _db.Timetables.Take(10).ToList();
            var visitor = _db.Visitors.Take(10).ToList();


            HomeViewModel homeViewModel = new HomeViewModel { Instructors = instructor,Visitors=visitor,Groups=group, TimeTables=timetable };
            return View(homeViewModel);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Lab_3.Controllers
{
    public class HomeController : Controller
    {
        readonly IMemoryCache _memoryCache;
        readonly SportContext _context;

        public HomeController(IMemoryCache memoryCache, SportContext context)
        {
            _memoryCache = memoryCache;
            _context = context;
        }
        [ResponseCache(CacheProfileName = "Caching")]
        public IActionResult Index()
        {
            Visitor visitorsFromMemoryCashe = (Visitor)_memoryCache.Get(Request.Path.Value.ToLower());

            if (Request.Cookies["coockiesVisitors"] != null)
            {
                Visitor visitorsCoockies = JsonConvert.DeserializeObject<Visitor>(Request.Cookies["coockiesVisitors"].ToString());
                ViewBag.adCoockies = visitorsCoockies;
            }
            ViewBag.visitorsFromMemory = visitorsFromMemoryCashe;
            ViewBag.visitors = _context.Visitors.Include(v => v.Group).ToList();
            return View();
        }
        [ResponseCache(CacheProfileName = "Caching")]
        public IActionResult Instructor()
        {
            Instructor instructorsFromMemoryCashe = (Instructor)_memoryCache.Get(Request.Path.Value.ToLower());

            if (HttpContext.Session.Get("InstructorsSession") != null)
            {
                string[] instructorsSessionArray = HttpContext.Session.GetString("InstructorsSession").Split(";");
                Instructor instructorsSession = new Instructor(instructorsSessionArray[0], instructorsSessionArray[1], instructorsSessionArray[2], instructorsSessionArray[3]);
                ViewBag.instructorsSession = instructorsSession;
            }
            ViewBag.instructorsFromMemory = instructorsFromMemoryCashe;
            ViewBag.instructors = _context.Instructors.ToList();
            return View();
            
        }
        [ResponseCache(CacheProfileName = "Caching")]
        public IActionResult TimeTable()
        {
            TimeTable timetablesFromMemoryCashe = (TimeTable)_memoryCache.Get(Request.Path.Value.ToLower());

            if (Request.Cookies["coockiesTimeTables"] != null)
            {
                TimeTable timetables = JsonConvert.DeserializeObject<TimeTable>(Request.Cookies["coockiesTimeTables"].ToString());
                ViewBag.timetablesCoockies = timetables;
            }

            ViewBag.timetablesFromMemory = timetablesFromMemoryCashe;
            ViewBag.timetables = _context.Timetables.Include(v => v.Group).ToList();
            return View();
            
        }
        [ResponseCache(CacheProfileName = "Caching")]
        public IActionResult Group()
        {
            ViewBag.groups = _context.Groups.Include(v => v.Instructor).ToList();
            return View();
            
        }
        [HttpPost]
        public IActionResult AddVisitors(Visitor visitor)
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMinutes(1);

            if (Request.Cookies["coockiesVisitors"] == null)
            {
                string value = JsonConvert.SerializeObject(visitor);
                Response.Cookies.Append("coockiesVisitors", value);
            }

            _context.Visitors.Add(visitor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddInstructors(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();

            string sess = instructor.Name + ";" + instructor.Surname + ";" + instructor.Midname + ";" + instructor.Aducation + ";" + instructor.Experience + ";";
            HttpContext.Session.SetString("InstructorsSession", sess);

            return RedirectToAction("Instructor");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

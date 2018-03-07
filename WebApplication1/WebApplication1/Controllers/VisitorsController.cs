using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_1.Models;

namespace WebApplication1.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly SportContext _context= new SportContext();

        public IActionResult Index(string Name, int GroupID)
        {
            var sportContext = _context.Visitors.Include(v => v.Group).ToList();
            ViewData["GroupID"] = _context.Groups.ToList();
            ViewData["poisk"] = GroupID;
            
            if (Name != null)
            {
                sportContext = _context.Visitors.Include(v => v.Group).Where(t => t.GroupID == GroupID && t.Name == Name).ToList();
                return View(sportContext);
            }
            else
            {

                return View(sportContext);
            }
        }
        public IActionResult Instructor(string Name, int InstructorID)
        {
            var sportContext = _context.Instructors.ToList();
            ViewData["InstructorID"] = _context.Instructors.ToList();
            ViewData["poisk"] = InstructorID;

            if (Name != null)
            {
                sportContext = _context.Instructors.Where(t => t.Name == Name && t.InstructorID == InstructorID).ToList();
                return View(sportContext);
            }
            else
            {

                return View(sportContext);
            }
        }
            public IActionResult TimeTable(int TimeTableID, int GroupID)
        {
            var sportContext = _context.Timetables.Include(v => v.Group).ToList();

            ViewData["GroupID"] = _context.Groups.ToList();
            ViewData["poisk"] = GroupID;

            if (TimeTableID != 0)
            {
                sportContext = _context.Timetables.Include(v => v.Group).Where(t => t.GroupID == GroupID && t.TimeTableID == TimeTableID).ToList();
                return View(sportContext);
            }
            else
            {

                return View(sportContext);
            }
        }

            public IActionResult Group(string Name, int GroupID)
        {
            var sportContext = _context.Groups.Include(v => v.Instructor).ToList();
            ViewData["GroupID"] = _context.Groups.ToList();
            ViewData["poisk"] = GroupID;

            if (Name != null)
            {
                sportContext = _context.Groups.Include(v => v.Instructor).Where(t => t.GroupID == GroupID && t.Name == Name).ToList();
                return View(sportContext);
            }

            else
            {
                return View(sportContext);
            }
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitor = _context.Visitors
                .Include(v => v.Group)
                .SingleOrDefault(m => m.VisitorID == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        public IActionResult Create()
        {
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupID");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("VisitorID,GroupID,Name,Surname,Midname,Passport")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupID", visitor.GroupID);
            return View(visitor);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitor = _context.Visitors.SingleOrDefault(m => m.VisitorID == id);
            if (visitor == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupID", visitor.GroupID);
            return View(visitor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("VisitorID,GroupID,Name,Surname,Midname,Passport")] Visitor visitor)
        {
            if (id != visitor.VisitorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                    _context.Update(visitor);
                    _context.SaveChanges();
                

                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupID", visitor.GroupID);
            return View(visitor);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitor =  _context.Visitors
                .Include(v => v.Group)
                .SingleOrDefault(m => m.VisitorID == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var visitor =  _context.Visitors.SingleOrDefault(m => m.VisitorID == id);
            _context.Visitors.Remove(visitor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Lab_1.Controllers
{
    [TypeFilter(typeof(TimingLogAttribute))] // Фильтр
    [ExceptionFilter] // Фильтр
    public class GroupsController : Controller
    {
        private readonly SportContext _context=new SportContext();

        [Authorize(Roles = "admin")]
        [Authorize(Roles = "user")]
        // GET: Groups
        public IActionResult Index(string Surname,Sort sortorder= Sort.NameAsc)
        {
            
            IQueryable<Group> sportContext = _context.Groups.Include(i=> i.Instructor);
            if (Surname != null)
            {
                sportContext = _context.Groups.Include(v => v.Instructor).Where(t =>t.Instructor.Surname.Contains(Surname));
  
            }
            ViewData["NameSort"] = sortorder == Sort.NameAsc ? Sort.NameDesc : Sort.NameAsc;
            ViewData["OldValue"] = Surname;
            switch (sortorder)
            {
                case Sort.NameDesc:
                    sportContext = sportContext.OrderByDescending(f => f.Name);
                    break;
                default:
                    sportContext = sportContext.OrderBy(f => f.Name);
                    break;
            }
            return View(sportContext);
        }
        [Authorize(Roles = "admin")]
        // GET: Groups/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group =  _context.Groups
                .Include(i => i.Instructor)
                .SingleOrDefault(m => m.GroupID == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }
        [Authorize(Roles = "admin")]
        // GET: Groups/Create
        public IActionResult Create()
        {
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorID");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("GroupID,InstructorID,Name,Count_of_visitor")] Group @group)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@group);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorID", @group.InstructorID);
            return View(@group);
        }
        [Authorize(Roles = "admin")]
        // GET: Groups/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group =  _context.Groups.SingleOrDefault(m => m.GroupID == id);
            if (@group == null)
            {
                return NotFound();
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorID", @group.InstructorID);
            return View(@group);
        }
        [Authorize(Roles = "admin")]
        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Edit(int id, [Bind("GroupID,InstructorID,Name,Count_of_visitor")] Group @group)
        {
            if (id != @group.GroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@group);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.GroupID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorID", @group.InstructorID);
            return View(@group);
        }
        [Authorize(Roles = "admin")]
        // GET: Groups/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group =  _context.Groups
                .Include(i => i.Instructor)
                .SingleOrDefault(m => m.GroupID == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var @group =  _context.Groups.SingleOrDefault(m => m.GroupID == id);
            _context.Groups.Remove(@group);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.GroupID == id);
        }
    }
}

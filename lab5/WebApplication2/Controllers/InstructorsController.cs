using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_1.Models;
using Lab_1;
using Microsoft.AspNetCore.Authorization;

namespace Lab_1.Controllers
{
    [ExceptionFilter]
    [TypeFilter(typeof(TimingLogAttribute))]
    public class InstructorsController : Controller
    {
        private readonly SportContext _context=new SportContext();


        [Authorize(Roles = "admin")]
        [Authorize(Roles = "user")]
        // GET: Instructors
        [SetToSession("SortState")]
       
 public IActionResult Index(string Name, Sort sortorder=Sort.NameAsc)
        {
            var sessionOperation = HttpContext.Session.Get("Operation");
            var sessionSortState = HttpContext.Session.Get("SortState");
            if (sessionOperation != null)
                if (sessionSortState.Count > 0) sortorder = (Sort)Enum.Parse(typeof(Sort), sessionSortState["sortOrder"]);
            IQueryable<Instructor> sportContext = _context.Instructors;

            if (Name != null)
            {
                sportContext = sportContext.Where(t => t.Name.Contains(Name));
                //return View(sportContext);
            }
          
            ViewData["NameSort"] = sortorder== Sort.NameAsc ? Sort.NameDesc : Sort.NameAsc;
            ViewData["OldValue"] = Name;
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
        // GET: Instructors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor =  _context.Instructors
                .SingleOrDefault(i => i.InstructorID == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }
        [Authorize(Roles = "admin")]
        // GET: Instructors/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        // POST: Instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("InstructorID,Name,Surname,Midname,Experience,Aducation")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }
        [Authorize(Roles = "admin")]
        // GET: Instructors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor =  _context.Instructors.SingleOrDefaultAsync(i => i.InstructorID == id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }
        [Authorize(Roles = "admin")]
        // POST: Instructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("InstructorID,Name,Surname,Midname,Experience,Aducation")] Instructor instructor)
        {
            if (id != instructor.InstructorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructor);
                     _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorExists(instructor.InstructorID))
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
            return View(instructor);
        }
        [Authorize(Roles = "admin")]
        // GET: Instructors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor =  _context.Instructors
                .SingleOrDefault(i => i.InstructorID == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }
        [Authorize(Roles = "admin")]
        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var instructor =  _context.Instructors.SingleOrDefault(i => i.InstructorID == id);
            _context.Instructors.Remove(instructor);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorExists(int id)
        {
            return _context.Instructors.Any(e => e.InstructorID == id);
        }
    }
}

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
    public class TimeTablesController : Controller
    {
        private readonly SportContext _context=new SportContext();


        // GET: TimeTables
        public IActionResult Index(string GroupName, Sort sortorder = Sort.NameAsc)
        {
            IQueryable<TimeTable> sportContext = _context.Timetables.Include(t => t.Group);
            
          

            if (GroupName != null)
            {
                sportContext = _context.Timetables.Include(t => t.Group).Where(t => t.Group.Name.Contains(GroupName));
              
            }
            ViewData["Days_of_the_weekSort"] = sortorder == Sort.NameAsc ? Sort.NameDesc : Sort.NameAsc;
            ViewData["OldValue"] = GroupName;
            switch (sortorder)
            {
                case Sort.NameDesc:
                    sportContext = sportContext.OrderByDescending(f => f.Days_of_the_week);
                    break;
                default:
                    sportContext = sportContext.OrderBy(f => f.Days_of_the_week);
                    break;
            }
            return View(sportContext);

        }
        [Authorize(Roles = "admin")]
        // GET: TimeTables/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeTable =  _context.Timetables
                .Include(t => t.Group)
                .SingleOrDefault(m => m.TimeTableID == id);
            if (timeTable == null)
            {
                return NotFound();
            }

            return View(timeTable);
        }
        [Authorize(Roles = "admin")]
        // GET: TimeTables/Create
        public IActionResult Create()
        {
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupID");
            return View();
        }
        [Authorize(Roles = "admin")]
        // POST: TimeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TimeTableID,GroupID,Time_visits,Days_of_the_week")] TimeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeTable);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupID", timeTable.GroupID);
            return View(timeTable);
        }
        [Authorize(Roles = "admin")]
        // GET: TimeTables/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeTable =  _context.Timetables.SingleOrDefault(m => m.TimeTableID == id);
            if (timeTable == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupID", timeTable.GroupID);
            return View(timeTable);
        }
        [Authorize(Roles = "admin")]
        // POST: TimeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TimeTableID,GroupID,Time_visits,Days_of_the_week")] TimeTable timeTable)
        {
            if (id != timeTable.TimeTableID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeTable);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeTableExists(timeTable.TimeTableID))
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
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupID", timeTable.GroupID);
            return View(timeTable);
        }
        [Authorize(Roles = "admin")]
        // GET: TimeTables/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeTable =  _context.Timetables
                .Include(t => t.Group)
                .SingleOrDefault(m => m.TimeTableID == id);
            if (timeTable == null)
            {
                return NotFound();
            }

            return View(timeTable);
        }
        [Authorize(Roles = "admin")]
        // POST: TimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var timeTable =  _context.Timetables.SingleOrDefault(m => m.TimeTableID == id);
            _context.Timetables.Remove(timeTable);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeTableExists(int id)
        {
            return _context.Timetables.Any(e => e.TimeTableID == id);
        }
    }
}

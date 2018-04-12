using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_1.Models;

namespace WebApplication2.Controllers
{
    [ExceptionFilter]
    [TypeFilter(typeof(TimingLogAttribute))]
    public class VisitorsController : Controller
    {

        private readonly SportContext _context = new SportContext();

        // GET: Visitors
        public IActionResult Index(string Surname, Sort sortorder = Sort.NameAsc)
        {
            IQueryable<Visitor> sportContext = _context.Visitors.Include(v => v.Group);
            if (Surname != null)
            {
               // sportContext = _context.Visitors.Where(t => t.Surname.Contains(Surname)).ToList();
            }
            ViewData["PassportSort"] = sortorder == Sort.NameAsc ? Sort.NameDesc : Sort.NameAsc;
            switch (sortorder)
            {
                case Sort.NameDesc:
                    sportContext = sportContext.OrderByDescending(f => f.Passport);
                    break;
                default:
                    sportContext = sportContext.OrderBy(f => f.Passport);
                    break;
            }
            return View(sportContext);
        }

        // GET: Visitors/Details/5
        public IActionResult Details(int? id)
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

        // GET: Visitors/Create
        public IActionResult Create()
        {
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupID");
            return View();
        }

        // POST: Visitors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Visitors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitor =  _context.Visitors.SingleOrDefault(m => m.VisitorID == id);
            if (visitor == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupID", visitor.GroupID);
            return View(visitor);
        }

        // POST: Visitors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                try
                {
                    _context.Update(visitor);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitorExists(visitor.VisitorID))
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
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupID", visitor.GroupID);
            return View(visitor);
        }

        // GET: Visitors/Delete/5
        public IActionResult Delete(int? id)
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

        // POST: Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var visitor =  _context.Visitors.SingleOrDefault(m => m.VisitorID == id);
            _context.Visitors.Remove(visitor);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitorExists(int id)
        {
            return _context.Visitors.Any(e => e.VisitorID == id);
        }
    }
}

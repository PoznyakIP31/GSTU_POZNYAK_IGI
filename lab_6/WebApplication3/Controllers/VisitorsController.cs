using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication3;

namespace FuelStationWebApi.Controllers
{
    [Route("api/[controller]")]
    public class VisitorsController : Controller
    {
        private readonly SportContext _context;
        public VisitorsController(SportContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        [Produces("application/json")]
        public List<VisitorsViewModel> Get()
        {
            var ovm = _context.Visitors.Include(v => v.Group).Select(o =>
                new VisitorsViewModel
                {
                    VisitorID = o.VisitorID,
                    GroupID = o.GroupID,
                    Name = o.Name,
                    Surname = o.Surname,
                    Midname = o.Midname,
                    Passport = o.Passport,
                    GroupName = o.Group.Name,
                });
            return ovm.OrderByDescending(t => t.VisitorID).Take(20).ToList();
        }
        // GET api/values
        [HttpGet("groups")]
        [Produces("application/json")]
        public IEnumerable<Group> GetGroups()
        {
            return _context.Groups.ToList();
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Visitor visitor = _context.Visitors.FirstOrDefault(x => x.VisitorID == id);
            if (visitor == null)
                return NotFound();
            return new ObjectResult(visitor);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Visitor visitor)
        {
            if (visitor == null)
            {
                return BadRequest();
            }

            _context.Visitors.Add(visitor);
            _context.SaveChanges();
            return Ok(visitor);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Visitor visitor)
        {
            if (visitor == null)
            {
                return BadRequest();
            }
            if (!_context.Visitors.Any(x => x.VisitorID == visitor.VisitorID))
            {
                return NotFound();
            }

            _context.Update(visitor);
            _context.SaveChanges();


            return Ok(visitor);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Visitor visitor = _context.Visitors.FirstOrDefault(x => x.VisitorID == id);
            if (visitor == null)
            {
                return NotFound();
            }
            _context.Visitors.Remove(visitor);
            _context.SaveChanges();
            return Ok(visitor);
        }
    }
}

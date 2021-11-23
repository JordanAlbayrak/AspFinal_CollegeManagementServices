using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using College_Management_Services.Data;
using College_Management_Services.Models;

namespace College_Management_Services.Areas.Student.Controllers
{
    [Area("Student")]
    public class StudentDutiesController : Controller
    {
        private readonly College_Management_ServicesContext _context;

        public StudentDutiesController(College_Management_ServicesContext context)
        {
            _context = context;
        }

        // GET: Student/StudentDuties
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentDuties.ToListAsync());
        }

        // GET: Student/StudentDuties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentDuty = await _context.StudentDuties
                .FirstOrDefaultAsync(m => m.DutyId == id);
            if (studentDuty == null)
            {
                return NotFound();
            }

            return View(studentDuty);
        }

        // GET: Student/StudentDuties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/StudentDuties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DutyId,Code,Description,Status")] StudentDuty studentDuty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentDuty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentDuty);
        }

        // GET: Student/StudentDuties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentDuty = await _context.StudentDuties.FindAsync(id);
            if (studentDuty == null)
            {
                return NotFound();
            }
            return View(studentDuty);
        }

        // POST: Student/StudentDuties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DutyId,Code,Description,Status")] StudentDuty studentDuty)
        {
            if (id != studentDuty.DutyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentDuty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentDutyExists(studentDuty.DutyId))
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
            return View(studentDuty);
        }

        // GET: Student/StudentDuties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentDuty = await _context.StudentDuties
                .FirstOrDefaultAsync(m => m.DutyId == id);
            if (studentDuty == null)
            {
                return NotFound();
            }

            return View(studentDuty);
        }

        // POST: Student/StudentDuties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentDuty = await _context.StudentDuties.FindAsync(id);
            _context.StudentDuties.Remove(studentDuty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentDutyExists(int id)
        {
            return _context.StudentDuties.Any(e => e.DutyId == id);
        }
    }
}

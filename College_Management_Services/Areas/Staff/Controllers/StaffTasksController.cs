using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using College_Management_Services.Data;
using College_Management_Services.Models;

namespace College_Management_Services.Areas.Staff.Controllers
{
    [Area("Staff")]
    public class StaffTasksController : Controller
    {
        private readonly College_Management_ServicesContext _context;

        public StaffTasksController(College_Management_ServicesContext context)
        {
            _context = context;
        }

        // GET: Staff/StaffTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaffTasks.ToListAsync());
        }

        // GET: Staff/StaffTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffTask = await _context.StaffTasks
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (staffTask == null)
            {
                return NotFound();
            }

            return View(staffTask);
        }

        // GET: Staff/StaffTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff/StaffTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,Code,Description,Location,Status")] StaffTask staffTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffTask);
        }

        // GET: Staff/StaffTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffTask = await _context.StaffTasks.FindAsync(id);
            if (staffTask == null)
            {
                return NotFound();
            }
            return View(staffTask);
        }

        // POST: Staff/StaffTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,Code,Description,Location,Status")] StaffTask staffTask)
        {
            if (id != staffTask.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffTaskExists(staffTask.TaskId))
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
            return View(staffTask);
        }

        // GET: Staff/StaffTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffTask = await _context.StaffTasks
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (staffTask == null)
            {
                return NotFound();
            }

            return View(staffTask);
        }

        // POST: Staff/StaffTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffTask = await _context.StaffTasks.FindAsync(id);
            _context.StaffTasks.Remove(staffTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffTaskExists(int id)
        {
            return _context.StaffTasks.Any(e => e.TaskId == id);
        }
    }
}

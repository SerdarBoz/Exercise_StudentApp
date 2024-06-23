using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentApplicatie.Models;

namespace StudentApplicatie.Controllers
{
    public class ClassGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassGroups.ToListAsync());
        }

        // GET: ClassGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classGroup = await _context.ClassGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classGroup == null)
            {
                return NotFound();
            }

            return View(classGroup);
        }

        // GET: ClassGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ClassGroup classGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classGroup);
        }

        // GET: ClassGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classGroup = await _context.ClassGroups.FindAsync(id);
            if (classGroup == null)
            {
                return NotFound();
            }
            return View(classGroup);
        }

        // POST: ClassGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ClassGroup classGroup)
        {
            if (id != classGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassGroupExists(classGroup.Id))
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
            return View(classGroup);
        }

        // GET: ClassGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classGroup = await _context.ClassGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classGroup == null)
            {
                return NotFound();
            }

            return View(classGroup);
        }

        // POST: ClassGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classGroup = await _context.ClassGroups.FindAsync(id);
            if (classGroup != null)
            {
                _context.ClassGroups.Remove(classGroup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassGroupExists(int id)
        {
            return _context.ClassGroups.Any(e => e.Id == id);
        }
    }
}

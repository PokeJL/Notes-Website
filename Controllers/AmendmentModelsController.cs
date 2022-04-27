#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Notes_Website.Data;
using Notes_Website.Models;
using Microsoft.AspNetCore.Authorization;

namespace Notes_Website.Controllers
{
    [Authorize] //This pervents users that are not logged in from see the notes and pervents all note related functions from running
    public class AmendmentModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AmendmentModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AmendmentModels/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var addition = new AmendmentModel() { Date = DateTime.Now, NoteModelId = (int)id }; //Automatically puts in the current date

            return View(addition);
        }

        // POST: AmendmentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Date,Author,Details,Note_Part,NoteModelId")] AmendmentModel addition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addition);
                await _context.SaveChangesAsync();
                var id = addition.NoteModelId;
                return RedirectToAction("Details", "NoteModels", new { id }); //Sends the user back to the original note they were viewing
            }
            return View(addition);
        }

        // GET: AmendmentModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addition = await _context.AmendmentModels.FindAsync(id);
            if (addition == null)
            {
                return NotFound();
            }
            return View(addition);
        }

        // POST: AmendmentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Date,Author,Details,Note_Part,NoteModelId")] AmendmentModel addition)
        {
            if (id != addition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteModelExists(addition.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                int Id = addition.NoteModelId;
                return RedirectToAction("Details", "NoteModels", new { Id }); //Sends the user back to the original note they were viewing
            }
            return View(addition);
        }

        // GET: AmendmentModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addition = await _context.AmendmentModels
                                .Include(t => t.Note).FirstOrDefaultAsync(r => r.Id == id);
            if (addition == null)
            {
                return NotFound();
            }
            return View(addition);
        }

        // POST: AmendmentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addition = _context.AmendmentModels.FirstOrDefault(r => r.Id == id);
            _context.AmendmentModels.Remove(addition);
            await _context.SaveChangesAsync();
            int Id = addition.NoteModelId;
            return RedirectToAction("Details", "NoteModels", new { Id }); //Sends the user back to the original note they were viewing
        }

        private bool NoteModelExists(int id)
        {
            return _context.NoteModel.Any(e => e.Id == id);
        }
    }
}

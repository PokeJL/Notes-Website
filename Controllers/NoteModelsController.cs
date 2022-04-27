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
    [Route("note/{action=Index}/{id?}")]
    public class NoteModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NoteModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        const string SessionKeyNoteType = "_noteType";
        private string NoteType     // To store and get the BlogType from session state 
        {
            set
            {
                if (string.IsNullOrEmpty(value) || value == "All")
                    HttpContext.Session.Remove(SessionKeyNoteType);    // Delete the stored NoteType                
                else
                    HttpContext.Session.SetString(SessionKeyNoteType, value);  // Save the new value
            }
            get => HttpContext.Session.GetString(SessionKeyNoteType);  // Get the stored value
        }

        // GET: NoteModels
        public async Task<IActionResult> Index()
        {
            return await Notes(null, null);
        }
        // GET: /notes
        [Route("/notes/page{num}")]
        [Route("/notes/{notetype?}/page{num}")]
        [Route("/notes/page{num}/{notetype}")]
        [Route("/notes/{notetype?}")]
        public async Task<IActionResult> Notes(string noteType, int? num)
        {
            IQueryable<NoteModel> query = _context.NoteModel.Include("NoteType");

            if (noteType != null) NoteType = noteType;
            if (NoteType != null)
            {
                query = query.Where(n => n.NoteType.Type == NoteType);
            }

            ViewBag.TotalPages = Math.Ceiling((double)query.Count() / 4);
            query = query.OrderByDescending(m => m.Added);
            ViewBag.CurrentPageNumber = 1;

            if (num != null)
            {
                query = query.Skip(((int)num - 1) * 4);
                ViewBag.CurrentPageNumber = num;
            }

            query = query.Take(4);

            ViewBag.noteTypes = _context.NoteTypes.ToList();
            ViewBag.currentNoteType = NoteType;

            return View("Index", await query.ToListAsync());
        }

        // GET: NoteModels/Details/5
        [Route("/note/{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteModel = await _context.NoteModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noteModel == null)
            {
                return NotFound();
            }
            ViewBag.AmendmentModels = _context.AmendmentModels.Where(m => m.NoteModelId == noteModel.Id).ToList();
            ViewBag.noteTypes = _context.NoteTypes.ToList();
            return View(noteModel);
        }

        // GET: NoteModels/Create
        public IActionResult Create()
        {
            var note = new NoteModel() { Added = DateTime.Now };

            ViewBag.noteTypes = _context.NoteTypes.ToList();
            return View(note);

            //return View();
        }

        // POST: NoteModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Note,Added,Note_Part,NoteTypeId")] NoteModel noteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.noteTypes = _context.NoteTypes.ToList();
            return View(noteModel);
        }

        // GET: NoteModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteModel = await _context.NoteModel.FindAsync(id);
            if (noteModel == null)
            {
                return NotFound();
            }
            ViewBag.noteTypes = _context.NoteTypes.ToList();
            return View(noteModel);
        }

        // POST: NoteModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Note,Added,Note_Part,NoteTypeId")] NoteModel noteModel)
        {
            if (id != noteModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteModelExists(noteModel.Id))
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
            ViewBag.noteTypes = _context.NoteTypes.ToList();
            return View(noteModel);
        }

        // GET: NoteModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteModel = await _context.NoteModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noteModel == null)
            {
                return NotFound();
            }
            ViewBag.noteTypes = _context.NoteTypes.ToList();
            return View(noteModel);
        }

        // POST: NoteModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noteModel = await _context.NoteModel.FindAsync(id);
            _context.NoteModel.Remove(noteModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteModelExists(int id)
        {
            return _context.NoteModel.Any(e => e.Id == id);
        }
    }
}

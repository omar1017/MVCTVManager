using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TVManager_Domain;
using TVManager_Infrastructure;

namespace MVCTVManagerProject.Controllers
{
    public class TVShowsController : Controller
    {
        private readonly TVManagerDBContext _context;

        public TVShowsController(TVManagerDBContext context)
        {
            _context = context;
        }

        // GET: TVShows
        public async Task<IActionResult> Index()
        {
            var tVManagerDBContext = _context.TVShows.Include(t => t.Attachment).Include(t => t.Language);
            return View(await tVManagerDBContext.ToListAsync());
        }

        // GET: TVShows/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVShow = await _context.TVShows
                .Include(t => t.Attachment)
                .Include(t => t.Language)
                .FirstOrDefaultAsync(m => m.TVShowID == id);
            if (tVShow == null)
            {
                return NotFound();
            }

            return View(tVShow);
        }

        // GET: TVShows/Create
        public IActionResult Create()
        {
            ViewData["AttachmentID"] = new SelectList(_context.Attachments, "AttachmentID", "FileType");
            ViewData["LanguageID"] = new SelectList(_context.Languages, "LanguageID", "Name");
            return View();
        }

        // POST: TVShows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TVShowID,Title,ReleaseDate,Rating,URL,LanguageID,AttachmentID")] TVShow tVShow)
        {
            tVShow.TVShowID = Guid.NewGuid();
            _context.Add(tVShow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: TVShows/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVShow = await _context.TVShows.FindAsync(id);
            if (tVShow == null)
            {
                return NotFound();
            }
            ViewData["AttachmentID"] = new SelectList(_context.Attachments, "AttachmentID", "FileType", tVShow.AttachmentID);
            ViewData["LanguageID"] = new SelectList(_context.Languages, "LanguageID", "Name", tVShow.LanguageID);
            return View(tVShow);
        }

        // POST: TVShows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TVShowID,Title,ReleaseDate,Rating,URL,LanguageID,AttachmentID")] TVShow tVShow)
        {
            if (id != tVShow.TVShowID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tVShow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TVShowExists(tVShow.TVShowID))
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
            ViewData["AttachmentID"] = new SelectList(_context.Attachments, "AttachmentID", "FileType", tVShow.AttachmentID);
            ViewData["LanguageID"] = new SelectList(_context.Languages, "LanguageID", "Name", tVShow.LanguageID);
            return View(tVShow);
        }

        // GET: TVShows/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVShow = await _context.TVShows
                .Include(t => t.Attachment)
                .Include(t => t.Language)
                .FirstOrDefaultAsync(m => m.TVShowID == id);
            if (tVShow == null)
            {
                return NotFound();
            }

            return View(tVShow);
        }

        // POST: TVShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tVShow = await _context.TVShows.FindAsync(id);
            if (tVShow != null)
            {
                _context.TVShows.Remove(tVShow);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TVShowExists(Guid id)
        {
            return _context.TVShows.Any(e => e.TVShowID == id);
        }
    }
}

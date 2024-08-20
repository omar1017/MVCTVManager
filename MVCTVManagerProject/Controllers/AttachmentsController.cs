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
    public class AttachmentsController : Controller
    {
        private readonly TVManagerDBContext _context;

        public AttachmentsController(TVManagerDBContext context)
        {
            _context = context;
        }

        // GET: Attachments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Attachments.ToListAsync());
        }

        // GET: Attachments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attachment = await _context.Attachments
                .FirstOrDefaultAsync(m => m.AttachmentID == id);
            if (attachment == null)
            {
                return NotFound();
            }

            return View(attachment);
        }

        // GET: Attachments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attachments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttachmentID,Path,Name,FileType")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                attachment.AttachmentID = Guid.NewGuid();
                _context.Add(attachment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attachment);
        }

        // GET: Attachments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attachment = await _context.Attachments.FindAsync(id);
            if (attachment == null)
            {
                return NotFound();
            }
            return View(attachment);
        }

        // POST: Attachments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AttachmentID,Path,Name,FileType")] Attachment attachment)
        {
            if (id != attachment.AttachmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attachment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttachmentExists(attachment.AttachmentID))
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
            return View(attachment);
        }

        // GET: Attachments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attachment = await _context.Attachments
                .FirstOrDefaultAsync(m => m.AttachmentID == id);
            if (attachment == null)
            {
                return NotFound();
            }

            return View(attachment);
        }

        // POST: Attachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var attachment = await _context.Attachments.FindAsync(id);
            if (attachment != null)
            {
                _context.Attachments.Remove(attachment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttachmentExists(Guid id)
        {
            return _context.Attachments.Any(e => e.AttachmentID == id);
        }
    }
}

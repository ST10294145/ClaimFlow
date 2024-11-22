using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClaimFlow.Data;
using ClaimFlow.Models;

namespace ClaimFlow.Controllers
{
    public class ClaimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClaimController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Claim
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClaimSubmissions.ToListAsync());
        }

        // GET: Claim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimSubmission = await _context.ClaimSubmissions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (claimSubmission == null)
            {
                return NotFound();
            }

            return View(claimSubmission);
        }

        // GET: Claim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Claim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ClaimantName,ClaimantEmail,ClaimDate,Status,AttachmentPath")] ClaimSubmission claimSubmission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(claimSubmission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(claimSubmission);
        }

        // GET: Claim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimSubmission = await _context.ClaimSubmissions.FindAsync(id);
            if (claimSubmission == null)
            {
                return NotFound();
            }
            return View(claimSubmission);
        }

        // POST: Claim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ClaimantName,ClaimantEmail,ClaimDate,Status,AttachmentPath")] ClaimSubmission claimSubmission)
        {
            if (id != claimSubmission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claimSubmission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimSubmissionExists(claimSubmission.Id))
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
            return View(claimSubmission);
        }

        // GET: Claim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimSubmission = await _context.ClaimSubmissions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (claimSubmission == null)
            {
                return NotFound();
            }

            return View(claimSubmission);
        }

        // POST: Claim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var claimSubmission = await _context.ClaimSubmissions.FindAsync(id);
            if (claimSubmission != null)
            {
                _context.ClaimSubmissions.Remove(claimSubmission);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaimSubmissionExists(int id)
        {
            return _context.ClaimSubmissions.Any(e => e.Id == id);
        }
    }
}

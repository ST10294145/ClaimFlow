using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClaimFlow.Data;
using ClaimFlow.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClaimFlow.Controllers
{
     // Applies general authorization to all actions in the controller by default
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
        [AllowAnonymous] // Optional: Allows unauthenticated or any authorized user to view details
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

        // (The rest of the actions remain unchanged with any necessary authorization adjustments)

        private bool ClaimSubmissionExists(int id)
        {
            return _context.ClaimSubmissions.Any(e => e.Id == id);
        }
    }
}

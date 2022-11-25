using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SundSalgBackend.Models.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using SundSalgBackend.Data;
using SundSalgBackend.Models;
using AutoMapper;
using SundSalgBackend.Contracts;

namespace SundSalgBackend.Controllers
{
    [Route("api/counselor")]
    [ApiController]
    public class CounselorController : Controller
    {
        private readonly IdentityContext _context;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;


        public CounselorController(
            IdentityContext context,
            IMapper mapper,
            IRepositoryManager repository
            )
        {
            _mapper = mapper;
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Counselor>>> GetCounselors()
        {
            var counselors = _repository.Counselor.GetAllCounselors(trackChanges: false);
            var counselorResult = _mapper.Map<IEnumerable<CounselorDto>>(counselors);
            return Ok(counselorResult);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Counselor>>> CounselorDetails(int id)
        {
            var counselor = _repository.Counselor.GetCounselorById(id, trackChanges: false);
            if (counselor == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(counselor);
        }

        // GET: Counselors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Counselors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Desc,Price,Picture")] Counselor counselor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(counselor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(counselor);
        }

        // GET: Counselors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Counselors == null)
            {
                return NotFound();
            }

            var counselor = await _context.Counselors.FindAsync(id);
            if (counselor == null)
            {
                return NotFound();
            }
            return View(counselor);
        }

        // POST: Counselors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Desc,Price,Picture")] Counselor counselor)
        {
            if (id != counselor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(counselor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CounselorExists(counselor.Id))
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
            return View(counselor);
        }

        // GET: Counselors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Counselors == null)
            {
                return NotFound();
            }

            var counselor = await _context.Counselors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (counselor == null)
            {
                return NotFound();
            }

            return View(counselor);
        }

        // POST: Counselors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Counselors == null)
            {
                return Problem("Entity set 'IdentityContext.Counselors'  is null.");
            }
            var counselor = await _context.Counselors.FindAsync(id);
            if (counselor != null)
            {
                _context.Counselors.Remove(counselor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CounselorExists(int id)
        {
          return _context.Counselors.Any(e => e.Id == id);
        }
    }
}

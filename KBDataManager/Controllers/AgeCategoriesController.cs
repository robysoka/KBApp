using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KBDataAccessLibrary.DataAccess;
using KBDataAccessLibrary.Models;
using KBDataManager.ViewModels;
using AutoMapper;

namespace KBDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeCategoriesController : ControllerBase
    {
        private readonly KBContext _context;
        private IMapper _mapper;

        public AgeCategoriesController(KBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        // GET: api/AgeCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgeCategory>>> GetAgeCategories()
        {
            return await _context.AgeCategories.ToListAsync();
        }

        // GET: api/AgeCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgeCategory>> GetAgeCategory(int id)
        {
            var ageCategory = await _context.AgeCategories.FindAsync(id);

            if (ageCategory == null)
            {
                return NotFound();
            }

            return ageCategory;
        }

        // PUT: api/AgeCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgeCategory(int id, AgeCategory ageCategory)
        {
            if (id != ageCategory.AgeCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(ageCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgeCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AgeCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AgeCategory>> PostAgeCategory([FromBody]AgeCategoryViewModel ageCategoryViewModel)
        {
            var newAgeCategory = _mapper.Map<AgeCategoryViewModel, AgeCategory>(ageCategoryViewModel);
            _context.AgeCategories.Add(newAgeCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgeCategory", new { id = ageCategoryViewModel.AgeCategoryId }, ageCategoryViewModel);
        }

        // DELETE: api/AgeCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgeCategory(int id)
        {
            var ageCategory = await _context.AgeCategories.FindAsync(id);
            if (ageCategory == null)
            {
                return NotFound();
            }

            _context.AgeCategories.Remove(ageCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgeCategoryExists(int id)
        {
            return _context.AgeCategories.Any(e => e.AgeCategoryId == id);
        }
    }
}

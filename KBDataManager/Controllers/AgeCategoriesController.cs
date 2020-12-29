﻿using System;
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
using KBDataAccessLibrary.Repository;

namespace KBDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeCategoriesController : ControllerBase
    {
        private readonly KBContext _context;
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public AgeCategoriesController(KBContext context, IUnitOfWork repository, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
            
        }

        //TODO: Repository Pattern si functii async?

        // GET: api/AgeCategories
        [HttpGet]
        public ActionResult<IEnumerable<AgeCategory>> GetAgeCategories()
        {
           return Ok(_mapper.Map<IEnumerable<AgeCategory>, IEnumerable<AgeCategoryViewModel>>(_repository.AgeCategories.GetAll()));
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
        public IActionResult PutAgeCategory(int id, AgeCategoryViewModel ageCategoryViewModel)
        {
            if (id!=ageCategoryViewModel.AgeCategoryId)
            {
                return BadRequest("Request URL Id does not match the Body Object Id ");
            }
            var ageCategory = _mapper.Map<AgeCategoryViewModel, AgeCategory>(ageCategoryViewModel);
            _context.Entry(ageCategory).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!AgeCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(e);
                }
            }
            
            //TODO: Ce este mai bine sa returnez cu Response Code-ul?
            return Ok(ageCategoryViewModel);
        }

        // POST: api/AgeCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<AgeCategory> PostAgeCategory([FromBody]AgeCategoryViewModel ageCategoryViewModel)
        {
            var newAgeCategory = _mapper.Map<AgeCategoryViewModel, AgeCategory>(ageCategoryViewModel);
            _repository.AgeCategories.Add(newAgeCategory);
            _repository.Complete();

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

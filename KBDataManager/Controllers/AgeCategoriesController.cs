using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KBDataAccessLibrary.Models;
using KBDataManager.ViewModels;
using AutoMapper;
using KBDataAccessLibrary.Repository;
using Microsoft.AspNetCore.Authorization;

namespace KBDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeCategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public AgeCategoriesController(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/AgeCategories
        /// <summary>
        /// Get ALL Age Categories Id and Name
        /// </summary>
        /// <returns>All Age Categories</returns>
        /// <response code="200"> Returns All Age Categories</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AgeCategory>>> GetAgeCategories()
        {
            return Ok(_mapper.Map<IEnumerable<AgeCategory>, IEnumerable<AgeCategoryViewModel>>(await _repository.AgeCategories.GetAll()));
        }

        // GET: api/AgeCategories/5
        /// <summary>
        /// Get Age category by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AgeCategory>> GetAgeCategory(int id)
        {
            var ageCategory = await _repository.AgeCategories.Get(id);
            if (ageCategory == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AgeCategory, AgeCategoryViewModel>(ageCategory));
        }

        // PUT: api/AgeCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update the name of an Age Category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ageCategoryViewModel"></param>
        /// <response code="200"> The modified Age Category </response>
        /// <response code="400"> Request URL Id does not match the Body Object Id </response>
        /// <response code="404"> Not Found </response>
        /// <returns>The modified Age Category</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAgeCategory(int id, [FromBody] AgeCategoryViewModel ageCategoryViewModel)
        {
            if (id != ageCategoryViewModel.AgeCategoryId)
            {
                return BadRequest("Request URL Id does not match the Body Object Id ");
            }
            var ageCategory = _mapper.Map<AgeCategoryViewModel, AgeCategory>(ageCategoryViewModel);
            try
            {
                _repository.AgeCategories.Update(ageCategory);
                await _repository.Complete();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest(e);
            }

            return Ok(ageCategoryViewModel);
        }

        // POST: api/AgeCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Create new Age Category
        /// </summary>
        /// <remarks>
        /// The ID should remain 0 in body request because it's auto-incrementing
        /// </remarks>
        /// <param name="ageCategoryViewModel"></param>
        /// <response code="201"> Created new Age Category </response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AgeCategory>> PostAgeCategory([FromBody] AgeCategoryViewModel ageCategoryViewModel)
        {
            try
            {
                var newAgeCategory = _mapper.Map<AgeCategoryViewModel, AgeCategory>(ageCategoryViewModel);
                _repository.AgeCategories.Add(newAgeCategory);
                await _repository.Complete();
            }
            catch (DbUpdateException e)
            {
                return BadRequest(e);
            }

            return CreatedAtAction("GetAgeCategory", new { id = ageCategoryViewModel.AgeCategoryId }, ageCategoryViewModel.CategoryName);
        }

        // DELETE: api/AgeCategories/5
        /// <summary>
        /// Delete an AgeCategory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAgeCategory(int id)
        {
            var ageCategory = await _repository.AgeCategories.Get(id);
            if (ageCategory == null)
            {
                return NotFound();
            }

            _repository.AgeCategories.Remove(ageCategory);
            await _repository.Complete();

            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KBDataAccessLibrary.DataAccess;
using KBDataAccessLibrary.Models;
using KBDataAccessLibrary.Repository;
using AutoMapper;
using KBDataManager.ViewModels;

namespace KBDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly KBContext _context;
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GroupsController(KBContext context,IUnitOfWork respository, IMapper mapper)
        {
            _context = context;
            _repository = respository;
            _mapper = mapper;
        }

        // GET: api/Groups/ageCategoryId
        /// <summary>
        /// Returns Groups of an Age Category
        /// </summary>
        /// <param name="ageCategoryId"></param>
        /// <returns></returns>
        [HttpGet("{ageCategoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroupsByAgeCategory(int ageCategoryId)
        {
            return Ok(_mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(await _repository.Groups.Find(id => id.AgeCategoryId == ageCategoryId)));
        }
        /*
        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            var @group = await _context.Groups.FindAsync(id);

            if (@group == null)
            {
                return NotFound();
            }

            return @group;
        }
        /*
        // PUT: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, Group @group)
        {
            if (id != @group.GroupId)
            {
                return BadRequest();
            }

            _context.Entry(@group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group @group)
        {
            _context.Groups.Add(@group);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup", new { id = @group.GroupId }, @group);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var @group = await _context.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(@group);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.GroupId == id);
        }
        */
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurvivorWebApi.Data;
using SurvivorWebApi.Data.DTO;
using SurvivorWebApi.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SurvivorWebApi.Controllers
{
    [Route("api/v1/competitors")]
    [ApiController]
    public class CompetitorsController : ControllerBase
    {
        private readonly SurvivorDbContext _context;
        public CompetitorsController(SurvivorDbContext context)
        {
            _context = context;
        }

        // → api/v1/competitors
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var competitors = await _context.Competitors.Include(c => c.Category)
                                                        .ToListAsync();

            return Ok(competitors);
        }

        // → api/v1/competitors/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompetitor(int id)
        {
            var competitor = await _context.Competitors.Include(c => c.Category)
                                                       .FirstOrDefaultAsync(x => x.Id == id);

            if (competitor == null)
            {
                return NotFound();
            }

            return Ok(competitor);
        }


        // → api/v1/competitors/categories/'categoryid'
        [HttpGet("categories/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var competitors = await _context.Competitors
                .Where(c => c.CategoryId == categoryId)
                .Include(c => c.Category)
                .ToListAsync();

            return Ok(competitors);
        }



        // Post: → api/v1/Products
        [HttpPost]
        public async Task<IActionResult> AddingCompetitor([FromBody]CompetitorDTO competitorDto) // → Used dto for related fields I want show
        {
            if (competitorDto == null)
            {
                return BadRequest("Competitor is null");
            }

            
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Name.ToLower() == competitorDto.CategoryName.ToLower());

            if (category == null)
            {
                return BadRequest("CategoryName Wrong. Celebrities or Volunteers please ...");
            }

           
            var competitor = new Competitor
            {
                FirstName = competitorDto.FirstName,
                LastName = competitorDto.LastName,
                CategoryId = category.Id
            };

            _context.Competitors.Add(competitor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompetitor), new { id = competitor.Id }, competitor);

        }

        // Put: → /api/v1/competitors/'id'
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody] Competitor competitor)
        {
            if (id != competitor.Id)
            {
                return BadRequest("Id not matching ...");
            }

            var competitorFind = await _context.Competitors.FirstOrDefaultAsync(x => x.Id == id);

            if (competitorFind is null)
            {
                return BadRequest();
            }

            _context.Entry(competitorFind).State = EntityState.Modified; // → For ModifiedDate
            
            _context.Competitors.Update(competitorFind);

            await _context.SaveChangesAsync();

            return NoContent();
          
        }

        // Delete: → api/v1/competitors/'id'
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitor(int id)
        {
            var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null)
            {
                return NotFound("No id matched...");
            }

            _context.Competitors.Remove(competitor);

            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}

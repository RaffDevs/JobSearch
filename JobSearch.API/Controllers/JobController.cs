using JobSearch.API.Database;
using JobSearch.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly DatabaseContext _database;
        private int registerPerPage = 5;
        public JobController(DatabaseContext database)
        {
            _database = database;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetJobs(string? search = "", string? cityState = "", int page = 1)
        {
            List<Job> jobs;

            if (string.IsNullOrEmpty(search) && string.IsNullOrEmpty(cityState))
            {
                jobs = await _database.Jobs
                    .Skip(registerPerPage * (page - 1))
                    .Take(registerPerPage)
                    .ToListAsync();

            } else
            {
                jobs = await _database.Jobs
                 .Where(job => job.CityState.ToLower().Contains(cityState.ToLower()))
                 .Where(job =>
                     job.JobTitle.ToLower().Contains(search.ToLower()) ||
                     job.TecnologyTools.ToLower().Contains(search.ToLower()) ||
                     job.Company.ToLower().Contains(search.ToLower())
                 ).Skip(registerPerPage * (page - 1))
                 .Take(registerPerPage)
                 .ToListAsync();
            }

            return Ok(jobs);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            Job? job = await _database.Jobs.FirstOrDefaultAsync(job => job.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            return new JsonResult(job);

        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(Job job)
        {
            job.PublishDate = DateTime.Now;

            var newJob = await _database.AddAsync(job);

            if (newJob == null)
            {
                return BadRequest();
            }

            await _database.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJob), new { newJob.Entity.Id }, newJob.Entity);
        }
    }
}

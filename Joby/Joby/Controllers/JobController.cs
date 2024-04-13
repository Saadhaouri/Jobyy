using AutoMapper;
using Joby.Core.Application.Interfaces.IServices;
using Joby.ViewModel;
using JObyy.Core.Application.Dto_s;
using Microsoft.AspNetCore.Mvc;

namespace Web1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;

        public JobController(IJobService jobService, IMapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetJobs()
        {
            var jobsDto = _jobService.GetJobs();
            var jobsViewModel = _mapper.Map<IEnumerable<JobViewModel>>(jobsDto);
            return Ok(jobsViewModel);
        }

        [HttpGet("{jobId}")]
        public IActionResult GetJobById(string jobId)
        {
            var jobDto = _jobService.GetJobById(jobId);

            if (jobDto == null)
            {
                return NotFound(); // Or return a specific error response
            }

            var jobViewModel = _mapper.Map<JobViewModel>(jobDto);
            return Ok(jobViewModel);
        }

        [HttpPost]
        public IActionResult AddJob([FromBody] JobViewModel jobViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobDto = _mapper.Map<JobDto>(jobViewModel);
            _jobService.AddJob(jobDto);

            return Ok();
        }

        [HttpPut("{jobId}")]
        public IActionResult UpdateJob(string jobId, [FromBody] JobViewModel jobViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingJobDto = _jobService.GetJobById(jobId);

            if (existingJobDto == null)
            {
                return NotFound(); // Or return a specific error response
            }

            _mapper.Map(jobViewModel, existingJobDto);
            _jobService.UpdateJob(existingJobDto);

            return NoContent();
        }

        [HttpDelete("{jobId}")]
        public IActionResult DeleteJob(string jobId)
        {
            var existingJobDto = _jobService.GetJobById(jobId);

            if (existingJobDto == null)
            {
                return NotFound(); // Or return a specific error response
            }

            _jobService.DeleteJob(jobId);

            return NoContent();
        }
    }
}

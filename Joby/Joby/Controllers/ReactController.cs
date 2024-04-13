using AutoMapper;
using Joby.ViewModel.Comment;
using Joby.ViewModel.React;
using Jobyy.Core.Application.Dto_s;
using Jobyy.Core.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Joby.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly IReactService _reactServices;
        private readonly IMapper _mapper;

        public ReactController(IReactService reactservive, IMapper mapper)
        {
            _reactServices = reactservive;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetReacts()
        {
            var reactDto = _reactServices.GetReacts();
            var reactsViewModel = _mapper.Map<IEnumerable<ReactViewModel>>(reactDto);
            return Ok(reactsViewModel);
        }



        [HttpGet("{Id}")]
        public IActionResult GetReactById(Guid Id)
        {
            var reactDto = _reactServices.GetReactById(Id);

            if (reactDto == null)
            {
                return NotFound(); // Or return a specific error response
            }

            var ReactViewModel = _mapper.Map<ReactViewModel>(reactDto);
            return Ok(ReactViewModel);
        }


        [HttpPost]
        public IActionResult AddReact([FromBody] ReactViewModel reactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var reactDto = _mapper.Map<ReactDto>(reactViewModel);
                _reactServices.AddReact(reactDto);



                // Return the newly created comment view model with a 201 Created status
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateReact(Guid Id, [FromBody] ReactViewModel reactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingReactDto = _reactServices.GetReactById(Id);

            if (existingReactDto == null)
            {
                return NotFound(); // Or return a specific error response
            }

            _mapper.Map(reactViewModel, existingReactDto);
            _reactServices.UpdateReact(existingReactDto);

            return NoContent();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteReact(Guid Id)
        {
            var existingReactDto = _reactServices.GetReactById(Id);

            if (existingReactDto == null)
            {
                return NotFound(); // Or return a specific error response
            }

            _reactServices.DeleteReact(Id);

            return NoContent();
        }
    }
}

using AutoMapper;
using Joby.Core.Application.Interfaces.IServices;
using JObyy.Core.Application.Dto_s;
using Microsoft.AspNetCore.Mvc;
using Web1.ViewModel.User;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var usersDto = _userService.GetUsers();
        var usersViewModel = _mapper.Map<IEnumerable<UserViewModel>>(usersDto);
        return Ok(usersViewModel);
    }

    [HttpGet("{userId}")]
    public IActionResult GetUserById(string userId)
    {
        var userDto = _userService.GetUserById(userId);

        if (userDto == null)
        {
            return NotFound(); // Or return a specific error response
        }

        var userViewModel = _mapper.Map<UserViewModel>(userDto);
        return Ok(userViewModel);
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] UserViewModel userViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Map the UserViewModel to UserDto
        var userDto = _mapper.Map<UserDto>(userViewModel);

        // Ensure that the user doesn't have an existing UserId


        // Add the user with the provided AddressDto
        _userService.AddUser(userDto);

        // Return a response, you might want to customize this based on your needs
        return Ok("User added successfully");
    }

    [HttpPut("{userId}")]
    public IActionResult UpdateUser(string userId, [FromBody] UserViewModel userViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _userService.UpdateUser(userId , _mapper.Map<UserDto>(userViewModel));

        return Ok("User Update Seccufly ");
    }



    [HttpDelete("{userId}")]
    public IActionResult DeleteUser(string userId)
    {
        var existingUserDto = _userService.GetUserById(userId);

        if (existingUserDto == null)
        {
            return NotFound(); // Or return a specific error response
        }

        _userService.DeleteUser(userId);

        return NoContent();
    }
}

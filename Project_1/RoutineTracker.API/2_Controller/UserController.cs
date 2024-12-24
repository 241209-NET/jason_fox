using Microsoft.AspNetCore.Mvc;
using RoutineTracker.API.DTO;
using RoutineTracker.API.Service;

namespace RoutineTracker.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public IActionResult CreateUser([FromBody] UserInDTO newUser)
    {
        var user = _userService.CreateUser(newUser);
        return CreatedAtAction("User Created", user);
    }

    [HttpPost("authenticate")]
    public IActionResult AuthenticateUser([FromBody] UserInDTO user)
    {
        var authenticatedUser = _userService.AuthenticateUser(user);
        if (authenticatedUser == null)
        {
            return NotFound();
        }
        return Ok(authenticatedUser);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUserById(int id)
    {
        var user = _userService.DeleteUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}
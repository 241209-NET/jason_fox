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
    public IActionResult CreateUser(UserInDTO newUser)
    {
        var user = _userService.CreateUser(newUser);
        return Ok(user);
    }

    [HttpPost("authenticate")]
    public IActionResult AuthenticateUser(UserInDTO user)
    {
        var authenticatedUser = _userService.AuthenticateUser(user);
        if (authenticatedUser == null)
        {
            return Unauthorized();
        }
        return Ok(authenticatedUser);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUserById(int id)
    {
        var user = _userService.DeleteUserById(id);
        if (user == null)
        {
            return BadRequest();
        }
        return Ok(user);
    }

    [HttpDelete]
    public IActionResult DeleteAllUsers()
    {
        var users = _userService.DeleteAllUsers();
        return Ok(users);
    }    
}
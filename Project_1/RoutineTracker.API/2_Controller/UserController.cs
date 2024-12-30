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
        try
        {
            var user = _userService.CreateUser(newUser);
            return Ok(user);
        }
        catch (Exception e) { 
            Console.Error.WriteLine(e.GetType().Name);
            return Conflict("Username already exists");
        }
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return BadRequest("User not found");
        }
        return Ok(user);
    }

    // TODO: Fix this route
    [HttpPost("authenticate")]
    public IActionResult AuthenticateUser(UserInDTO user)
    {
        var authenticatedUser = _userService.AuthenticateUser(user);
        if (authenticatedUser == null)
        {
            return Unauthorized("Invalid login credentials");
        }
        return Ok(authenticatedUser);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUserById(int id)
    {
        var user = _userService.DeleteUserById(id);
        if (user == null)
        {
            return BadRequest("User not found");
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
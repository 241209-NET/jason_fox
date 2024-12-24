using RoutineTracker.API.Model;

namespace RoutineTracker.API.DTO;

public class UserInDTO
{
    public required string Username { get; set; }
    public required string Password { get; set; }

    public User ToUser()
    {
        return new User
        {
            Username = this.Username,
            Password = this.Password
        };
    }
}
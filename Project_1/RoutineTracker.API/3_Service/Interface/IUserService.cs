using RoutineTracker.API.DTO;
using RoutineTracker.API.Model;

namespace RoutineTracker.API.Service;

public interface IUserService
{
    User CreateUser(UserInDTO newUser);
    User? AuthenticateUser(UserInDTO user);
    User? DeleteUserById(int id);
    IEnumerable<User> DeleteAllUsers();
}
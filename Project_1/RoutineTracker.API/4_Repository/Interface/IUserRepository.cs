using RoutineTracker.API.Model;

namespace RoutineTracker.API.Repository;

public interface IUserRepository
{
    User CreateUser(User newUser);
    User? AuthenticateUser(User user);
    User? DeleteUserById(int id);
}
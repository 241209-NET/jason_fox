using RoutineTracker.API.Model;

namespace RoutineTracker.API.Repository;

public interface IUserRepository
{
    User CreateUser(User newUser);
    IEnumerable<User> GetAllUsers();
    User? GetUserById(int id);
    User? GetUserByCredentials(User user);
    User? DeleteUserById(int id);
    IEnumerable<User> DeleteAllUsers();
}
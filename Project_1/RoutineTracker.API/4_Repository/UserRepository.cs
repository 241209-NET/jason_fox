using RoutineTracker.API.Data;
using RoutineTracker.API.Model;

namespace RoutineTracker.API.Repository;

public class UserRepository : IUserRepository
{
    private readonly RoutineTrackerContext _routineTrackerContext;
    public UserRepository(RoutineTrackerContext routineTrackerContext)
    {
        _routineTrackerContext = routineTrackerContext;
    }

    public User CreateUser(User newUser)
    {
        _routineTrackerContext.Users.Add(newUser);
        _routineTrackerContext.SaveChanges();
        return newUser;
    }

    public User? GetUserByCredentials(User user)
    {
        return _routineTrackerContext.Users.Select(u => u).Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
    }

    public User? DeleteUserById(int id)
    {
        var user = _routineTrackerContext.Users.Find(id);
        if (user == null) return null;
        _routineTrackerContext.Users.Remove(user);
        _routineTrackerContext.SaveChanges();
        return user;
    }

    public IEnumerable<User> DeleteAllUsers()
    {
        var users = _routineTrackerContext.Users.Select(u => u);
        _routineTrackerContext.Users.RemoveRange(users);
        _routineTrackerContext.SaveChanges();
        return users;
    }
}
using RoutineTracker.API.DTO;
using RoutineTracker.API.Model;
using RoutineTracker.API.Repository;
using RoutineTracker.API.Utilities;

namespace RoutineTracker.API.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User CreateUser(UserInDTO newUser)
    {
        var user = newUser.ToUser();
        user.Password = Crypto.HashPassword(user.Password);
        return _userRepository.CreateUser(user);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    public User? GetUserById(int id)
    {
        return _userRepository.GetUserById(id);
    }

    public User? AuthenticateUser(UserInDTO user)
    {
        var userToAuthenticate = user.ToUser();
        var existingUser = _userRepository.GetUserByUsername(userToAuthenticate.Username);
        if (existingUser == null) return null;
        if (!Crypto.ComparePasswords(userToAuthenticate.Password, existingUser.Password)) return null;
        return existingUser;
    }

    public User? DeleteUserById(int id)
    {
        return _userRepository.DeleteUserById(id);
    }

    public IEnumerable<User> DeleteAllUsers()
    {
        return _userRepository.DeleteAllUsers();
    }
}
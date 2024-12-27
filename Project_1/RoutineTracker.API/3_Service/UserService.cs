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

    public User? AuthenticateUser(UserInDTO user)
    {
        var userToAuthenticate = user.ToUser();
        userToAuthenticate.Password = Crypto.HashPassword(userToAuthenticate.Password);
        return _userRepository.GetUserByCredentials(userToAuthenticate);
    }

    public User? DeleteUserById(int id)
    {
        return _userRepository.DeleteUserById(id);
    }
}
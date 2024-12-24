using RoutineTracker.API.DTO;
using RoutineTracker.API.Model;
using RoutineTracker.API.Repository;

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
        return _userRepository.CreateUser(user);
    }

    public User? AuthenticateUser(UserInDTO user)
    {
        var userToAuthenticate = user.ToUser();
        return _userRepository.AuthenticateUser(userToAuthenticate);
    }

    public User? DeleteUserById(int id)
    {
        return _userRepository.DeleteUserById(id);
    }
}
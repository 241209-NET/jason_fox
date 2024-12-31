using RoutineTracker.API.Model;
using RoutineTracker.API.DTO;
using RoutineTracker.API.Repository;
using RoutineTracker.API.Service;
using Moq;

namespace RoutineTracker.TEST;

public class UserDbFixture : IDisposable
{
    public Mock<IUserRepository> MockRepo { get; private set; }
    public UserService UserService { get; private set; }

    public UserDbFixture()
    {
        var user = new User
        {
            Id = 1,
            Username = "test",
            // Password is hashed "password"
            Password = "10000$2uR1L/e5wiGKQO5n8E4xCf4G0MoU0YR3fc9+iEYesfr9kfNo"
        };

        MockRepo = new Mock<IUserRepository>();
        MockRepo.Setup(repo => repo.GetUserByUsername(user.Username)).Returns(user);

        UserService = new UserService(MockRepo.Object);
    }

    public void Dispose()
    {
    }
}

public class UserServiceTests : IClassFixture<UserDbFixture>
{
    public UserDbFixture fixture;

    public UserServiceTests(UserDbFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void TestAuthenticateUserValidPassword()
    {
        // Arrange
        var loginUser = new UserInDTO
        {
            Username = "test",
            Password = "password"
        };

        // Act
        var result = fixture.UserService.AuthenticateUser(loginUser);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void TestAuthenticateUserInvalidPassword()
    {
        // Arrange
        var loginUser = new UserInDTO
        {
            Username = "test",
            Password = "invalid"
        };

        // Act
        var result = fixture.UserService.AuthenticateUser(loginUser);

        // Assert
        Assert.Null(result);
    }
}
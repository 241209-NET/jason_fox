using RoutineTracker.API.Model;
using RoutineTracker.API.DTO;
using RoutineTracker.API.Repository;
using RoutineTracker.API.Service;
using Moq;
using RoutineTracker.API.Utilities;

namespace RoutineTracker.TEST;

public class UserDbFixture : IDisposable
{
    public Mock<IUserRepository> MockRepo { get; private set; }
    public UserService UserService { get; private set; }
    public List<User> UserList { get; private set; } = new List<User>();
    public User TestUser { get; private set; }

    public UserDbFixture()
    {
        TestUser = new User
        {
            Id = 1,
            Username = "test",
            // Password is hashed "password"
            Password = Crypto.HashPassword("password")
        };

        UserList.Add(TestUser);

        MockRepo = new Mock<IUserRepository>();

        // Create user
        MockRepo.Setup(repo => repo.CreateUser(It.IsAny<User>())).Callback((User u) => UserList.Add(u)).Returns(TestUser);

        // Get all users
        MockRepo.Setup(repo => repo.GetAllUsers()).Returns(UserList);

        // Get user by id
        MockRepo.Setup(repo => repo.GetUserById(TestUser.Id)).Returns(TestUser);

        // Get user by username
        MockRepo.Setup(repo => repo.GetUserByUsername(TestUser.Username)).Returns(TestUser);

        // Delete user
        MockRepo.Setup(repo => repo.DeleteUserById(TestUser.Id)).Returns(TestUser);

        // Delete all users
        MockRepo.Setup(repo => repo.DeleteAllUsers()).Returns(UserList);


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
    public void TestCreateUser()
    {
        // Arrange
        var newUser = new UserInDTO
        {
            Username = "test",
            Password = "password"
        };

        // Act
        var result = fixture.UserService.CreateUser(newUser);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(newUser.Username, result.Username);
        Assert.NotEqual(newUser.Password, result.Password);
    }

    [Fact]
    public void TestGetAllUsers()
    {
        // Act
        var result = fixture.UserService.GetAllUsers();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fixture.UserList.Count, result.Count());
    }

    [Fact]
    public void TestGetUserById()
    {
        // Act
        var result = fixture.UserService.GetUserById(fixture.TestUser.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fixture.TestUser.Id, result.Id);
    }

    [Fact] // TODO: Test is failing
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

    [Fact]
    public void TestDeleteUserById()
    {
        // Act
        var result = fixture.UserService.DeleteUserById(fixture.TestUser.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fixture.TestUser.Id, result.Id);
    }

    [Fact]
    public void TestDeleteAllUsers()
    {
        // Act
        var result = fixture.UserService.DeleteAllUsers();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}
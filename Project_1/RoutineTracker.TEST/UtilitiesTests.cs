using RoutineTracker.API.Utilities;

namespace RoutineTracker.TEST;

public class UtilitiesTests
{
    [Fact]
    public void TestHashPassword()
    {
        // Arrange
        var password = "password";
        var salt = Utilities.CreateSalt();
        var hashedPassword = Utilities.HashPassword(password, salt);

        // Act
        var result = Utilities.HashPassword(password, salt);

        // Assert
        Assert.Equal(hashedPassword, result);
    }
}
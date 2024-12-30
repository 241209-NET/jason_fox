using RoutineTracker.API.Utilities;

namespace RoutineTracker.TEST;

public class UtilitiesTests
{
    [Fact]
    public void TestHashPassword()
    {
        // Arrange
        var password = "password";

        // Act
        var result = Crypto.HashPassword(password);

        // Assert
        Assert.NotEqual(password, result);
    }

    [Fact]
    public void TestComparePasswords()
    {
        // Arrange
        var password = "password";
        var hashedPassword = Crypto.HashPassword(password);

        // Act
        var result = Crypto.ComparePasswords(password, hashedPassword);

        // Assert
        Assert.True(result);
    }
}
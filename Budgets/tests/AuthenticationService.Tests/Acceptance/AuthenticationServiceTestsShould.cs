using NSubstitute;

namespace AuthenticationService.Tests.Acceptance;

public class AuthenticationServiceTestsShould
{
    [Fact]
    public async Task ReturnEmail_When_GoogleOAuth2LoginIsSuccessful()
    {
        // Arrange
        var googleAuthService = Substitute.For<IGoogleAuthService>();
        var authorizationCode = "fakeAuthorizationCode";
        var expectedUserEmail = "user@example.com";

        // Act
        var emailFromGoogle = await googleAuthService.GetEmailFromGoogleAsync(authorizationCode);

        // Assert
        await googleAuthService.Received(1).GetEmailFromGoogleAsync(authorizationCode);
        Assert.Equal(expectedUserEmail, emailFromGoogle);
    }
}
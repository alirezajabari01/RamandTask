using Application.Contract.Users;
using Application.Contract.Users.Requests;
using Application.Users;
using Domain.Users;
using Domain.Users.Contracts;
using Moq;

namespace Application.Test;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepository = new();
    private readonly IAuthenticationService _authenticationService;

    public UserServiceTests()
    {
        _authenticationService = new AuthenticationService(_userRepository.Object);
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task LoginAsync_Must_Return_User_When_UserName_And_Password_Is_Correct()
    {
        var loginRequest = new LoginRequest
        (
            "alireza",
            "123"
        );

        var cancellationToken = CancellationToken.None;
        var user = new User("alireza", "123");
        _userRepository
            .Setup(repo => repo.FirstOrDefaultAsync(
                "sp_GetByUserNameAndPassword",
                It.IsAny<object>(),
                cancellationToken))
            .ReturnsAsync(user);

        var loginResponse = await _authenticationService.LoginAsync(loginRequest, cancellationToken);

        Assert.NotNull(loginResponse.Token);
        Assert.IsNotEmpty(loginResponse.Token);
    }

    [Test]
    public void LoginAsync_Must_Throw_Exception_When_UserName_Is_InCorrect()
    {
        var loginRequest = new LoginRequest
        (
            "incorrectUser",
            "1234"
        );

        var cancellationToken = CancellationToken.None;

        _userRepository
            .Setup(repo => repo.FirstOrDefaultAsync(
                "sp_GetByUserNameAndPassword",
                It.IsAny<object>(),
                cancellationToken))
            .ReturnsAsync((User)null);

        Assert.ThrowsAsync<NullReferenceException>(async () =>
            await _authenticationService.LoginAsync(loginRequest, cancellationToken)
        );
    }
}
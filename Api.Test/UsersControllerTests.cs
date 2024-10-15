using Application.Contract.Users;
using Application.Contract.Users.Responses;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Api.Test;

using Moq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class UsersControllerTests
{
    private WebApplicationFactory<Program> _factory;
    [SetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>();
    }
    [TearDown]
    public void Cleanup()
    {
        _factory?.Dispose();
    }
  
    [Test]
    public async Task GetAll_Should_Return_Users_When_Valid_Token()
    {
        // Arrange
        var validToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyaWQiOiI0IiwidXNlck5hbWUiOiJhbGlyZXphIiwibmJmIjoxNzI5MDA4MTUxLCJleHAiOjIwMTMwMDQ5NTAsImlhdCI6MTcyOTAwODE1MSwiaXNzIjoid3d3Lk9ubGluZUd5bS5pciIsImF1ZCI6Ind3dy5PbmxpbmVHeW0uaXIifQ.eoxQfSzwCNdJnB9T8IWy8S3k-wNaSDzuzvaNhFBuN-o";
        var userServiceMock = new Mock<IUserService>();
        var users = new List<GetAllUsersResponse>
        {
            new(1, "testUser")
        };

        userServiceMock.Setup(s => s.GetAllUsersAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(users);

        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IUserService>(sp => userServiceMock.Object);
            });
        }).CreateClient();

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(validToken);

        // Act
        var response = await client.GetAsync("api/v1/users");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        
        var responseData = await response.Content.ReadAsAsync<IEnumerable<GetAllUsersResponse>>(
            );
        responseData.ShouldNotBeNull();
        responseData.Count().ShouldBeGreaterThan(0);
    }
}
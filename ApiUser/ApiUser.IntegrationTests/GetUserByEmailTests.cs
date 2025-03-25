using ApiUser.Domain;
using FluentAssertions;
using System.Text.Json;
using Xunit;

namespace ApiUser.IntegrationTests;

[Collection(TestCollection.Name)]
public class GetUserByEmailTests
{
    private readonly IntegrationTestFixture _fixture;
    public GetUserByEmailTests(IntegrationTestFixture testFixture)
    {
        _fixture = testFixture;

        //TODO _fixture.DbSetup.Reset();
    }

    //[Fact]
    [Theory]
    [InlineData("igor@gmail.com")]
    [InlineData("yury@gmail.com")]
    public async Task GetUserByEmail_Return_User(string email)
    {
        _fixture.AddUser(new Domain.User
        {
            EMail = email,
            GivenName = "Igor",
            Surname = "Il",
            Age = 34,
            Country = "Germany",
            City = "Hamburg",
            Street = "Berner Chaussee",
            HouseNumber = 154,
            PostalCode = 22526,
            Password = "123456"
        });

        var client = _fixture.CreateClient();

        var response = await client.GetAsync($"/user/email/{email}");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync();
        var user = JsonSerializer.Deserialize<User>(content, new
            JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        user.EMail.Should().Be(email);

        //todo
    }

    [Theory]
    [InlineData("test@gmail.com")]
    public async Task GetUserByEmail_Return_Exception(string email)
    {
        //_fixture.AddUser(new Domain.User
        //{
        //    EMail = email,
        //    GivenName = "Igor",
        //    Surname = "Il",
        //    Age = 34,
        //    Country = "Germany",
        //    City = "Hamburg",
        //    Street = "Berner Chaussee",
        //    HouseNumber = 154,
        //    PostalCode = 22526,
        //    Password = "123456"
        //});

        var client = _fixture.CreateClient();

        var response = await client.GetAsync($"/user/email/{email}");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
    }
}

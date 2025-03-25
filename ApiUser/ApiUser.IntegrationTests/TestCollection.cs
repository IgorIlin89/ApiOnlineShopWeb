using Xunit;

namespace ApiUser.IntegrationTests;

[CollectionDefinition(Name)]
public class TestCollection : ICollectionFixture<IntegrationTestFixture>
{
    public const string Name = "ApiUser.TestCollection";
}

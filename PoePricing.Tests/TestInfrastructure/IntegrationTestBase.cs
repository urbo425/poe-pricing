using Xunit;

namespace PoePricing.Tests.TestInfrastructure
{
    public class IntegrationTestBase : IClassFixture<IntegrationTestFixture>
    {
        protected IntegrationTestFixture Fixture { get; }

        public IntegrationTestBase(IntegrationTestFixture fixture)
        {
            Fixture = fixture;
        }
    }
}
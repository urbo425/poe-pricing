using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using PoePricing.PoeModels;
using PoePricing.Services;
using PoePricing.Stashes;
using Xunit;

namespace PoePricing.Tests.Stashes
{
    public class GetStashTabsTests
    {
        [Fact]
        public async Task ShouldGetStashTabsFromPoeEndpointUsingGetStashTabsRequest()
        {
            var service = Substitute.For<IPoeApiService>();

            var request = new GetStashTabs.Request
            {
                AccountName = "SomeAccountName",
                PoeSessionId = "someId"
            };

            var sut = new GetStashTabs.Handler(service);

            await sut.Handle(request);
            await service.Received(1).GetStashTabs(request);
        }

        [Fact]
        public async Task ShouldConvertHttpMessageToGetStashTabsResponse()
        {
            var service = Substitute.For<IPoeApiService>();

            var request = new GetStashTabs.Request
            {
                AccountName = "SomeAccountName",
                PoeSessionId = "someId"
            };
            var expectedResponse = new GetStashTabs.Response
            {
                Tabs = new List<Tab>
                {
                    new Tab
                    {
                        Name = "some name",
                        Index = 0,
                        Type = "some type"
                    }
                }
            };
            service.GetStashTabs(request).Returns(CreateGetStashTabsHttpResponseMessage(expectedResponse));

            var sut = new GetStashTabs.Handler(service);
            var response = await sut.Handle(request);
            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task ShouldReturnNullIfServiceReturnsNull()
        {
            var service = Substitute.For<IPoeApiService>();

            var sut = new GetStashTabs.Handler(service);
            var response = await sut.Handle(new GetStashTabs.Request());
            response.Should().BeNull();
        }

        private HttpResponseMessage CreateGetStashTabsHttpResponseMessage(GetStashTabs.Response expectedResponse)
        {
            var jsonString = JsonSerializer.Serialize(expectedResponse);
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };
        }
    }
}

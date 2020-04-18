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
    public class GetStashItemsTests
    {
        [Fact]
        public async Task ShouldGetStashItemsFromPoeEndpointUsingGetStashTabItemsRequest()
        {
            var service = Substitute.For<IPoeApiService>();

            var request = new GetStashTabItems.Request
            {
                AccountName = "SomeAccountName",
                PoeSessionId = "someId",
                TabIndex = "1"
            };

            var sut = new GetStashTabItems.Handler(service);

            await sut.Handle(request);
            await service.Received(1).GetStashTabItems(request);
        }

        [Fact]
        public async Task ShouldConvertNameProperty()
        {
            var service = Substitute.For<IPoeApiService>();

            var request = new GetStashTabItems.Request
            {
                AccountName = "SomeAccountName",
                PoeSessionId = "someId",
                TabIndex = "1"
            };
            var expectedResponse = new GetStashTabItems.Response
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "some name"
                    }
                }
            };
            service.GetStashTabItems(request).Returns(CreateGetStashTabItemsHttpResponseMessage(expectedResponse));

            var sut = new GetStashTabItems.Handler(service);
            var response = await sut.Handle(request);
            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task ShouldReturnNullIfServiceReturnsNull()
        {
            var service = Substitute.For<IPoeApiService>();

            var sut = new GetStashTabItems.Handler(service);
            var response = await sut.Handle(new GetStashTabItems.Request());
            response.Should().BeNull();
        }

        private HttpResponseMessage CreateGetStashTabItemsHttpResponseMessage(GetStashTabItems.Response expectedResponse)
        {
            var jsonString = JsonSerializer.Serialize(expectedResponse);
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };
        }
        private static GetStashTabItems.Response CreateGetStashTabItemsResponse()
        {
            return new GetStashTabItems.Response
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "some name",
                        // Id = "some id",
                        // ImplicitMods = new List<string>
                        // {
                        //     "mod1",
                        //     "mod2"
                        // },
                        // ExplicitMods = new List<string>
                        // {
                        //     "mod1",
                        //     "mod2"
                        // },
                        // Height = 1,
                        // Width = 1,
                        // Icon = "some icon",
                        // Identified = true,
                        // ItemLevel = 75,
                        // ItemSockets = new List<ItemSocket>
                        // {
                        //     new ItemSocket
                        //     {
                        //         Attribute = "some attribute",
                        //         Group = 0,
                        //         SocketColor = "B"
                        //     }
                        // },
                        // League = "some league",
                        // TypeLine = "some type line",
                        // Properties = new List<ItemProperty>
                        // {
                        //     new ItemProperty
                        //     {
                        //         Name = "some property name",
                        //         Values = new List<string>
                        //         {
                        //             "24",
                        //             "0"
                        //         }
                        //     }
                        // },
                        // Requirements = new List<ItemProperty>
                        // {
                        //     new ItemProperty
                        //     {
                        //         Name = "some property name",
                        //         Values = new List<string>
                        //         {
                        //             "24",
                        //             "0"
                        //         }
                        //     }
                        // }
                    }
                }
            };
        }
    }
}
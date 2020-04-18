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
            var expectedResponse = CreateGetStashTabItemsResponse(name: "toad");
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

        [Fact]
        public async Task ShouldConvertIconProperty()
        {
            var service = Substitute.For<IPoeApiService>();

            var request = new GetStashTabItems.Request
            {
                AccountName = "SomeAccountName",
                PoeSessionId = "someId",
                TabIndex = "1"
            };
            var expectedResponse = CreateGetStashTabItemsResponse(icon: "img.someImage");
            service.GetStashTabItems(request).Returns(CreateGetStashTabItemsHttpResponseMessage(expectedResponse));

            var sut = new GetStashTabItems.Handler(service);
            var response = await sut.Handle(request);
            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task ShouldConvertTypeLineProperty()
        {

            var service = Substitute.For<IPoeApiService>();

            var request = new GetStashTabItems.Request
            {
                AccountName = "SomeAccountName",
                PoeSessionId = "someId",
                TabIndex = "1"
            };
            var expectedResponse = CreateGetStashTabItemsResponse(typeLine: "type line");
            service.GetStashTabItems(request).Returns(CreateGetStashTabItemsHttpResponseMessage(expectedResponse));

            var sut = new GetStashTabItems.Handler(service);
            var response = await sut.Handle(request);
            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task ShouldConvertImplicitProperty()
        {
            var service = Substitute.For<IPoeApiService>();

            var request = new GetStashTabItems.Request
            {
                AccountName = "SomeAccountName",
                PoeSessionId = "someId",
                TabIndex = "1"
            };
            var implicitMods = new List<string>
            {
                "mod1",
                "mod2"
            };
            var expectedResponse = CreateGetStashTabItemsResponse(implicitMods: implicitMods);
            service.GetStashTabItems(request).Returns(CreateGetStashTabItemsHttpResponseMessage(expectedResponse));

            var sut = new GetStashTabItems.Handler(service);
            var response = await sut.Handle(request);
            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task ShouldConvertExplicitProperty()
        {
            var service = Substitute.For<IPoeApiService>();

            var request = new GetStashTabItems.Request
            {
                AccountName = "SomeAccountName",
                PoeSessionId = "someId",
                TabIndex = "1"
            };
            var explicitMods = new List<string>
            {
                "mod1",
                "mod2"
            };
            var expectedResponse = CreateGetStashTabItemsResponse(explicitMods: explicitMods);
            service.GetStashTabItems(request).Returns(CreateGetStashTabItemsHttpResponseMessage(expectedResponse));

            var sut = new GetStashTabItems.Handler(service);
            var response = await sut.Handle(request);
            response.Should().BeEquivalentTo(expectedResponse);
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
        private static GetStashTabItems.Response CreateGetStashTabItemsResponse(string name = "some name", string icon = "icon url",
            string typeLine = "some type line", List<string> implicitMods = null, List<string> explicitMods = null)
        {
            return new GetStashTabItems.Response
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = name,
                        Icon = icon,
                        TypeLine = typeLine,
                        ImplicitMods = implicitMods,
                        ExplicitMods = explicitMods,
                        // Id = "some id",
                        // Height = 1,
                        // Width = 1,
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
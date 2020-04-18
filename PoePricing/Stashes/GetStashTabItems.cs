using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PoePricing.PoeModels;
using PoePricing.Services;

namespace PoePricing.Stashes
{
    public static class GetStashTabItems
    {
        public class Request : IRequest<Response>
        {
            public string AccountName { get; set; }

            public string PoeSessionId { get; set; }

            public string TabIndex { get; set; }
        }

        public class Response
        {
            [JsonPropertyName("items")]
            public List<Item> Items { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IPoeApiService _poeApiService;

            public Handler(IPoeApiService poeApiService)
            {
                _poeApiService = poeApiService;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
            {
                try
                {
                    var responseMessage = await _poeApiService.GetStashTabItems(request);
                    var content = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonSerializer.Deserialize<Response>(content);
                    return response;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
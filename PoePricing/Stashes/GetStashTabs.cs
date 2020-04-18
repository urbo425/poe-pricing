using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PoePricing.PoeModels;
using PoePricing.Services;

namespace PoePricing.Stashes
{
    public static class GetStashTabs
    {
        public class Request : IRequest<Response>
        {
            [Required] 
            public string AccountName { get; set; }

            [Required]
            public string PoeSessionId { get; set; }
        }
        public class Response
        {
            [JsonPropertyName("tabs")]
            public List<Tab> Tabs { get; set; }
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
                    var responseMessage = await _poeApiService.GetStashTabs(request);
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
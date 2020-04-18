using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using PoePricing.Stashes;

namespace PoePricing.Services
{
    public class PoeApiService : IPoeApiService
    {
        private readonly Uri _baseAddress;

        public PoeApiService()
        {
            _baseAddress = new Uri("https://www.pathofexile.com/character-window/");
        }

        public async Task<HttpResponseMessage> GetStashTabs(GetStashTabs.Request request)
        {
            var cookieContainer = new CookieContainer();
            using var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            using var client = new HttpClient(handler) { BaseAddress = _baseAddress };
            cookieContainer.Add(_baseAddress, new Cookie("POESESSID", request.PoeSessionId));

            var response = await client.GetAsync($"get-stash-items?accountName={request.AccountName}&league=Delirium&tabs=1");

            return response;
        }

        public async Task<HttpResponseMessage> GetStashTabItems(GetStashTabItems.Request request)
        {
            var cookieContainer = new CookieContainer();
            using var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            using var client = new HttpClient(handler) { BaseAddress = _baseAddress };
            cookieContainer.Add(_baseAddress, new Cookie("POESESSID", request.PoeSessionId));

            var response = await client.GetAsync($"get-stash-items?accountName={request.AccountName}&league=Delirium&tabs=1&tabIndex={request.TabIndex}");

            return response;
        }
    }

    public interface IPoeApiService
    {
        Task<HttpResponseMessage> GetStashTabs(GetStashTabs.Request request);

        Task<HttpResponseMessage> GetStashTabItems(GetStashTabItems.Request request);
    }
}
using System.Collections.Generic;
using System.Net.Http;

namespace PoePricing.Services
{
    public class PoeApiService
    {
        public readonly HttpClient client;

        public PoeApiService(HttpClient client)
        {
            this.client = client;
        }

        
    }

    interface IPoeApiService
    {
        
    }
}
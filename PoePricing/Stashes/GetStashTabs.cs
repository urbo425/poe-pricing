using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace PoePricing.Stashes
{
    public static class GetStashTabs
    {
        public class Request : IRequest<List<string>>
        {

        }

        public class Handler : IRequestHandler<Request, List<string>> {
            public async Task<List<string>> Handle(Request request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
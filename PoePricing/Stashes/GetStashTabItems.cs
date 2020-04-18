using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace PoePricing.Stashes
{
    public static class GetStashTabItems
    {
        public class Request : IRequest<Response>
        {
            public string TabIndex { get; set; }
        }

        public class Response
        {

        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
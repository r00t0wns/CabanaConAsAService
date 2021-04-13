using MediatR;
using NodaTime;
using Ordering.Application.Responses;

namespace Ordering.Application.Queries
{
    public class IsItCabanaConTimeYetQuery : IRequest<IsItCabanaConTimeYetResponse>
    {
        public IsItCabanaConTimeYetQuery(LocalDateTime currentTime)
        {
            CurrentTime = currentTime;
        }

        public LocalDateTime CurrentTime { get; }
    }
}
using MediatR;
using NodaTime;
using CabanaConAsAService.Application.Responses;

namespace CabanaConAsAService.Application.Queries
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
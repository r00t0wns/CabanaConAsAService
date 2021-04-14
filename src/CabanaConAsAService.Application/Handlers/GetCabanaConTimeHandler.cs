using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NodaTime;
using CabanaConAsAService.Application.Queries;
using CabanaConAsAService.Application.Responses;

namespace CabanaConAsAService.Application.Handlers
{
    public class GetCabanaConTimeHandler : IRequestHandler<IsItCabanaConTimeYetQuery, IsItCabanaConTimeYetResponse>
    {
        private readonly LocalDateTime _cabanaDateTime =
            new ZonedDateTime(SystemClock.Instance.GetCurrentInstant(),
                DateTimeZoneProviders.Tzdb["America/Los_Angeles"]).WithZone(DateTimeZone.Utc).LocalDateTime;

        public Task<IsItCabanaConTimeYetResponse> Handle(IsItCabanaConTimeYetQuery request,
            CancellationToken cancellationToken)
        {
            var currentTime = request.CurrentTime;
            var timeLeft = Period.Between(currentTime, _cabanaDateTime);

            var response = new IsItCabanaConTimeYetResponse {IsItCabanaConTimeYet = timeLeft.Ticks <= 0};

            return Task.FromResult(response);
        }
    }
}
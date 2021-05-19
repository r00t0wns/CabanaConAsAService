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
            new(2021, 08, 05, 0, 0, 0);

        public Task<IsItCabanaConTimeYetResponse> Handle(IsItCabanaConTimeYetQuery request,
            CancellationToken cancellationToken)
        {
            var currentTime = request.CurrentTime;
            var timeLeft = Period.Between(currentTime, _cabanaDateTime);

            var response = new IsItCabanaConTimeYetResponse
            {
                IsItCabanaConTimeYet = timeLeft.Ticks <= 0,
                TimeLeft = new TimeLeft
                {
                    Years = timeLeft.Years,
                    Months = timeLeft.Months,
                    Days = timeLeft.Days,
                    Hours = (int)timeLeft.Hours,
                    Minutes = (int)timeLeft.Minutes,
                    Seconds = (int)timeLeft.Seconds
                }
                
            };

            return Task.FromResult(response);
        }
    }
}

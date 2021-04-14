namespace CabanaConAsAService.Application.Responses
{
    public class IsItCabanaConTimeYetResponse
    {
        public bool IsItCabanaConTimeYet { get; set; }
        public TimeLeft TimeLeft { get; set; }
    }

    public class TimeLeft
    {
        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
    }
}
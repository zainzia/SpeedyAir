using SpeedyAir.Models;

namespace SpeedyAir.Services
{
    /// <summary>
    /// Flight Scheduler will schedule and provide the flights.
    /// </summary>
    public class FlightScheduler
    {
        private List<Flight> flights;

        public FlightScheduler() 
        {
            flights = new List<Flight>
            {
                new Flight
                {
                    Day = 1,
                    Number = 1,
                    Destination = "YYZ",
                },
                new Flight
                {
                    Day = 1,
                    Number = 2,
                    Destination = "YYC",
                },
                new Flight
                {
                    Day = 1,
                    Number = 3,
                    Destination = "YVR",
                },
                new Flight
                {
                    Day = 2,
                    Number = 4,
                    Destination = "YYZ",
                },
                new Flight
                {
                    Day = 2,
                    Number = 5,
                    Destination = "YYC",
                },
                new Flight
                {
                    Day = 2,
                    Number = 6,
                    Destination = "YVR",
                },
            };
        }

        /// <summary>
        /// Gets a list of the flights.
        /// </summary>
        /// <returns>A list of Flights.</returns>
        public List<Flight> GetSchedule()
        {
            return flights;
        }
    }
}

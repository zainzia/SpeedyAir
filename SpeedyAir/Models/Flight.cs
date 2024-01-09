namespace SpeedyAir.Models
{
    public class Flight
    {
        /// <summary>
        /// Destination of the Flight.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Flight Number on the day of the Flight.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Day of the Flight.
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Number of Orders the flight has.
        /// </summary>
        public int NumberOfOrders { get; set; } = 0;
    }
}

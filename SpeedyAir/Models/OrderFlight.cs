namespace SpeedyAir.Models
{
    public class OrderFlight
    {
        /// <summary>
        /// Flight for the order.
        /// </summary>
        public Flight? Flight { get; set; }

        /// <summary>
        /// Order.
        /// </summary>
        public Order Order { get; set; }
    }
}

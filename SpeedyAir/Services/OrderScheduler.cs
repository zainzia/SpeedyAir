using System.Text.Json;
using SpeedyAir.Models;

namespace SpeedyAir.Services
{
    /// <summary>
    /// Order Scheduler will obtain all orders and schedule them on the flights.
    /// </summary>
    public class OrderScheduler
    {
        private const string ordersFile = @"..\..\..\Data\coding-assigment-orders.json";
        private const string destination = "destination";
        private const int flightMaxCapacity = 20;

        /// <summary>
        /// Gets all the orders from the file.
        /// </summary>
        /// <returns>A List of the Orders.</returns>
        private List<Order>? GetOrders()
        {
            if (!File.Exists(ordersFile))
            {
                return null;
            }

            var ordersText = File.ReadAllText(ordersFile);
            var ordersObject = JsonSerializer.Deserialize<JsonElement>(ordersText).EnumerateObject();

            var orders = new List<Order>();
            foreach (var orderObjectProperty in ordersObject)
            {
                var orderNumber = orderObjectProperty.Name;
                var orderDestination = orderObjectProperty.Value.GetProperty(destination).GetString();

                if (orderDestination == null)
                {
                    continue;
                }

                orders.Add(new Order
                {
                    Number = orderNumber,
                    Destination = orderDestination
                });
            }

            return orders;
        }

        /// <summary>
        /// Schedules all orders based on the flight schedule.
        /// </summary>
        /// <returns></returns>
        public List<OrderFlight>? ScheduleOrders()
        {
            var flightScheduler = new FlightScheduler();
            var flightSchedule = flightScheduler.GetSchedule();
            if (flightSchedule == null)
            {
                return null;
            }
            
            var orders = GetOrders();
            if (orders == null)
            {
                return null;
            }
            
            var orderFlights = new List<OrderFlight>();
            foreach (var order in orders)
            {
                var flight = flightSchedule.FirstOrDefault(x => x.Destination == order.Destination && x.NumberOfOrders < flightMaxCapacity);

                if (flight != null)
                {
                    flight.NumberOfOrders++;
                }

                orderFlights.Add(new OrderFlight
                {
                    Flight = flight,
                    Order = order
                });
            }

            return orderFlights;
        }
    }
}

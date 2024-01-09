using SpeedyAir.Services;

namespace SpeedyAir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintFlightAndOrderSchedule();
        }

        /// <summary>
        /// Prints the Flight and the Order Schedule.
        /// </summary>
        private static void PrintFlightAndOrderSchedule()
        {
            var flightSchedule = new FlightScheduler();
            var flights = flightSchedule.GetSchedule();
            if (flights == null)
            {
                Console.WriteLine("No flights scheduled!");
                return;
            }

            foreach(var flight in flights)
            {
                Console.WriteLine($"Flight: {flight.Number}, departure: YUL, arrival: {flight.Destination}, day: {flight.Day}");
            }

            var orderScheduler = new OrderScheduler();
            var scheduledOrders = orderScheduler.ScheduleOrders();
            if (scheduledOrders== null)
            {
                Console.WriteLine("No Scheduled orders found!");
                return;
            }

            foreach(var scheduledOrder in scheduledOrders)
            {
                if (scheduledOrder.Flight == null)
                {
                    Console.WriteLine($"order: {scheduledOrder.Order.Number}, flightNumber: not scheduled");
                }
                else
                {
                    Console.WriteLine($"order: {scheduledOrder.Order.Number}, flightNumber: {scheduledOrder.Flight.Number}, departure: YUL, arrival:{scheduledOrder.Order.Destination}, day:{scheduledOrder.Flight.Day}");
                }
            }
        }
    }
}

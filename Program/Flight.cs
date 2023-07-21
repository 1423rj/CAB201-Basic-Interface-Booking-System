using System;

namespace UserInterface
{
    /// <summary>
    /// The Abstract Flight Class. 
    /// </summary>
    abstract class Flight
    {
        /// <summary>
        /// Amount of customers allowed on a plane
        /// </summary>
        public int allowedattendees  { get; }
        /// <summary>
        /// current count of customers on a plane
        /// </summary>
        public int currentattendees { get; set; }
        /// <summary>
        /// The Distance.
        /// </summary>
        public double Distance { get; }
        /// <summary>
        /// The Destination.
        /// </summary>
        public string Destination { get; }
        /// <summary>
        /// The place of departure
        /// </summary>
        public string Departure { get; }
        /// <summary>
        /// The Time of departure
        /// </summary>
        public string Departuretime { get; set; }
        /// <summary>
        /// The planes No.
        /// </summary>
        public int Flightnumber { get; }
        /// <summary>
        /// The type of Plane
        /// </summary>
        public string Flight_type { get; set; }

        /// <summary>
        /// Holds a Flight.
        /// </summary>
        /// <param name="allowedattendees">Amount of customers allowed on a plane</param>
        /// <param name="currentattendees">current count of customers on a plane</param>
        /// <param name="Distance">The Distance.</param>
        /// <param name="flight_type">The type of plane</param>
        /// <param name="destination">The Destination.</param>
        /// <param name="departure">Where the Plane leaves</param>
        /// <param name="departuretime">When the Plane leaves</param>
        /// <param name="flightnumber">No. of plane</param>
        public Flight(string flight_type, double Distance, string destination, string departure, string departuretime, int flightnumber, int allowedattendees, int currentattendees)
        {
            
            this.Flight_type = flight_type;
            this.Distance = Distance;
           this.Destination = destination;
            this.Departure = departure;
            this.Departuretime = departuretime;
            this.Flightnumber = flightnumber;
        }
        /// <summary>
        /// Abstract initialiser to find cost of plane trip
        /// </summary>
        /// <returns>Returns price</returns>
        abstract public double GetCost();


        /// <summary>
        /// Abstract initialiser to find time of plane trip
        /// </summary>
        /// <returns>Returns Time in hours</returns>
        abstract public double DisplayTime();
    }


}
using System;


namespace UserInterface
{

    /// <summary>
    /// The Light Air Craft Flight Class. 
    /// </summary>

    class Lightaircraft : Flight
    {
        /// <summary>
        /// Holds a Light Flight.
        /// </summary>
        /// <param name="allowedattendees">Amount of customers allowed on a plane</param>
        /// <param name="currentattendees">current count of customers on a plane</param>
        /// <param name="Distance">The Distance.</param>
        /// <param name="flight_type">The type of plane</param>
        /// <param name="destination">The Destination.</param>
        /// <param name="departure">Where the Plane leaves</param>
        /// <param name="departuretime">When the Plane leaves</param>
        /// <param name="flightnumber">No. of plane</param>
        public Lightaircraft(string flight_type, double Distance, string destination, string departure, string departuretime, int flightnumber, int allowedattendees, int currentattendees) : base(flight_type, Distance, destination, departure, departuretime, flightnumber, allowedattendees, currentattendees)
        {
            
        }
        /// <summary>
        /// Calculates the time needed to complete a plane trip
        /// </summary>
        /// <returns>Returns Time in hours</returns>
        public override double DisplayTime()
        {
            return (Distance / 800 + 0.5);

        }
        /// <summary>
        /// Calculates the cost of a plane trip
        /// </summary>
        /// <returns>Returns price</returns>
        public override double GetCost()
        {
            return 250 * Distance / 800;


        }



    }
}
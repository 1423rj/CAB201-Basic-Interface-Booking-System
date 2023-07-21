using System;

namespace UserInterface
{
    /// <summary>
    /// Class to represent a Customer with a flight. 
    /// </summary>
    class FlightCustomer : Customer
    {
        /// <summary>
        /// Which flight the customer is on
        /// </summary>
        public int Flightnumber { get; }
        /// <summary>
        /// Current amount of people on said plane
        /// </summary>

        public int Currentattendees { get; set; }
        public FlightCustomer(string name, string email, string address, string mobile, int flightnumber, int customernumber, int currentattendees) : base(name, email, address, mobile, customernumber)
        {
            this.Flightnumber = flightnumber;
            this.Currentattendees = currentattendees;
        }

    }
}
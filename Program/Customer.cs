using System;
using System.Collections.Generic;


namespace UserInterface
{
    /// <summary>
    /// Class to represent a customer. 
    /// </summary>
    class Customer
    {
        /// <summary>
        /// Name of a Customer
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Enail of a Customer
        /// </summary>
        public string Email { get; }
        /// <summary>
        /// Address of a Customer
        /// </summary>
        public string Address { get; }
        /// <summary>
        /// Mobile of a Customer
        /// </summary>
        public string Mobile { get; private set; }
        /// <summary>
        /// Customers No.
        /// </summary>

        public int CustomerNumber { get; }

        /// <summary>
        /// Holds a customer.
        /// </summary>
        /// <param name="name">Name of the customer</param>
        /// <param name="email">Email of the customer</param>
        /// <param name="address">Home Address of the customer</param>
        /// <param name="mobile">Mobile Number of the customer</param>
        /// <param name="customernumber">Customers number in order of when added to the system</param>

        public Customer(string name, string email, string address, string mobile, int customernumber)
        {
            this.Name = name;
            this.Email = email;
            this.Address = address;
            this.Mobile = mobile;
            this.CustomerNumber = customernumber;

        }

        public override string ToString()
        {
            return this.Name + " " + this.Email + " " + this.Address + " " + this.Mobile;
        }


    }

}
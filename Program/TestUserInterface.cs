using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UserInterface
{
    class TestUserInterface
    {
        /// <summary>
        /// The main program.
        /// </summary>
        static void Main(string[] args)
        {

            const int AddLightFlight = 1, AddHelicopterFlight = 2, Viewcurrentflights = 3, AddCustomer = 5, Viewbookings = 7, Addflyingservice = 6, viewcurrentflighttimes = 4, Logout = 8;
            //Initialises Classes, appends arrays to 100 to hold up to 100 of each type of customer or flight
            User user = new User();
            Flight[] flight = new Flight[100];
            int flights = 0;
            Customer[] customer = new Customer[100];
            HelicopterFlight[] helicopterFlights = new HelicopterFlight[100];
            FlightCustomer[] flightCustomer = new FlightCustomer[100];
            List<Customer> customerList = new List<Customer>();
            List<Flight> FlightList = new List<Flight>();
            List<FlightCustomer> FlyingList = new List<FlightCustomer>();
            int Customernumber = 0;
            string Name;
            string Email;
            string Address;
            string phone;
            user.loggedin = false;
                while (user.End == 0)
                {
                    user.Register(); 
                    if (user.loggedin == true)
                    {
                    //List of options for the user to pick.
                        Console.WriteLine("");
                        Console.WriteLine("1) Add a new Light aircraft flight");
                        Console.WriteLine("2) Add a new Helicopter  flight");
                        Console.WriteLine("3) View flights");
                        Console.WriteLine("4) View flight times");
                        Console.WriteLine("5) Register a customer");
                        Console.WriteLine("6) Add Customer flights");
                        Console.WriteLine("7) View Customer flights");
                        Console.WriteLine("8) Logout");
                        Console.WriteLine("");
                        user.errorcatcher();
                        int option = user.parsedinput;
                        Console.WriteLine("");
                        switch (option)
                        {

                            case AddLightFlight:
                                flights++;
                                Console.Write("Distance of Flight number {0}: ", flights);
                                user.errorcatcher();
                                int distance = user.parsedinput;
                            Console.Write("Departure place of Flight number {0}: ", flights);
                                string Departure = Console.ReadLine();
                                Console.Write("Destination of Flight number {0}: ", flights);
                                string Destination = Console.ReadLine();
                                Console.Write("Departure time of Flight number {0}: ", flights);
                                string departuretime = Console.ReadLine();
                                flight[flights] = new Lightaircraft("Light Air Craft", distance, Destination, Departure, departuretime, flights, 6, 0);
                                FlightList.Add(flight[flights]);
                                break;
                            case AddHelicopterFlight:
                                flights++;
                                Console.Write("Distance of Flight number {0}: ", flights);
                                user.errorcatcher();
                                distance = user.parsedinput;
                                Console.Write("Departure place of Flight number {0}: ", flights);
                                Departure = Console.ReadLine();
                                Console.Write("Destination of Flight number {0}: ", flights);
                                Destination = Console.ReadLine();
                                Console.Write("Departure time of Flight number {0}: ", flights);
                                departuretime = Console.ReadLine();
                                flight[flights] = new HelicopterFlight("Helicopter", distance, Destination, Departure, departuretime, flights, 2, 0);
                                FlightList.Add(flight[flights]);
                                break;
                            case Viewcurrentflights:

                                foreach (Flight c in FlightList)
                                {
                                    Console.WriteLine("Flight type: {0}, Distance: {1}, Destination: {2} - {3}", c.Flight_type, c.Distance, c.Destination, c.Departure);
                                }
                                break;

                            case AddCustomer:
                                Customernumber++;
                                Console.Write("Fullname: ");
                                Name = Console.ReadLine();
                                Console.Write("Email: ");
                                Email = Console.ReadLine();
                                Console.Write("Address: ");
                                Address = Console.ReadLine();
                                Console.Write("Mobile Number: ");
                                phone = Console.ReadLine();
                                customer[Customernumber] = new Customer(Name, Email, Address, phone, Customernumber);
                                customerList.Add(customer[Customernumber]);
                                Console.WriteLine("{0} successfully registered", Name);
                          

                                break;
                            case Addflyingservice:
                                foreach (Customer c in customerList)
                                {
                                    Console.WriteLine("Customer Number {4}: Name: {0}, Email: {1}, Address: {2}, Phone Number: {3}", c.Name, c.Email, c.Address, c.Mobile, c.CustomerNumber);
                                }
                                Console.Write("Enter the customer number: ");
                            //All chosenone integers represent which customer or flight the user has chosen
                                int chosenone = int.Parse(Console.ReadLine());
                                foreach (Flight c in FlightList)
                                {
                                    Console.WriteLine("Flight number {4}:    Flight type: {0}, Distance: {1}, Destination: {2} - {3}", c.Flight_type, c.Distance, c.Destination, c.Departure, c.Flightnumber);
                                }
                                Console.Write("Enter the Flight number: ");
                                int chosenone2 = int.Parse(Console.ReadLine());
                            //uses System.Linq to find specific instances throughout the created lists of desired results.

                                var result = from c in customerList
                                             where c.CustomerNumber == chosenone
                                             select c;

                                foreach (Customer c in result)
                                {
                                    var result2 = from s in FlightList
                                                  where s.Flightnumber == chosenone2
                                                  select s;

                                    foreach (Flight s in result2)
                                    {
                                        Console.WriteLine("");
                                        int i = 1;
                                    //adds an attendant to the flight.
                                        s.currentattendees = s.currentattendees + 1;
                                        flightCustomer[i] = new FlightCustomer(c.Name, c.Email, c.Address, c.Mobile, s.Flightnumber, c.CustomerNumber, s.currentattendees);


                                        if (s.Flight_type == "Light Air Craft")
                                        {
                                            if (s.currentattendees <= 6)
                                            {

                                                Lightaircraft Flightcost = new Lightaircraft(s.Flight_type, s.Distance, s.Destination, s.Departure, s.Departuretime, s.Flightnumber, 6, s.currentattendees);
                                                FlyingList.Add(flightCustomer[i]);
                                                Console.WriteLine("Customer number {0} has been added", chosenone);
                                                Console.WriteLine("");
                                                Console.WriteLine("Cost: " + Flightcost.GetCost());
                                            }
                                            else
                                            {
                                                Console.WriteLine("Too Many People Booked for this flight");
                                                Console.WriteLine("");
                                            }

                                        }
                                        else if (s.Flight_type == "Helicopter")
                                        {

                                            if (s.currentattendees <= 2)
                                            {
                                                FlyingList.Add(flightCustomer[i]);
                                                HelicopterFlight HeliFlightcost = new HelicopterFlight(s.Flight_type, s.Distance, s.Destination, s.Departure, s.Departuretime, s.Flightnumber, 2, s.currentattendees);
                                                Console.WriteLine("Customer number {0} has been added", chosenone);
                                                Console.WriteLine("");
                                                Console.WriteLine("Cost: " + HeliFlightcost.GetCost());
                                            }
                                            else
                                            {
                                                Console.WriteLine("Too Many People Booked for this flight");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Flights Available");
                                        }
                                    }
                                }
                                break;
                            case Viewbookings:

                                foreach (Flight c in FlightList)
                                {
                                    Console.WriteLine("Flight number {4}:    Flight type: {0}, Distance: {1}, Destination: {2} - {3}", c.Flight_type, c.Distance, c.Destination, c.Departure, c.Flightnumber);
                                }
                                Console.Write("Enter the Flight number: ");
                            user.errorcatcher();
                            int flightnumber = user.parsedinput;
                                var result3 = from c in FlyingList
                                              where c.Flightnumber == flightnumber
                                              select c;
                            
                            foreach (FlightCustomer c in result3)
                                {
                                    Console.WriteLine(c.Name, c.Currentattendees);        
                                } 
                            break;

                            case viewcurrentflighttimes:
                                foreach (Flight s in FlightList)
                                {
                                    Console.WriteLine();
                                    if (s.Flight_type == "Light Air Craft")
                                    {

                                        Flight Time = new Lightaircraft(s.Flight_type, s.Distance, s.Destination, s.Departure, s.Departuretime, s.Flightnumber, 6, s.currentattendees);


                                        Console.WriteLine(s.Flightnumber + ": Departure time is " + s.Departuretime + " and will take " + s.DisplayTime() + " hours to land");


                                    }
                                    else if (s.Flight_type == "Helicopter")
                                    {
                                        Flight Time = new HelicopterFlight(s.Flight_type, s.Distance, s.Destination, s.Departure, s.Departuretime, s.Flightnumber, 2, s.currentattendees);
                                        if (s.currentattendees == 0)
                                        {
                                            Console.WriteLine(s.Flightnumber + ": Departure time is " + s.Departuretime + " and will take " + Time.DisplayTime() + " hours to land");
                                        }
                                        else if (s.currentattendees == 1)
                                        {
                                            Console.WriteLine(s.Flightnumber + ": Departure time is " + s.Departuretime + " and will take " + Time.DisplayTime() + 0.25 + " hours to land");
                                        }
                                        else
                                        {
                                            Console.WriteLine(s.Flightnumber + ": Departure time is " + s.Departuretime + " and will take " + Time.DisplayTime() + 0.33 + " hours to land");
                                        }

                                    }

                                }
                                break;
                            case Logout:
                                user.Logout();
                                break;
                        }
                    }
                }
            }
        }
    }

using System;
using System.Collections.Generic;

namespace UserInterface
{
    /// <summary>
    /// Support method for creating a user and supporting a interactive menu,
    /// </summary>

        class User
        {
     
        /// <summary>
        /// Name of a User
        /// </summary>
        private string Name { get; set; }
        /// <summary>
        /// Email of a User
        /// </summary>
        private string Email { get; set; }
        /// <summary>
        /// Password of a User
        /// </summary>
        protected string Password { get; set; }
        /// <summary>
        /// Temporary Password to be matched by another password
        /// </summary>
        private bool temp = false;

        /// <summary>
        /// boolean of if the user is logged in
        /// </summary>
        public bool loggedin = false;
        /// <summary>
        /// Which option the user will pick in a list
        /// </summary>
        int option { set; get; }
        /// <summary>
        /// Int to represent whether the program should be terminated
        /// </summary>
        public int End = 0;
        /// <summary>
        /// Users choice for an option, used in error correction
        /// </summary>
        public int parsedinput = 0;
        /// <summary>
        /// Used to welcome the user
        /// </summary>
        private int firstlogin = 0;
        /// <summary>
        /// Class User.
        /// </summary>
        public User()
            {
               
            }
        /// <summary>
        /// Private method to get the password from a user
        /// </summary>
        
        private void CheckPassword()
            {
            Console.Write("Password: ");
            Password = "";

            try
                {
                    
                    do
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        // Backspace Should Not Work  
                        if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                        {
                            Password += key.KeyChar;
                            Console.Write("*");
                        }
                        else
                        {
                            if (key.Key == ConsoleKey.Backspace && Password.Length > 0)
                            {
                                Password = Password.Substring(0, (Password.Length - 1));
                                Console.Write("\b \b");
                            }
                            else if (key.Key == ConsoleKey.Enter)
                            {
                                if (string.IsNullOrWhiteSpace(Password))
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Empty value not allowed.");
                                    CheckPassword();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("");
                                    break;
                                }
                            }
                        }
                    } while (true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception detected: " + ex);
                }
            }
        /// <summary>
        /// Compares the users registered email and password to their input
        /// </summary>
        
        private void CompareUser()
        {
            Console.Write("Please Enter Your Email: ");
            string entereduser = Console.ReadLine();
            Console.Write("Please Enter Your Password: ");
            string temppass = Console.ReadLine();

            if (entereduser == Email && temppass == Password)
            {
                Console.WriteLine(" ");
                temp = true;

                
            }
            else
            {
                Console.WriteLine("Password or Username Incorrect");
                temp = false;
            }


        }
        /// <summary>
        /// Logs the user out of the system and returns to menu. Does not remove their registration though
        /// </summary>
        public void Logout()
        {
            Console.WriteLine("Logging Out");
            temp = false;
            loggedin = false;
        }
        /// <summary>
        /// Register a user
        /// </summary>
        public void Register()
        {
            if (loggedin == false)
            {
                Console.WriteLine("Please Select an Action");
                Console.WriteLine("1) Register");
                Console.WriteLine("2) Log in");
                Console.WriteLine("3) Exit");
                Console.WriteLine("");
                errorcatcher();
                option = parsedinput;
                if (option == 1)
                {
                    Console.Write("Fullname: ");
                    Name = Console.ReadLine();
                    Console.Write("Email: ");
                    Email = Console.ReadLine();
                    CheckPassword();
                    Console.WriteLine("{0} Successfully registered", Name);
                }
                
                    else if (option == 2)
                    {
                        CompareUser();
                    }
                    else if (option == 3)
                    {
                        End = 1;
                    }
                else
                {
                    Console.WriteLine("Please enter a valid character");
                }
            }

            if (temp == true)
            {
                loggedin = true;
                if (firstlogin == 0)
                {
                    Console.WriteLine("Welcome {0}", Name);
                    firstlogin = 1;
                }

            }     
        }
        /// <summary>
        /// Overrides the ToString method with Name
        /// </summary>
        /// <returns>Returns the name of the User</returns>
        public override string ToString()
        {
            return  this.Name;
        }
        /// <summary>
        /// Catches errors in user input, if the input is no a integer, repeat until the input is an integer
        /// </summary>
        public void errorcatcher()
        {
            int x = 0;
            while (x == 0)
            {
                string input = Console.ReadLine();
                try
                {

                    parsedinput = int.Parse(input);
                    x = 1;

                }
                catch (FormatException)
                {
                    Console.WriteLine("Input was non-numeric");
                    Console.Write("Please reinput your value: ");

                }
            }
            
        }
        

    }
    }

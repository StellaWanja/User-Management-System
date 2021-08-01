using System;
using System.ComponentModel.DataAnnotations; //use for email validation
using System.Text.RegularExpressions; //use for Regex
using System.Collections.Generic;

namespace ManagementLogic
{
    public class Functions
    {
        //check if the input for selection is valid
        //string input is the input the user adds from Console.ReadLine()
        //since the return value should be int, use public static int
        public static int IsInputValid(string input)
        {
            //holds the value of the string input converted to an int
            int value;
            //if the value is an int, return true, else false if not an int
            bool isValid = Int32.TryParse(input, out value);
            //if isValid is false, return -1 as consoleInput
            if (!isValid)
            {
                return -1;
            }
            //if isValid is true but the int value is greater than 4 and less than 0
            //then return -1 as consoleInput
            else if (value < 0 || value > 4)
            {
                return -1;
            }
            //if isValid is true and the int value is within range 0-4
            //return the value which equals consoleInput
            else
            {
                return value;
            }
        }

        //validate the user info inputed
        public static void UserInfo(string firstName, string lastName, string email, string favouriteFood)
        {
            //use a try\catch to catch any exceptions that may occur
            try
            {
                //check if the input is empty
                //if empty, throw an exception error message that has been inputed below
                if (firstName == "") throw new ArgumentException("Kindly input your first name", "firstName");
                if (lastName == "") throw new ArgumentException("Kindly input your last name", "lastName");
                if (email == "") throw new ArgumentException("Kindly input your email", "email");
                if (favouriteFood == "") throw new ArgumentException("Kindly input your favourite food", "favouriteFood");

                //use regex to check if firstname, lastname, favouritefood has special characters
                //regexItem checks for characters that are either lowercase or uppercase
                var regexItem = new Regex("^[a-zA-Z]*$");
                //if regexItem doesnot match input, return error message
                if (!regexItem.IsMatch(firstName) || !regexItem.IsMatch(lastName) || !regexItem.IsMatch(favouriteFood))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new FormatException("Invalid input. Kindly avoid using special characters.");
                }

                //validate if email is a vaild email (in correct format)
                //by using EmailAddressAttribute()
                var validateEmail = new EmailAddressAttribute();
                if (!validateEmail.IsValid(email))
                {
                    //if email is invalid, show error message in red
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new FormatException("Invalid email. Please enter a valid email");
                }
            }
            catch (FormatException ex)
            {
                //if an format exception is found, eg input contains special characters
                //throw exception message in red that have been written above
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh no! Something went wrong!");
                throw new FormatException(ex.Message);
            }
            catch (ArgumentException ex)
            {
                //if an argument exception is found, eg an empty string
                //throw exception message in red that have been written above
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh no! Something went wrong!");
                throw new ArgumentException(ex.Message);
            }
            catch (Exception e)
            {
                //catches all unpredicted errors and clear console
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception(e.Message);
            }
        }

        //create an instance of the UsersQueue which will be of type string
        public static UsersQueue<string> users = new UsersQueue<string>();

        //add the user to the queue by using enqueue method
        public static void AddUser(string firstName, string lastName, string email, string favouriteFood)
        {
            //invoke Generic Class Queue
            users.Enqueue(firstName);
            users.Enqueue(lastName);
            users.Enqueue(email);
            users.Enqueue(favouriteFood);
        }

        //display the user 
        public static void DisplayUser()
        {
            //fetch any data from UsersData.txt and read
            FileText.ReadFileAsync();
            //display the added user that is not yet saved to the file
            users.Print();
        }

        //remove the user using dequeue method
        public static void RemoveUser()
        {
            users.Dequeue();
            users.Dequeue();
            users.Dequeue();
            users.Dequeue();
        }
    }
}
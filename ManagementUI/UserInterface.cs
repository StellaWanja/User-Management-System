using System;
using ManagementLogic;

namespace ManagementUI
{
    public class UserInterface
    {
        //FileText.ReadFileAsync();
        //Handles the console info to be displayed
        public static void Display()
        {
            //call the properties from Properties.cs to be used here
            Properties user = new Properties();
            string firstName = user.FirstName;
            string lastName = user.LastName;
            string email = user.EmailAddress;
            string favouriteFood = user.FavouriteFood;

            //ensure app is always running unless if exit button is selected
            //using while loop
            bool appIsRunning = true;
            //this will check if data had been saved initially
            //to avoid saving duplicate items
            //when saving changes and leaving the app
            bool fileWasSaved = false;
            while (appIsRunning)
            {
                Console.WriteLine("Welcome to my User Management App");

                Console.WriteLine("Enter:");
                Console.WriteLine("1 to Add User");
                Console.WriteLine("2 to Remove User");
                Console.WriteLine("3 to Save Changes");
                Console.WriteLine("4 to Display Users");
                Console.WriteLine("0 to Exit");

                //hold the value of the input after it has been validated
                var consoleInput = Functions.IsInputValid(Console.ReadLine());
                //if the input was not an int or 0-5, return an error
                if (consoleInput == -1)
                {
                    
                    Console.WriteLine("Please enter a valid input from the selection");
                }
                else
                //if the input was an input of the selected range
                //run the case depending on the input selected
                {
                    switch (consoleInput)
                    {
                        //add user to queue
                        case 1:
                            try
                            {
                                Console.WriteLine("Please enter your first name");
                                firstName = Console.ReadLine();
                                Console.WriteLine("Please enter your last name");
                                lastName = Console.ReadLine();
                                Console.WriteLine("Please enter your email address");
                                email = Console.ReadLine();
                                Console.WriteLine("Please enter your favourite food");
                                favouriteFood = Console.ReadLine();
                                Functions.UserInfo(firstName, lastName, email, favouriteFood);
                                Console.WriteLine("User has been added successfully");
                                Functions.AddUser(firstName, lastName, email, favouriteFood);
                            }
                            catch (FormatException ex)
                            {
                                //if an argument exception is found, eg an empty string
                                //throw exception message in red that have been written above
                                Console.ForegroundColor = ConsoleColor.Red;
                                throw new FormatException(ex.Message);
                            }
                            catch (ArgumentException ex)
                            {
                                //if an argument exception is found, eg an empty string
                                //throw exception message in red that have been written above
                                Console.ForegroundColor = ConsoleColor.Red;
                                throw new ArgumentException(ex.Message);
                            }
                            catch (Exception e)
                            {
                                //catches all unpredicted errors and clear console
                                Console.ForegroundColor = ConsoleColor.Red;
                                throw new Exception(e.Message);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        //remove user from queue               
                        case 2:
                        //call the dequeue function
                            Functions.RemoveUser();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        //save changes
                        case 3:
                            //call the writetofile function
                            FileText.WriteFileAsync(firstName, lastName, email, favouriteFood);
                            fileWasSaved = true;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        //display the user
                        case 4:
                        //call the display function
                            Functions.DisplayUser();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 0:
                            //if file had not been initially saved
                            //ie, case 3 was not selected
                            //then save the data
                            if(fileWasSaved == false)
                            {
                                FileText.WriteFileAsync(firstName, lastName, email, favouriteFood);
                            }
                            appIsRunning = false;
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }
            }
        }
    }
}
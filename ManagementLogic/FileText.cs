using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ManagementLogic
{
    public class FileText
    {
        //use async/await to read file
        public async static void ReadFileAsync()
        {
                    //relative file path
         string path = @"../ManagementLogic/UsersData.txt";

            //create txt file if file does not exist
            if (!File.Exists(path))
            {
                using StreamWriter createFile = File.CreateText(path);
            }

            //read the contents of the file
            using (StreamReader streamReader = File.OpenText(path))
            {
                //read to the end of the file
                var read = await streamReader.ReadToEndAsync(); //async method
                System.Console.WriteLine(read);
            }
        }

        //use async/await to write file
        //it will take parameters of the data passed in from the caller
        public async static void WriteFileAsync(string firstName, string lastName, string email, string favouriteFood)
        {
             //relative file path
            string path = @"../ManagementLogic/UsersData.txt";

            //create txt file if file does not exist
            if (!File.Exists(path))
            {
                using StreamWriter createFile = File.CreateText(path);
            }

            //write the data to file
            //save data to a list<string> first
            //and loop through it to get the value of specific item to be added to file
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                List<string> list = new List<string>();
                list.Add(firstName);
                list.Add(lastName);
                list.Add(email);
                list.Add(favouriteFood);
                foreach (string item in list)
                {
                    //write to file asynchronously
                    await streamWriter.WriteAsync(item);
                }
            }
        }

    }
}

using System;
using AdventureWorksAPI.Controllers;
using System.Collections.Generic;
using AdventureWorksAPI.Models;
using System.Linq;

namespace Import_Export
{
    public class Program
    {
      public static AdventureWorksContext context { get; set; }
        static void Main(string[] args)
        {
            //Get a users choice either Import or Export
            //if Export pick either all or a select group of database objects

            //if Import pick a file to read from delimited by pipe to post to database
            //when import is selected pick a database type

            string answer = "";

            //Testing
            Console.WriteLine("Run Json or CSV Serializer?");
            answer = Console.ReadLine().ToLower();

            if (answer == "json")
            {
                Export.ExportCustomersJSON();
            }
            else if (answer == "regular")
            {
                Export.ExportCustomers();
            }
            else
            {

            }
            
            //continue
            Console.WriteLine("Try the method you wrote?");
            answer = Console.ReadLine().ToLower();

            if (answer == "yes")
            {
                ErrorCSVWriter();
            }
            else if (answer == "no")
            {
                Console.ReadKey();
            }
            else if (answer =="import")
            {
                GetCustomerNames();
            }

        }
        static void Choice(string value)
        {
            //switch case to process choice

        }
        static void ErrorCSVWriter()
        {
            context = new AdventureWorksContext();
            List<ErrorLog> errorList = context.ErrorLog.ToList();
            foreach (ErrorLog error in errorList)
            {
                FileWriting.WriteError(error);
            }
        }
        static void GetCustomerNames()
        {

            List<Customer> list = Import.ImportCustomersHelper().ToList(); 

            foreach (Customer customer in list)
            {
                Console.WriteLine(customer.firstName + customer.lastName);
            }

        }
    }
}

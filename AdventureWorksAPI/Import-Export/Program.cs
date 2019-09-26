using System;
using AdventureWorksAPI.Controllers;
using System.Collections.Generic;
using AdventureWorksAPI.Models;
using System.Linq;

namespace Import_Export
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get a users choice either Import or Export
            //if Export pick either all or a select group of database objects

            //if Import pick a file to read from delimited by pipe to post to database
            //when import is selected pick a database type


            //Testing
            Export.ExportCustomers();
            Export.ExportCustomersJSON();

            //continue
            Console.WriteLine("Try the method you wrote?");
            string answer = Console.ReadLine().ToLower();

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
            ErrorLogsController controller = new ErrorLogsController();
            List<ErrorLog> errorList = controller.GetErrorLog().ToList();
            foreach (ErrorLog error in errorList)
            {
                FileWriting.WriteError(error);
            }
        }
        static void GetCustomerNames()
        {

            List<Customer> list = Import.ImportCustomers().ToList();

            foreach (Customer customer in list)
            {
                Console.WriteLine(customer.FirstName + customer.LastName);
            }
        }
    }
}

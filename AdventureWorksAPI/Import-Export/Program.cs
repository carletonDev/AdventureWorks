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
            //run write all to json folder to export to firebase realtime, and maybe link ef to it
           var check= FirebaseDatabase.WriteAllToJson();

            Console.WriteLine(check);
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
                Console.WriteLine(customer.firstName +" "+ customer.lastName);
            }



        }
    }
}

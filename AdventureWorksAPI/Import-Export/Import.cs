using AdventureWorksAPI.Models;
using CsvHelper;
using System.Collections.Generic;
using System.IO;
using FileHelpers;
using System.Threading.Tasks;

namespace Import_Export
{
    public static class Import
    {
        public static AdventureWorksContext context;
        //method to import to the database using File Helper Nuget
        public static void ImportCustomerFromCsV()
        {
            //instantiate file helper and read file
            var engine = new FileHelperEngine<Customer>();
            var records = engine.ReadFile("C:\\Customers\\allCustomers.csv");
            //Add to database
            context.Customer.AddRange(records);
            context.SaveChanges();
        }
        //method to import to the database using CsvHelper and returns a list if u want to see it in console
        public static List<Customer> ImportCustomersHelper()
        {
            List<Customer> data = new List<Customer>();

            using (var stream = new StreamReader("C:\\Customers\\allCustomers.csv"))
            {
               using (var csv = new CsvReader(stream))
                {
                    csv.Configuration.Delimiter = "|";
                    csv.Configuration.HasHeaderRecord = true;
   
                    var records = csv.GetRecords<Customer>();

                    foreach (var record in records)
                    {
                        data.Add(record);
                    }

                    context.Customer.AddRange(records);
                    context.SaveChanges();

                }

            }
                return data;
        }

        //method that sends a single customer object to api async using a Task 
        public static async void ImportToAPI(Customer customer)
        {


            await PostCustomerAsync(customer);


        }
        public static async Task<int> PostCustomerAsync(Customer customer)
        {
            AdventureWorksContext context = new AdventureWorksContext();
            context.Customer.Add(customer);
            int x = await context.SaveChangesAsync();
            return x;
        }

    }
}

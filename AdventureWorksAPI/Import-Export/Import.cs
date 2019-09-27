using AdventureWorksAPI.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Import_Export
{
   public static class Import
    {
        public static void ImportErrorLog()
        {
          
        }
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

                    if (records.GetEnumerator().MoveNext()==true)
                    {
                        foreach (var record in records)
                        {
                            data.Add(record);
                        }
                    }
                    else
                    {
                        ImportToAPI(csv.GetRecord<Customer>());   
                    }
                }
                 
            }
                return data;
        }
        public static async void ImportToAPI(Customer customer)
        {

          
             await Export.PostCustomerAsync(customer);


        }

    }
}

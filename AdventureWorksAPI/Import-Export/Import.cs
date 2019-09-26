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
        public static IList<Customer> ImportCustomers()
        {
            IList<Customer> data = null;
            using(var stream = new FileStream("C:\\Customers\\allCustomers.csv", FileMode.Open, FileAccess.Read))
            {
                var cs = new CsvSerializer<Customer>();
                data = cs.Deserialize(stream);
            }
            return data;
        }

    }
}

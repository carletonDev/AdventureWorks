using AdventureWorksAPI.Controllers;
using AdventureWorksAPI.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Xml;

namespace Import_Export
{
    public static class Export
    {
       public static void ExportCustomers()
        {
            //code school way
            //Access the api controller 
            CustomersController controller = new CustomersController();
            //store the list of customers in the database to list
            List<Customer> allCustomers = controller.GetCustomer().ToList();
            //use csv serializer class to serialize all customers with a pipe delimiter
            CsvSerializer<Customer> csv = new CsvSerializer<Customer>();
            using (var stream = new FileStream("C:\\Customers\\allCustomers.csv",FileMode.Create,FileAccess.Write))
            {
                csv.Separator = '|';
                csv.Serialize(stream, allCustomers);
            }

        
        }
        public static void ExportCustomersJSON()
        {
            var json = JsonResult("api/customers");
            XmlNode xml = JsonConvert.DeserializeXmlNode("{records:{record:" + json + "}}");

            
        }
        static void ExportAddresses()
        {

        }
        static void ExportCustomerAddress()
        {

        }
        public static void ExportErrors()
        {
            //CSV Helper NU Get Method
            //get a List of all errors
            ErrorLogsController controller = new ErrorLogsController();
            List<ErrorLog> allErrors = controller.GetErrorLog().ToList();
            //using streamwriter
            using (StreamWriter writer = File.CreateText("C:\\ErrorLog\\errors.csv"))
            {
                //set delimiter using csvhelper configuration class to pipe
                Configuration configuration = new Configuration();
                configuration.Delimiter = "|";
                //instantiate serializaer
                CsvSerializer csv = new CsvSerializer(writer,configuration);
                //for each error in error log list
                foreach(ErrorLog error in allErrors)
                {
                    //create a string array to store and convert to list
                    List<string> errorCSV = new List<string>();
                    errorCSV.Add("ErrorLogId:"+error.ErrorLogId.ToString());
                    errorCSV.Add("ErrorMessage:"+error.ErrorMessage);
                    errorCSV.Add("ErrorLine:"+error.ErrorLine.ToString());
                    errorCSV.Add("ErrorNumber:"+error.ErrorNumber.ToString());
                    errorCSV.Add("ErrorProcedure:"+error.ErrorProcedure);
                    errorCSV.Add("ErrorSeverity:"+error.ErrorSeverity.ToString());
                    errorCSV.Add("ErrorState:"+error.ErrorState.ToString());
                    errorCSV.Add("ErrorTime:"+error.ErrorTime.ToString());
                    //send values to csv helper to serialize record (only stores values though not the data)
                    csv.Write(errorCSV.ToArray());
                }
            }
        }

        public static async Task<string> JsonResult(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://website20190926112338.azurewebsites.net/"+ url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync(); 

        }
    }
}

using AdventureWorksAPI.Controllers;
using AdventureWorksAPI.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Xml;


namespace Import_Export
{
    public static class Export
    {
         public static AdventureWorksContext context { get; set; }
         public static HttpClient client { get; set; }
        public static void ExportCustomers()
        {
            Customer customer = new Customer();
            customer.customerId = 30119;
            customer.nameStyle = false;
            customer.title = "Mr.";
            customer.firstName = "Carleton";
            customer.lastName = "cabarrus";
            customer.middleName = "lee";
            customer.suffix = "jr";
            customer.companyName = "ACompany";
            customer.salesPerson = "adventure-works\\pamela0|orlando0@adventure-works.com";
            customer.phone = "804-337-1521";
            customer.passwordHash = new HashCode().ToString();
            customer.passwordSalt = "salt";
            customer.rowguid = Guid.NewGuid();
            customer.modifiedDate = DateTime.Now;
            string csv = ConvertJson(JsonConvert.SerializeObject(customer));
            FileWriting.WriteStringToFile(csv, "C:\\Customers\\allCustomers.csv");
        }
        public static void ExportCustomersJSON()
        {
            //pass in parameters
            string json = JsonResult("api/customers").Result;
            //convert json to xml to csv with pipe delimeter
            string csv= ConvertJson(json);
            //use file write method to write string to file
            FileWriting.WriteStringToFile(csv, "C:\\Customers\\allCustomers.csv");

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
            List<ErrorLog> allErrors = context.ErrorLog.ToList();
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
            client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://website20190926112338.azurewebsites.net/"+ url);
            return  await response.Content.ReadAsStringAsync(); 

            
        }
        //public static async Task<Uri> PostCustomer(string url, Customer customer)
        //{
        //    var json = JsonConvert.SerializeObject(customer);
            
        //    HttpClient client = new HttpClient();

        //    //HttpResponseMessage response = await client.PostAsync("https://website20190926112338.azurewebsites.net/" + url,);
        //    //response.EnsureSuccessStatusCode();

        //    // return URI of the created resource.
        //    return response.Headers.Location;
        //}

        public static async Task<int>PostCustomerAsync(Customer customer)
        {
            AdventureWorksContext context = new AdventureWorksContext();
            context.Customer.Add(customer);
           int x= await context.SaveChangesAsync();
            return x;
        }
        public static string ConvertJson(string json)
        {
            XmlNode xml = JsonConvert.DeserializeXmlNode("{records:{record:" + json + "}}");

            XmlDocument xmldoc = new XmlDocument();
            //Create XmlDoc Object
            xmldoc.LoadXml(xml.InnerXml);
            //Create XML Steam 
            var xmlReader = new XmlNodeReader(xmldoc);
            DataSet dataSet = new DataSet();
            //Load Dataset with Xml
            dataSet.ReadXml(xmlReader);
            //return single table inside of dataset
            var csv = dataSet.Tables[0].ToCSV("|");

            return csv;
        }
        public static string ToCSV(this DataTable table, string delimator)
        {
            var result = new StringBuilder();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                result.Append(table.Columns[i].ColumnName);
                result.Append(i == table.Columns.Count - 1 ? "\n" : delimator);
            }
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    result.Append(row[i].ToString());
                    result.Append(i == table.Columns.Count - 1 ? "\n" : delimator);
                }
            }
            return result.ToString().TrimEnd(new char[] { '\r', '\n' });
        }

    }
}

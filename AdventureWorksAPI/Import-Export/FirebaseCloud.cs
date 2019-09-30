using System;
using System.Collections.Generic;
using System.Text;

using AdventureWorksAPI.Models;

namespace Import_Export
{
   public class FirebaseDatabase
    {
        /// <summary>
        /// create json files to import to firebase database when azure subscription expires
        /// </summary>
        public static string WriteAllToJson()
        {
            var dictionary = CreateEFDictionary();
            
            //convert the models in the database to json files in the json folder in your c drive
            foreach(var value in dictionary)
            {
                Export.ExporttoJSON(value.Value,"json");
            }
            
            return "done";
        }
        /// <summary>
        /// creates a database of the model names for GET requests from the api
        /// </summary>
        /// <returns>dictionary of models</returns>
        public static Dictionary<int,string> CreateEFDictionary()
        {
            Dictionary<int, string> models = new Dictionary<int, string>();
            models.Add(0, "Addresses");
            models.Add(1, "Customers");
            models.Add(2, "CustomerAddresses");
            models.Add(3, "ErrorLogs");
            models.Add(4, "Products");
            models.Add(5, "ProductCategories");
            models.Add(6, "ProductDescriptions");
            models.Add(7, "ProductModels");
            models.Add(8, "ProductModelProductDescriptions");
            models.Add(9, "SalesOrderDetails");
            models.Add(10, "SalesOrderHeaders");

            return models;
        }
    }
}

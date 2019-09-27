using AdventureWorksAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Import_Export
{
    public static class FileWriting
    {
        public static string  pipe = "|";
        public static string path = "C:\\ErrorLog\\";
       public static void WriteError(ErrorLog item)
        {
            using (StreamWriter sw = new StreamWriter(path + "error.csv"))
            {
                sw.WriteLine(item.ErrorLogId.ToString() + pipe + item.ErrorTime.ToString() + pipe + item.ErrorNumber.ToString() + pipe + item.ErrorSeverity.ToString() + pipe + item.ErrorState.ToString() + pipe + item.ErrorProcedure + pipe + item.ErrorLine.ToString() + pipe + item.ErrorMessage);
            }
        }
        public static void WriteStringToFile(string value, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(value);
            }
        }
       public static void ReadNewCustomer(Customer post)
        {

        } 
    }
}

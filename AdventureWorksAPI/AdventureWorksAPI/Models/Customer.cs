using FileHelpers;
using System;
using System.Collections.Generic;
namespace AdventureWorksAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            customerAddress = new HashSet<CustomerAddress>();
            salesOrderHeader = new HashSet<SalesOrderHeader>();
        }
        public int customerId { get; set; }
        public bool nameStyle { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string suffix { get; set; }
        public string companyName { get; set; }
        public string salesPerson { get; set; }
        public string emailAddress { get; set; }
        public string phone { get; set; }
        public string passwordHash { get; set; }
        public string passwordSalt { get; set; }
        public Guid rowguid { get; set; }
        public DateTime modifiedDate { get; set; }

        public ICollection<CustomerAddress> customerAddress { get; set; }
        public ICollection<SalesOrderHeader> salesOrderHeader { get; set; }
    }
}

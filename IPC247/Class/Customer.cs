using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC247
{
    public class Customer
    {
        public string ID { get; set; }
        public string CardName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public Customer()
        {
            ID = "0";
            CardName = "";
            Address = "";
            Phone = "";
            CompanyName = "";
            Company = "0";
            Email = "";
            Description = "";
        }
        public Customer(Customer cus)
        {
            ID = cus.ID;
            CardName = cus.CardName;
            Address = cus.Address;
            Phone = cus.Phone;
            CompanyName = cus.CompanyName;
            Company = cus.Company;
            Email = cus.Email;
            Description = cus.Description;
        }
    }

}

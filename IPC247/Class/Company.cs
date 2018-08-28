using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC247
{
    public class Company
    {
        public string ID { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Company(Company com)
        {
            ID = com.ID;
            CompanyName = com.CompanyName;
            Description = com.Description;
            Address = com.Address;
        }
        public Company()
        {
            ID = "0";
            CompanyName = ""; 
            Description = "";
            Address = "";
        }
        public Company(string _ID, string _CompanyName, string _Description, string _Address)
        {
            ID = _ID;
            CompanyName = _CompanyName;
            Description = _Description;
            Address = _Address;
        }

    }
}


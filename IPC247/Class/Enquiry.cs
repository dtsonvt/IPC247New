using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC247
{
    public class Enquiry
    {
        public string ID_Request { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string ID_Enquiry { get; set; }
        public string EnquiryName { get; set; }
        public string Curator { get; set; }
        public string CuratorName { get; set; }
        public string Address_Cus { get; set; }
        public Enquiry()
        {
            ID_Request = "0";
            CompanyName = "";
            CompanyCode = "0";
            Description = "";
            CardCode = "0";
            CardName = "";
            SDT = "";
            Email = "";
            ID_Enquiry = "0";
            EnquiryName = "";
            Curator = "";
            CuratorName = "";
            Address_Cus = "";
        }

        public Enquiry(Enquiry en)
        {
            ID_Request = en.ID_Request;
            CompanyCode = en.CompanyCode;
            CompanyName = en.CompanyName;
            Description = en.Description;
            CardName = en.CardName;
            CardCode = en.CardCode;
            SDT = en.SDT;
            Email = en.Email;
            ID_Enquiry = en.ID_Enquiry;
            EnquiryName = en.EnquiryName;
            Curator = en.Curator;
            CuratorName = en.CuratorName;
            Address_Cus = en.Address_Cus;
        }
    }
}


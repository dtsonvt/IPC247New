using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC247
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? Price { get; set; }
        public string UserID { get; set; }
    }

}

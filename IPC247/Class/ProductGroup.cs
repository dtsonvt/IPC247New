using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC247
{
    public class ProductGroupDetails
    {
        public string ID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int SoLuong { get; set; }

        public decimal ThanhTien
        {
            get
            {
                try
                {
                    return Price* SoLuong;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }

    public class ProductSelect
    {
        public string ID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductGroupHeader
    {
		private string _ID ;
		private string _ProductGroupName ;
		private string _ListProductCode ;
		private string _CreateBy ;
		private string _CreateDate ;
		private string _UpdateBy ;
		private string _UpdateDate ;
		private decimal _TongTien;

		public string ID { get; set; }
        public string ProductGroupName { get; set; }
        public string ListProductCode { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateDate { get; set; }
        public decimal TongTien { get; set; }
		public ProductGroupHeader()
		{

			ID = _ID;
			ProductGroupName = _ProductGroupName;
			ListProductCode = _ListProductCode;
			CreateBy = _CreateBy;
			CreateDate = _CreateDate;
			UpdateBy = _UpdateBy;
			UpdateDate = _UpdateDate;
			TongTien = _TongTien;
		}
		public ProductGroupHeader(ProductGroupHeader ob)
		{

			ID = ob.ID;
			ProductGroupName = ob.ProductGroupName;
			ListProductCode = ob.ListProductCode;
			CreateBy = ob.CreateBy;
			CreateDate = ob.CreateDate;
			UpdateBy = ob.UpdateBy;
			UpdateDate = ob.UpdateDate;
			TongTien = ob.TongTien;
		}
	}
}


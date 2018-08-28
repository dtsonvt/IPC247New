using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC247
{
    public class InfoCustomer
    {
        public string ID { get; set; }
        public string SoBaoGia { get; set; }

        public string ToKhachHang { get; set; }
        public string DiaChiKhachHang { get; set; }
        public string NguoiNhan { get; set; }
        public string Mobile_NguoiNhan { get; set; }
        public string Tel_NguoiNhan { get; set; }
        public string Email_NguoiNhan { get; set; }

        public string NgayBaoGia { get; set; }
        public decimal TongTien { get; set; }
        public decimal TongTienAfterVat { get; set; }
        public int VAT { get; set; }

        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateDate { get; set; }

		public string DieuKhoan { get; set; }
        public string ID_Enquiry { get; set; }
        public string EnquiryName { get; set; }
        public string IDCardCode { get; set; }
        public string IDCompany { get; set; }
        public List<InfoReportDetails> DSSanPham { get; set; }
    }

    public class InfoCustomerPrint
    {
        public string ID { get; set; }
        public string SoBaoGia { get; set; }
        public string ToKhachHang { get; set; }
        public string DiaChiKhachHang { get; set; }
        public string NguoiNhan { get; set; }
        public string Mobile_NguoiNhan { get; set; }
        public string Tel_NguoiNhan { get; set; }
        public string Email_NguoiNhan { get; set; }
        public string NgayBaoGia { get; set; }
        public decimal TongTien { get; set; }
        public decimal TongTienAfterVat
        {
            get
            {
                try
                {
                    return TongTien + VATMoney;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public int VAT { get; set; }
        public decimal VATMoney
        {
            get
            {
                try
                {
                    return decimal.Parse(System.Math.Round(double.Parse(TongTien.ToString()) * (VAT * 1.0 / 100), 0).ToString());
                }
                catch
                {
                    return 0;
                }
            }
        }
        public string DieuKhoanHopDong { get; set; }
        public string STT { get; set; }
        public string MaSP { get; set; }
        public string TenHang { get; set; }
        public string MoTaHangHoa { get; set; }
        public string SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        // thông tin thêm :
        public string TenCongTy { get; set; }
        public string DiaChi { get; set; }
        public string NguoiGui { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

    }

    public class InfoReportDetails
    {
        //    public string STT { get; set; }
        public string ID { get; set; }
        public string MaSP { get; set; }
        public string TenHang { get; set; }
        public string MoTaHangHoa { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia
        {
            get; set;
        }
        public decimal DonGiaKhauTru
        {
            get
            {
                return DonGia - ChietKhau;
            }
        }
        public decimal ChietKhau { get; set; }
        public decimal ThanhTien
        {
            get
            {
                return SoLuong*DonGiaKhauTru;
            }
        }
        public decimal Profit { get; set; }
		public decimal CostPrice
		{
			get; set;
		}
		public int Status { get; set; }
		public int IsGroup { get; set; }
	}
}

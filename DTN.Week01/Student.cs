using System;
using System.Collections.Generic;
using System.Text;

namespace Dtn.Week01.Bai01
{
    internal class Student
    {
        public string masv { get; set; }
        public string hoTen { get; set; }
        public string ngaySinh { get; set; }
        public string gioiTinh { get; set; }
        public string email { get; set; }
        public string soDienThoai { get; set; }
        public string nganhHoc { get; set; }
        public float dtb { get; set; }
        public bool trangThai { get; set; }

        public void xuat()
        {
            Console.WriteLine(masv + " " + hoTen + " " + ngaySinh + " " + gioiTinh + " " + email + " " + soDienThoai + " " + nganhHoc + " " + dtb + " " + trangThai);
        }
    }
}

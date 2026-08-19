using Dtn.Week01.Bai01;
using System.ComponentModel;
using System.Linq;

namespace DtnWeek01Bai01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string choice;
            List<Student> students = new List<Student>()
            {
                new Student
                {
                    masv="SV001",
                    hoTen="Dinh Thanh Nam",
                    ngaySinh = "27/12/2006",
                    gioiTinh = "Nam",
                    email="nam@gmail.com",
                    soDienThoai="0000000001",
                    nganhHoc="CNTT",
                    dtb=8.2f,
                    trangThai=true
                },
                new Student
                {
                    masv="SV002",
                    hoTen="Nguyen Duc Duy",
                    ngaySinh = "02/01/2007",
                    gioiTinh = "Nam",
                    email="duy@gmail.com",
                    soDienThoai="0000000002",
                    nganhHoc="CNTT",
                    dtb=7.6f,
                    trangThai=true
                }
            };
            do
            {
                menu();
                Console.Write("Nhap lua chon cua ban: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ThemSinhVien(students);
                        break;
                    case "2":
                        HienThiDanhSach(students);
                        break;
                    case "3":
                        Student sv = TimSinhVienTheoMa(students);
                        if (sv == null)
                        {
                            Console.WriteLine("Khong tim thay sinh vien!");
                        }
                        else
                        {
                            Console.WriteLine("Tim thay sinh vien");
                            sv.xuat();
                        }
                        break;
                    case "4":
                        TimGanDungTheoHoTen(students);
                        break;
                    case "5":
                        CapNhatSinhVien(students);
                        break;
                    case "6":
                        XoaSinhVien(students);
                        break;
                    case "7":
                        SapXepTheoHoTen(students);
                        break;
                    case "8":
                        SapXepTheoDiemTrungBinh(students);
                        break;
                    case "9":
                        HienThiSinhVienCoDiem8TroLen(students);
                        break;
                    case "10":
                        HienThiSinhVienCoDiemCaoNhat(students);
                        break;
                    case "11":
                        float diemtb = TinhDiemTrungBinhToanBoSinhVien(students);
                        Console.WriteLine("Diem trung binh toan bo sinh vien la: " + diemtb);
                        break;
                    case "12":
                        ThongKeSinhVienTheoNganh(students);
                        break;
                    case "13":
                        ThongKeSinhVienTheoTrangThai(students);
                        break;
                    case "14":
                        Console.WriteLine("Ban da thoat chuong trinh");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            } while (choice != "14");
        }

        static void menu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Hien thi danh sach");
            Console.WriteLine("3. Tim sinh vien theo ma");
            Console.WriteLine("4. Tim gan dung theo ho ten");
            Console.WriteLine("5. Cap nhat sinh vien");
            Console.WriteLine("6. Xoa sinh vien");
            Console.WriteLine("7. Sap xep theo ho ten");
            Console.WriteLine("8. Sap xep theo diem trung binh");
            Console.WriteLine("9. Hien thi sinh vien co diem tu 8 tro len");
            Console.WriteLine("10. Hien thi sinh vien co diem cao nhat");
            Console.WriteLine("11. Tinh diem trung binh toan bo sinh vien");
            Console.WriteLine("12. Thong ke sinh vien theo nganh");
            Console.WriteLine("13. Thong ke sinh vien theo trang thai");
            Console.WriteLine("14. Thoat chuong trinh");
        }

        static void ThemSinhVien(List<Student> students)
        {
            Student sv = new Student();
            Console.Write("Ma sinh vien: ");
            sv.masv = Console.ReadLine();
            bool check = false;

            foreach (Student s in students)
            {
                if (sv.masv == s.masv)
                {
                    check = true;
                    break;
                }
            }

            if (check)
            {
                Console.WriteLine("Ma sinh vien da ton tai");
                return;
            }

            do
            {
                Console.Write("Ho va ten: ");
                sv.hoTen = Console.ReadLine();
            } while (sv.hoTen == null || sv.hoTen.Trim() == "");

            Console.Write("Ngay sinh: ");
            sv.ngaySinh = Console.ReadLine();
            Console.Write("Gioi tinh (Nam / Nu) : ");
            sv.gioiTinh = Console.ReadLine();
            Console.Write("Email: ");
            sv.email = Console.ReadLine();
            Console.Write("So dien thoai: ");
            sv.soDienThoai = Console.ReadLine();
            Console.Write("Nganh hoc: ");
            sv.nganhHoc = Console.ReadLine();

            do
            {
                Console.Write("Diem trung binh: ");
                sv.dtb = float.Parse(Console.ReadLine());
            } while (sv.dtb < 0 || sv.dtb > 10);
            
            sv.trangThai = true;

            students.Add(sv);

            Console.WriteLine("Them sinh vien thanh cong!");
        }

        static void HienThiDanhSach(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Khong co sinh vien trong danh sach");
                return;
            }

            foreach (Student sv in students)
            {
                Console.WriteLine(sv.masv + " " + sv.hoTen + " " + sv.ngaySinh + " " + sv.gioiTinh + " " + sv.email + " " + sv.soDienThoai + " " + sv.nganhHoc + " " + sv.dtb + " " + sv.trangThai);
            }
        }

        static Student TimSinhVienTheoMa(List<Student> students)
        {
            Student sinhvien = null;
            string masv;
            Console.Write("Nhap ma sinh vien can tim: ");
            masv = Console.ReadLine();
            foreach (Student sv in students)
            {
                if (sv.masv == masv)
                {
                    sinhvien = sv;
                    break;
                }
            }
            return sinhvien;
        }

        static void TimGanDungTheoHoTen(List<Student> students)
        {
            Console.Write("Nhap ten sinh vien can tim: ");
            string ten = Console.ReadLine();
            bool check = false;

            foreach (Student sv in students)
            {
                if (sv.hoTen.ToLower().Contains(ten.ToLower()))
                {
                    sv.xuat();
                    check = true;
                }
            }

            if (!check)
            {
                Console.WriteLine("Khong tim thay sinh vien!");
            }
        }

        static void CapNhatSinhVien(List<Student> students)
        {
            Console.Write("Nhap ma sinh vien muon cap nhat: ");
            string ma = Console.ReadLine();
            Student sinhvien = null;

            foreach (Student sv in students)
            {
                if (ma == sv.masv)
                {
                    sinhvien = sv;
                    break;
                }
            }

            if (sinhvien == null)
            {
                Console.WriteLine("Khong tim thay sinh vien!");
                return;
            }

            do
            {
                Console.Write("Ho va ten moi: ");
                sinhvien.hoTen = Console.ReadLine();
            } while (sinhvien.hoTen == null || sinhvien.hoTen.Trim() == "");

            Console.Write("Ngay sinh moi: ");
            sinhvien.ngaySinh = Console.ReadLine();
            Console.Write("Gioi tinh (Nam / Nu) moi: ");
            sinhvien.gioiTinh = Console.ReadLine();
            Console.Write("Email moi: ");
            sinhvien.email = Console.ReadLine();
            Console.Write("So dien thoai moi: ");
            sinhvien.soDienThoai = Console.ReadLine();
            Console.Write("Nganh hoc moi: ");
            sinhvien.nganhHoc = Console.ReadLine();
            do
            {
                Console.Write("Diem trung binh moi: ");
                sinhvien.dtb = float.Parse(Console.ReadLine());
            } while (sinhvien.dtb < 0 || sinhvien.dtb > 10);

            Console.WriteLine("Cap nhat thanh cong");
        }

        static void XoaSinhVien(List<Student> students)
        {
            string ma;
            Console.Write("Nhap ma sinh vien muon xoa: ");
            ma = Console.ReadLine();
            Student sinhvien = null;

            foreach (Student sv in students)
            {
                if (ma == sv.masv)
                {
                    sinhvien = sv;
                    break;
                }
            }

            if (sinhvien == null)
            {
                Console.WriteLine("Khong tim thay sinh vien");
                return;
            }
            else
            {
                students.Remove(sinhvien);
                Console.WriteLine("Xoa sinh vien thanh cong!");
            }
        }

        static void SapXepTheoHoTen(List<Student> students)
        {
            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = i + 1; j < students.Count; j++)
                {
                    if (students[i].hoTen.CompareTo(students[j].hoTen) > 0)
                    {
                        Student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }

            Console.WriteLine("Danh sach sau khi sap xep theo ten la: ");
            HienThiDanhSach(students);
        }

        static void SapXepTheoDiemTrungBinh(List<Student> students)
        {
            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = i + 1; j < students.Count; j++)
                {
                    if (students[i].dtb < students[j].dtb)
                    {
                        Student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }

            Console.WriteLine("Danh sach sau khi sap xep theo diem la: ");
            HienThiDanhSach(students);
        }

        static void HienThiSinhVienCoDiem8TroLen(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Khong co sinh vien trong danh sach");
                return;
            }

            List<Student> sinhvien = new List<Student>();
            foreach (Student sv in students)
            {
                if (sv.dtb >= 8)
                {
                    sinhvien.Add(sv);
                }
            }
            if (students.Count == 0)
            {
                Console.WriteLine("Khong co sinh vien tu 8 diem tro len");
                return;
            }
            else
            {
                HienThiDanhSach(sinhvien);
            }
        }

        static void HienThiSinhVienCoDiemCaoNhat(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Khong co sinh vien trong danh sach");
                return;
            }

            List<Student> sinhvien = new List<Student>();
            float max = students[0].dtb;
            foreach (Student sv in students)
            {
                if (sv.dtb > max)
                    max = sv.dtb;
            }

            foreach (Student sv in students)
            {
                if (sv.dtb == max)
                    sinhvien.Add(sv);
            }
            Console.WriteLine("Nhung sinh vien co diem trung binh cao nhat la: ");
            HienThiDanhSach(sinhvien);
        }

        static float TinhDiemTrungBinhToanBoSinhVien(List<Student> students)
        {
            if(students.Count == 0)
            {
                return 0;
            }

            float diemTrungBinh = 0.0f;
            foreach (Student sv in students)
            {
                diemTrungBinh += sv.dtb;
            }


            return diemTrungBinh / students.Count;
        }

        static void ThongKeSinhVienTheoNganh(List<Student> students)
        {
            List<string> nganhHoc = new List<string>();

            foreach (Student sv in students)
            {
                bool check = false;

                foreach (string nganh in nganhHoc)
                {
                    if (nganh == sv.nganhHoc)
                    {
                        check = true;
                        break;
                    }
                }

                if (!check)
                {
                    int dem = 0;

                    foreach (Student sinhvien in students)
                    {
                        if (sinhvien.nganhHoc == sv.nganhHoc)
                        {
                            dem++;
                        }
                    }

                    Console.WriteLine("Nganh " + sv.nganhHoc + ": " + dem + " sinh vien");
                    nganhHoc.Add(sv.nganhHoc);
                }
            }
        }

        static void ThongKeSinhVienTheoTrangThai(List<Student> students)
        {
            int dangHoc = 0;
            int dangNghi = 0;
            foreach (Student sv in students)
            {
                if (sv.trangThai)
                {
                    dangHoc++;
                }
                else
                {
                    dangNghi++;
                }
            }

            Console.WriteLine("Dang hoc: " + dangHoc + " sinh vien");
            Console.WriteLine("Dang nghi: " + dangNghi + " sinh vien");
        }
    }
}


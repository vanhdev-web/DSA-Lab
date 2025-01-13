using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    public class Sach
    {
        public string MaSach;
        public string TenSach;
        public string TacGia;
        public uint NamXuatBan;
        public uint SoLuong;
    }
    public class DocGia
    {
        public string MaDocGia;
        public string TenDocGia;
        public string DiaChi;
        public string SoDienThoai;

    }
    public class PhieuMuon
    {
        public string MaPhieuMuon;
        public string MaDocGia;
        public string MaSach;
        public DateTime NgayMuon;
        public DateTime NgayTra;

    }

    internal class Program
    {
        public static List<Sach> dsSach =  new List<Sach>();
        public static List<DocGia> dsDocGia =  new List<DocGia>();
        //Thêm sách
        public static Sach ThemSach(string MaSach, string TenSach, string TacGia, uint NamXuatBan, uint SoLuong)
        {
            Sach sach = new Sach();
            sach.MaSach = MaSach;
            sach.TenSach = TenSach;
            sach.TacGia = TacGia;
            sach.NamXuatBan = NamXuatBan;
            sach.SoLuong = SoLuong;
            return sach;
        }

        //Thêm độc giả
        public static DocGia themDocGia(string MaDocGia, string TenDocGia, string DiaChi, string SoDienThoai)
        {
            DocGia docgia = new DocGia();
            docgia.MaDocGia = MaDocGia;
            docgia.TenDocGia = TenDocGia;
            docgia.DiaChi = DiaChi;
            docgia.SoDienThoai = SoDienThoai;
            return docgia;
        }

        //Tìm kiếm sách theo mã sách
        public static Sach TKmasach(string MaSach)
        {
            foreach (Sach sach in dsSach)
            {
                if (sach.MaSach.ToUpper() == MaSach.ToUpper())
                {
                    return sach;
                }
            }
            return null;
        }

        //Tìm kiếm sách theo tên sách
        public static Sach TKtensach(string TenSach)
        {
            foreach (Sach sach in dsSach)
            {
                if (sach.TenSach.ToUpper() == TenSach.ToUpper())
                {
                    return sach;
                }
            }
            return null;
        }

        //Tìm kiếm sách theo tác giả
        public static List<Sach> TKtacgia(string TacGia)
        {
            List<Sach> dsTKsach = new List<Sach>();
            foreach (Sach sach in dsSach)
            {
                if (sach.TacGia.ToUpper() == TacGia.ToUpper())
                {
                    dsTKsach.Add(sach);
                }
            }
            if (dsTKsach.Count != 0)
            {
                return dsTKsach;
            }
            else
            {
                return null;
            }
        }

        //In danh sách sách
        public static void InDSSach(bool isNew = true,List<Sach> ds=null)
        {
            if (isNew)
            {
                foreach (Sach sach in dsSach)
                {
                    InSach(sach);
                }
            }
            else
            {
                if (ds != null)
                {
                    foreach (Sach sach in ds)
                    {
                        InSach(sach);
                    }
                }
                else
                {
                    Console.WriteLine("Không tìm thấy sách");
                }
            }
        }

        //In danh sách độc giả

        public static void InDSDocGia()
        {
            foreach (DocGia docgia in dsDocGia)
            {
                Console.WriteLine(
                    $"Mã độc giả : {docgia.MaDocGia}\n"+
                    $"Tên độc giả : {docgia.TenDocGia}\n"+
                    $"Địa chỉ : {docgia.DiaChi}\n"+
                    $"Số điện thoại : {docgia.SoDienThoai}\n" 
                    );
            }
        }

        // In thông tin một cuốn sách
        public static void InSach(Sach sach)
        {
            if (sach != null)
            {
                Console.WriteLine(
                       $"Mã sách : {sach.MaSach}\n" +
                       $"Tên sách : {sach.TenSach}\n" +
                       $"Tên tác giả : {sach.TacGia}\n" +
                       $"Năm xuất bản : {sach.NamXuatBan}\n" +
                       $"Số lượng : {sach.SoLuong} \n"
                       );
            }
            else
            {
                Console.WriteLine("Không tìm thấy sách");
            }
        }


        //Mượn sách

       /* public class PhieuMuon
        {
            public string MaPhieuMuon;
            public string MaDocGia;
            public string MaSach;
            public DateTime NgayMuon;
            public DateTime NgayTra;

        }*/
        public static void MuonSach(string MaPhieuMuon, string MaDocGia, string MaSach, DateTime NgayMuon, DateTime NgayTra)
        {
            PhieuMuon pm = new PhieuMuon();
            pm.MaPhieuMuon = MaPhieuMuon;
            pm.MaDocGia = MaDocGia;
            pm.MaSach = MaSach;
            pm.NgayMuon = NgayMuon;
            pm.NgayTra = NgayTra;
            InPhieuMuon(pm.MaPhieuMuon, pm.MaDocGia, pm.MaSach, pm.NgayMuon, pm.NgayTra);
        }
        //Trả sách
        public static void TraSach(string MaPhieuMuon, string MaDocGia, string MaSach, DateTime NgayMuon, DateTime NgayTra)
        {
            PhieuMuon pm = new PhieuMuon();
            pm.MaPhieuMuon = MaPhieuMuon;
            pm.MaDocGia = MaDocGia;
            pm.MaSach = MaSach;
            pm.NgayMuon = NgayMuon;
            pm.NgayTra = NgayTra;
            InPhieuMuon(pm.MaPhieuMuon, pm.MaDocGia, pm.MaSach, pm.NgayMuon, pm.NgayTra,NgayMuon<NgayTra);
        }

        public static void InPhieuMuon(string MaPhieuMuon, string MaDocGia, string MaSach, DateTime NgayMuon, DateTime NgayTra, bool Tinhtrang= true)
        {
            string tinhtrang = Tinhtrang == true ?"Đúng hạn" : "Trễ hạn" ;
            Console.WriteLine($"Mã phiếu mượn : {MaPhieuMuon}\n" +
                $"Mã độc giả : {MaDocGia}\n" +
                $"Mã sách : {MaSach}\n" +
                $"Ngày mượn : {NgayMuon}\n" +
                $"Ngày trả : {NgayTra}\n"+
                $"Tình trạng: {tinhtrang}\n"); 
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Thêm sách vào list
            Sach sach1 = ThemSach("001", "Sapiens: A Brief History of Humankind", "Yuval Noah Harari", 2011, 10);
            dsSach.Add(sach1);
            Sach sach2 = ThemSach("002", "Atomic Habits", "James Clear", 2018, 20);
            dsSach.Add(sach2);
            Sach sach3 = ThemSach("003", "To Kill a Mockingbird", "Harper Lee", 1960, 30);
            dsSach.Add(sach3);
            Sach sach4 = ThemSach("004", "The Clear Path to Productivity", "James Clear", 2020, 40);
            dsSach.Add(sach4);


            // Thêm độc giả vào list
            DocGia docgia1 = themDocGia("A00", "DO VIET ANH", "Quận 1", "0404040404");
            dsDocGia.Add(docgia1);
            DocGia docgia2 = themDocGia("B00", "LE QUOC BAO", "Quận 2", "0505050505");
            dsDocGia.Add(docgia1);
            DocGia docgia3 = themDocGia("C00", "TANG THOAI HAO", "Quận 3", "0606060606");
            dsDocGia.Add(docgia1);

            //InDSSach();
            //InDSDocGia();

            //----------------------Tìm kiếm sách--------------------------
            /*Sach sach = TKmasach("001");
            InSach(sach);*/

            /*Sach sach =TKtensach("Atomic Habits");
            InSach(sach);*/

            //Tìm kiêm theo tác giả
            /*List<Sach> dstimkiem = TKtacgia("James Clear");
            InDSSach(false,dstimkiem);*/


            //Mượn sách
            DateTime datetime = DateTime.Now;
            //MuonSach("01", "A00", "001",datetime , datetime.AddDays(20));

            //Trả sách
            //TraSach("01", "A00", "001", datetime, new DateTime(2024,1,1));
            

            Console.ReadKey();

        }


    }
}

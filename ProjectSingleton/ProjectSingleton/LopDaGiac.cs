using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSingleton
{
    public abstract class DaGiac
    {
        //data
        //nhung cai no cha dung private con ko dc sai, protected con sai
        private string mau;
        private int socanh;
        protected double[] dodaicanh;
        //constructor
        //this tranh su nhoc nhang khai bao cung ten
        //this chinh la lop ao DaGiac
        public DaGiac(string mau,int socanh)
        {
            this.mau = mau;
            this.socanh = socanh;
            dodaicanh = new double[socanh];
        }
        //methods
        public abstract void TinhChuVi();
        public abstract void TinhDienTich();

  
        public virtual void InThongTin()
        {
            
            Console.WriteLine("Mau: {0}", mau);
            Console.WriteLine("so canh: {0}", socanh);
        }
    }

    //derived class
    //LopHinhVuong -->LopDaGiac
    public class LopHinhVuong:DaGiac
    {
        //constructor
        //tinh dong goi va che dau thong tin
        //thua ke the hien qua base
        //base->thua ke
        public LopHinhVuong(string mau) : 
            base(mau, 1)
        {
            Console.WriteLine("Nhap canh hinh vuong");
            dodaicanh[0] = Double.Parse(Console.ReadLine());
        }
        public override void TinhChuVi()
        {
            Console.WriteLine("Chu vi: {0}", dodaicanh[0] * 4);
        }
        //override -->tinh da hinh
        public override void TinhDienTich()
        {
            Console.WriteLine("Dien tich: {0}", dodaicanh[0] * dodaicanh[0]);
        }
        //Tinh da hinh
        //viet lai cua cha
        public override void InThongTin()
        {
            //su dung lai cua cha
            base.InThongTin();
            Console.WriteLine("Do dai canh hinh vuong: {0}", dodaicanh[0]);
        }
    }
    public class LopDaGiac
    {
        public static void Test()
        {
            LopHinhVuong hv1 = new LopHinhVuong("xanh");
            hv1.InThongTin();
            hv1.TinhChuVi();
            hv1.TinhDienTich();

            Console.ReadKey();
        }

    }
}

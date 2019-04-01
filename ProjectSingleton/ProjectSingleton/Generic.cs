using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSingleton
{
    //Generic delegates
    //Thay thế nguyên 1 đống delegates duoi
    //Kieu R (double ,int)
    //2 kieu tra về la T,R
    //dinh nghia 1 cai chung
    public delegate R Tinh<T,R>(T a, T b);

    //delegates
    //
    //public delegate int TinhNguyen(int a, int b);
    //public delegate double TinhThuc(double a, double b);
    //public delegate double TinhChuoi(string a, string b);
    //public delegate double TinhThuc2(int a, int b);
    public  class PhepTinhNumber
    {
        public static int AddInt(int a,int b)
        {
            return a + b;
        }
        public static double AddDouble(double a,double b)
        {
            return a + b;
        }

        public static string AddString(string a,string b)
        {
            return a.Trim() + " " + b.Trim();
        }
        public static double DivNumber(int a,int b)
        {

            return a * 1.0 / b;
        }
    }
    public class Generic
    {
        public static void Test()
        {
            Tinh<int, int> cong2nguyen = new Tinh<int, int>(PhepTinhNumber.AddInt);
            Console.WriteLine("5+2={0}", cong2nguyen(5, 2));
            Tinh<double, double> cong2thuc = new Tinh<double, double>(PhepTinhNumber.AddDouble);
            Console.WriteLine("4.5+3.5={0}", cong2thuc(4.5, 3.5));
            Tinh<string, string> cong2chuoi = new Tinh<string, string>(PhepTinhNumber.AddString);
            Console.WriteLine("Hello+Han= {0}", cong2chuoi("Hello", "Han"));

            Tinh<int, double> chianguyen = new Tinh<int, double>(PhepTinhNumber.DivNumber);
            Console.WriteLine("5/7={0:0.000}", chianguyen(5,7));

            Console.ReadKey();
        }
    }
}

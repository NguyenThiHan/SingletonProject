using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSingleton
{

    
    public delegate int TinhToan(int a, int b);

    public delegate void Calculator(int number);
    public static class PhepTinh
    {
        static int number1 = 10;
        public static int Number
        {
            get
            {
                return number1;
            }
        }
        public static void Add2Number(int number2)
        {
            //number1=number1+number;
            //
            number1 += number2;
        }
        public static void Sub2Number(int number2)
        {
            number1 -= number2;
        }
        public static void Multiply(int number2)
        {
            number1 *= number2;
        }
        public static int Cong2Nguyen(int a, int b)
        {
            return a + b;
        }
        public static int Tru2Nguyen(int a,int b)
        {
        
            return a - b;
        }
        public static int Nhan2Nguyen(int a,int b)
        {
            return a * b;

        }
    }
    public class Delegate
    {
        public static void Test()
        {
            TinhToan tinhcong = new TinhToan(PhepTinh.Cong2Nguyen);
            Console.WriteLine("4+3={0}", tinhcong(4, 3));
            TinhToan tinhtru = new TinhToan(PhepTinh.Tru2Nguyen);
            Console.WriteLine("5-4={0}", tinhtru(4, 5));

            Calculator add = new Calculator(PhepTinh.Add2Number);
            add(3);
            Console.WriteLine("10+3={0}", PhepTinh.Number);
            Calculator sub = new Calculator(PhepTinh.Sub2Number);
            sub(4);
            Console.WriteLine("10-4={0}", PhepTinh.Number);
   
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSingleton
{
    // tinh truu tuong
    public abstract class Polygon
    {
        //data hiding
        //tinh dong goi thong tin 
        //thong tin number_side la thong tin can duoc dong goi
        private string color;
        private int number_side;
        //chỉ cho con sài 
        //class nào có cha con được sử dụng
        protected double[] side_length;

        //constructor
        public Polygon(string color, int number_side)
        {
            this.color = color;
            this.number_side = number_side;
            //create 1 list number_side
            side_length = new double[number_side];
        }
        // method abstract to Perimeter Caculator
        public abstract void Perimeter();
        //method abstract to Area Caculator 
        public abstract void Area();

        //method abstract to 
        public virtual void PrintInformation()
        {
            Console.WriteLine("Color: {0}", color);
            Console.WriteLine("Number side : {0}", number_side);
        }
    }

    //instance of Polygon
    ////derived class-> Polygon
    public class Square: Polygon
    {
        //base --> inheritance(tinh thua ke)
        //base the hiện tính thừa kế
        public Square(string color) : base(color, 1)
        {
            Console.Write("Enter side length:");
            side_length[0] =Double.Parse( Console.ReadLine());

        }
        public override void Area()
        {
            Console.WriteLine("Area: {0} ", side_length[0] * 4);
        }
        public override void Perimeter()
        {
            Console.WriteLine("Perimeter: {0} ", side_length[0] * side_length[0]);
        }

        //Polymorphism
        //the hien tinh da hinh viet lai tu lop cha
        public override void PrintInformation()
        {
            base.PrintInformation();
            Console.WriteLine("side length: {0}", side_length[0]);
        }
    }

    public class InheritanceSample
        {
            public static void Test()
            {
                Square sq1 = new Square("black");
                sq1.PrintInformation();
                sq1.Area();
                sq1.Perimeter();

            }

        }

}

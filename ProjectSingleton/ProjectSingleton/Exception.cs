using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSingleton
{
    //lop ngoại le để cạnh dương
    public class EnterPositiveSideException:ApplicationException
    {
        //nhan message va in message
        public EnterPositiveSideException(string message):base(message)
        {

        }

    }
    //lớp ngoại lệ cho 3 cạnh của 1 tam giác
    public class ThreeSideOfTriangle:ApplicationException
    {
        public ThreeSideOfTriangle(string message):base(message)
        {

        }
    }
    public class TowSideOfRectangle:ApplicationException
    {
        public TowSideOfRectangle(string message):base(message)
        {

        }
    }
    //interface để tính toán
    interface ICaculator
    {
        void Area();
        void Perimeter();
    }
    public abstract class PolygonCalculator:ICaculator
    {
        //data
        private int number_side;
        //cho con su dung
        protected double[] side_length;

        //method
        public PolygonCalculator(int number_side)
        {
            this.number_side = number_side;
            side_length = new double[number_side];
        }
        public virtual void Area()
        {
            Console.WriteLine("Caculating.....!");
        }
        public virtual void Perimeter()
        {
            Console.WriteLine("Caculating.....!");
        }
        public virtual void PrintInformation()
        {
            Console.WriteLine("Number side: {0}", number_side);
        }
    }

    public class SquareCalculator : PolygonCalculator
    {

        public SquareCalculator() : base(1)
        {
        Retype:
            try
            {
                Console.Write("Enter length of side: ");
                side_length[0] = double.Parse(Console.ReadLine());
                if (side_length[0] <= 0)
                {
                    throw new EnterPositiveSideException("Enter Positive Side");
                }
            }
            //catch chuyen kieu
            catch (FormatException e)
            {
                Console.WriteLine("Enrror: {0}", e.Message);
                goto Retype;
            }
            catch (EnterPositiveSideException e)
            {
                Console.WriteLine("Enrror: {0}", e.Message);
                goto Retype;
            }

        }

        //method
        public override void PrintInformation()
        {
            base.PrintInformation();
            Console.WriteLine("Length of side: {0}", side_length[0]);
            Console.WriteLine("I'm Square!!!");
        }

        public override void Area()
        {
            base.Area();
            Console.WriteLine("Area: {0}", side_length[0] * side_length[0]);
        }
        public override void Perimeter()
        {
            base.Perimeter();
            Console.WriteLine("Perimeter: {0}", side_length[0] * 4);
        }
    }

    public class RectangleCaculater:PolygonCalculator
    {
        //constructor
        public RectangleCaculater() : base(2)
        {
        Retype:

            try
            {
                Console.Write("Enter length of length_side:");
                side_length[0] = Double.Parse(Console.ReadLine());
                Console.Write("Enter length of width_side: ");
                side_length[1] = Double.Parse(Console.ReadLine());
                if (side_length[0] <= 0 || side_length[1] <= 0)
                {
                    throw new EnterPositiveSideException("Must Enter Positive Side!");
                }
                if(side_length[0]==side_length[1])
                {
                    throw new TowSideOfRectangle("Must Enter Side length different!!!");
                }
            }
            //loi formart trong system
            catch (FormatException e)
            {
                Console.WriteLine("Enrror: {0}", e.Message);
                goto Retype;
            }
            catch (EnterPositiveSideException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                goto Retype;
            }
            catch (TowSideOfRectangle e)
            {

                Console.WriteLine("Error: {0}", e.Message);
                goto Retype;
            }
            finally
            {
                Console.WriteLine("Error");
            }
        }
        public override void Area()
        {
            base.Area();
            Console.WriteLine("Area: {0}", (side_length[0] * side_length[1]));
        }
        public override void Perimeter()
        {
            base.Perimeter();
            Console.WriteLine("Perimeter: {0}", (side_length[0] + side_length[1]) / 2);
        }
        public override void PrintInformation()
        {
            base.PrintInformation();
            Console.WriteLine("I'm Rectangle!!");
            Console.WriteLine("Length of Rectangle: {0}", side_length[0]);
            Console.WriteLine("Width of Rectangle: {0}", side_length[1]);
        }
    }

    public class TriangleCaculator : PolygonCalculator
    {

        public TriangleCaculator() : base(3)
        {
        Retype:
            try
            {
                Console.Write("Length of Triangle:");
                side_length[0] = Double.Parse(Console.ReadLine());
                Console.Write("Length of Triangle:");
                side_length[1] = Double.Parse(Console.ReadLine());
                Console.Write("Length of Triangle:");
                side_length[2] = Double.Parse(Console.ReadLine());
                if (side_length[0] <= 0 || side_length[1] <= 0 || side_length[2] <= 0)
                {
                    throw new EnterPositiveSideException("Must enter positive side!!! ");
                }
                if ((side_length[0] + side_length[1] < side_length[2]) || (side_length[0] - side_length[1] > side_length[2])/* || (side_length[0]==side_length[1])|| (side_length[0]==side_length[3])||(side_length[2]==side_length[3] )*/)
                {
                    throw new ThreeSideOfTriangle("Enter false!! Please retype!!!");
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                goto Retype;
            }
            catch(EnterPositiveSideException e)
            {
                Console.WriteLine("Error:{0}", e.Message);
                goto Retype;
            }
            catch(ThreeSideOfTriangle e)
            {
                Console.WriteLine("Error:{0}", e.Message);
                goto Retype;
            }
            //finally
            //{
            //    Console.WriteLine("Error");
            //}
        }
        public override void Area()
        {
            base.Area();
            //nua chu vi
            double p = (side_length[0] + side_length[1] + side_length[2]) / 2;
            Console.WriteLine("Area: {0}", Math.Sqrt(p * (p - side_length[0]) * (p - side_length[1]) * (p - side_length[2])));
        }
        public override void Perimeter()
        {
            base.Perimeter();
            Console.WriteLine("I'm Triangle!!!!");
            Console.WriteLine("Perimeter: {0}", (side_length[0] + side_length[1] + side_length[2]));
        }
        public override void PrintInformation()
        {
            base.PrintInformation();
        }

    }
    public class Exception
        {
        private string v;

        public Exception(string v)
        {
            this.v = v;
        }

        public static void Test()
            {
            //SquareCalculator hv1 = new SquareCalculator();
            //hv1.PrintInformation();
            //hv1.Area();
            //hv1.Perimeter();

            RectangleCaculater rectangle = new RectangleCaculater();
            rectangle.PrintInformation();
            rectangle.Area();
            rectangle.Perimeter();

            //TriangleCaculator triangle = new TriangleCaculator();
            //triangle.PrintInformation();
            //triangle.Area();
            //triangle.Perimeter();

            Console.ReadKey();
        }


    }
    
}

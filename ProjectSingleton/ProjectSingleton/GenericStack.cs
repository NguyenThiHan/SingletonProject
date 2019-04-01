using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectSingleton
{
    public class MyStack
    {
        const int max_element = 10;
      
        int sp;//stack pointer
        double[] value;
        public MyStack()
        {
            sp = 0;//empty
            value = new double[max_element];
        }

        //method
        public bool Empty()
        {
            return (sp == 0);
        }
        public bool Full()
        {
            return (sp == max_element);
        }

        public void Push(double val)
        {
            if(!Full())
            {
                value[sp] = val;
                sp++;
            }
            else
            {
                throw new IndexOutOfRangeException("Can't add new element on stack.Stack is full");
            }
        }
        public double Pop()
        {
            double kq;
            if(!Empty())
            {
                sp--;
                kq = value[sp];
            }
            else
            {
                throw new Exception(V);
            }
            return kq;
        }
    }
    public class GenericStack
    {
    }
}

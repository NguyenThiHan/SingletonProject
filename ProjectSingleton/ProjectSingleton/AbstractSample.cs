using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSingleton
{

    public interface ISwim
    {
        void Swim();
    }
    public interface ITalk
    {
        void Talk();
    }
    public interface ISing
    {
        void Sing();
    }
    public abstract class Animal
    {
        protected string Name { get; set; }
        protected double Weight { get; set; }

        //method abstract
        public abstract void sound();
        public override string ToString()
        {
            return string.Format("Name: {0}, Weight: {1}", Name, Weight);
        }
    }
    public class Cat: Animal
    {
        public Cat()
        {
            this.Name = "Mi";
            this.Weight = 5;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void sound()
        {
            Console.WriteLine("I'm a Cat");
            Console.WriteLine("Meo meo!");
        }
    }

    public class Dog:Animal,ITalk,ISing,ISwim
    {
        public Dog()
        {
            this.Name = "Lux";
            this.Weight = 7;

        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void sound()
        {
            Console.WriteLine("I'm a Dog");
            Console.WriteLine("Gâu Gâu!!");
        }

        public void Swim()
        {
            Console.WriteLine("I can Swim");
        }

        public void Sing()
        {
            Console.WriteLine("I can Sing a Song");
        }

        public void Talk()
        {
            Console.WriteLine("I can say Hello Guys");
        }
    }

    public class Fish:Animal, ISwim
    {
        public Fish()
        {
            this.Name = "Hana";
            this.Weight =2;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void sound()
        {
            Console.WriteLine("I'm a Fish");
            Console.WriteLine("I donn't have sound ");
        }
        public void Swim()
        {
            Console.WriteLine("I can swim");
        }
    }
     
    public static class AbstractSample
    {
        public static void Test()
        {
            //
            Cat cat1 = new Cat();
            Console.WriteLine(cat1.ToString());
            Console.Write("Soud:");
            cat1.sound();
            //Dog
            Console.WriteLine("==========");
            Dog dog1 = new Dog();
            Console.WriteLine(dog1.ToString());
            Console.Write("Sound: ");
            dog1.sound();
            dog1.Talk();
            dog1.Swim();
            dog1.Sing();

        }

    }
}

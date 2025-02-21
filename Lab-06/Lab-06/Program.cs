using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace ConsoleApp1
{
    public abstract class ABicycle : IComparable 
    {
        public int id { get; set; }
        public string color { get; set; }
        public double price { get; set; }


        public ABicycle(int id, string color, double price)
        {
            this.id = id;
            this.color = color;
            this.price = price;

        }
        public void Print()
        {
            Console.WriteLine($"Info ( id : {id} , color: {color}, price : {price})");
        }

        public int CompareTo(object obj)
        {
            ABicycle aBicycle = obj as ABicycle;
            if (this.price < aBicycle.price) return -1;
            if (this.price > aBicycle.price) { return 1; }
            return 0;

        }

        

        public class UsualBicycle : ABicycle , ICloneable
        {
            public bool utility;
            public UsualBicycle(int id, string color, double price, bool utility) : base(id, color, price)
            {
                this.utility = utility;
            }

            public object Clone()
            {
                return new UsualBicycle(this.id, this.color, this.price, this.utility);
            }
        }

        public class SpeedBicycle : ABicycle, ICloneable
        {
            public int speedrate;
            public SpeedBicycle(int id, string color, double price, int speedrate) : base(id, color, price)
            {
                this.speedrate = speedrate;
            }

            public object Clone()
            {
                return new SpeedBicycle(this.id, this.color, this.price, this.speedrate);
            }
        }

        public class ClimbBicycle : ABicycle, ICloneable
        {
            public int climbrate;
            public ClimbBicycle(int id, string color, double price, int climbrate) : base(id, color, price)
            {
                this.climbrate = climbrate;
            }

            public object Clone()
            {
                return new ClimbBicycle(this.id, this.color, this.price, this.climbrate);
            }
        }

        public class Store
        {
                public List<ABicycle> Bicycles = new List<ABicycle>()
            {
                new UsualBicycle(1, "red", 270, true),
                new UsualBicycle(3, "blue", 110, false),
                new UsualBicycle(10, "orange", 120, true),
                new UsualBicycle(4, "gray", 430, false),

                new SpeedBicycle(5, "gray", 144, 2),
                new SpeedBicycle(2, "white", 710, 2),
                new SpeedBicycle(2, "white", 710, 2),

                new ClimbBicycle(7, "blue", 670, 2),
                new ClimbBicycle(8, "green", 302, 4),
                new ClimbBicycle(6, "pink", 175, 5)
            };

            
            /* Bicycles.Add(new UsualBicycle(1, "red", 270, true));
             Bicycles.Add(new UsualBicycle(3, "blue", 110, false));
             Bicycles.Add(new UsualBicycle(10, "orange", 120, true));
             Bicycles.Add(new UsualBicycle(4, "gray", 430, false));


             Bicycles.Add(new SpeedBicycle(5, "gray", 144, 2));
             Bicycles.Add(new SpeedBicycle(2, "white", 710, 2));
             Bicycles.Add(new SpeedBicycle(9, "blue", 283, 2));


             Bicycles.Add(new ClimbBicycle(7, "blue", 670, 2));
             Bicycles.Add(new ClimbBicycle(8, "green", 302, 4));
             Bicycles.Add(new ClimbBicycle(6, "pink", 175, 5));*/



            public List<ABicycle> Search(int from, int to)
            {
                
                List<ABicycle> result = new List<ABicycle>();
                foreach (ABicycle i in Bicycles)
                {
                    if (i.price >= from && i.price <= to)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }

            public List<ABicycle> Arrange(bool ascending = true)
            {


                Bicycles.Sort();
                if (!ascending)
                {
                    Bicycles.Reverse();
                }
                return Bicycles;
            }



        }

        internal class Program
        {
            public static void printListBicycle(List<ABicycle> list)
            {
                foreach (ABicycle i in list)
                {
                    i.Print();
                }
            }

            static void Main(string[] args)
            {
                Store store = new Store();
                //Tìm kiếm theo giá
                printListBicycle(store.Search(300, 700));
                Console.WriteLine();

                printListBicycle(store.Bicycles);
                Console.WriteLine();
                //Sắp xếp từ thấp lên cao
                store.Arrange();
                printListBicycle(store.Bicycles);

                Console.WriteLine();
                //Sắp xếp từ cao xuông thấp
                store.Arrange(false);
                printListBicycle(store.Bicycles);

                Console.ReadLine();

            }
        }
    }
}
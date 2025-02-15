using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{

    interface IVector
    {
        IVector Add(IVector vector);
        IVector Subtract(IVector vector);
        IVector Multiply(double scalar);
        IVector Divide(double scalar);
        double Length();
        IVector Normalize();
        double DotProduct(IVector vector);
        IVector CrossProduct(IVector vector);
         void Print();
    }
    class Vector2D:IVector , ICloneable , IComparable
    {
        public double x { get; set; }
        public double y { get; set; }

        public Vector2D(double x=0, double y = 0)
        {
            this.x = x;
            this.y = y; 
        }
        public IVector Add(IVector vector)
        {
            if (vector.GetType() == this.GetType())
            {
                Vector2D other = vector as Vector2D;
                return new Vector2D(this.x + other.x, this.y + other.y);
            }
            else
            {
                Vector3D other = vector as Vector3D;
                return new Vector3D(this.x + other.x, this.y + other.y, 0 + other.z);
            }
            
        }
        public IVector Subtract(IVector vector)
        {
            

            if (vector.GetType() == this.GetType())
            {
                Vector2D other = vector as Vector2D;
                return new Vector2D(this.x - other.x, this.y - other.y);
            }
            else
            {
                Vector3D other = vector as Vector3D;
                return new Vector3D(this.x - other.x, this.y - other.y, 0 - other.z);
            }


        }
        public IVector Multiply(double scalar)
        {
            return new Vector2D(this.x * scalar, this.y * scalar);
        }
        public IVector Divide(double scalar)
        {
            return new Vector2D(this.x / scalar, this.y / scalar);
        }
        public double Length()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y);
        }
        public IVector Normalize()
        {
            return new Vector2D(this.x / Length(), this.y / Length());
        }
        public double DotProduct(IVector vector)
        {
            

            if (vector.GetType() == this.GetType())
            {
                Vector2D other = vector as Vector2D;
                return (this.x * other.x + this.y * other.y);
            }
            else
            {
                Vector3D other = vector as Vector3D;
                return (this.x * other.x + this.y * other.y);

            }
            
        }
        public IVector CrossProduct(IVector vector)
        {
            return null;
        }

        public void Print()
        {
            Console.WriteLine($"{this.GetType().Name} ({this.x}, {this.y})");
        }

        public object Clone()
        {
            return new Vector2D(this.x, this.y);
        }

        public int CompareTo(object obj)
        {
            IVector v2d = obj as IVector;
            if (this.Length() < v2d.Length()) return -1;
            if (this.Length() >v2d.Length()) return 1;
            return 0;

        }

        public IVector ConvertToVector3D()
        {
            Vector2D tem = (Vector2D) this.Clone();
            return new Vector3D(tem.x, tem.y, 0);
        }
    }

    class Vector3D : IVector, ICloneable, IComparable
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Vector3D(double x = 0, double y = 0, double z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z; 
        }
        public IVector Add(IVector vector)
        {
            Vector3D other = vector as Vector3D;
            return new Vector3D(this.x + other.x, this.y + other.y, this.z + other.z);

        }
        public IVector Subtract(IVector vector)
        {
            Vector3D other = vector as Vector3D;
            return new Vector3D(this.x - other.x, this.y - other.y, this.z - other.z);

        }
        public IVector Multiply(double scalar)
        {
            return new Vector3D(this.x * scalar, this.y * scalar, this.z * scalar);
        }
        public IVector Divide(double scalar)
        {
            return new Vector3D(this.x / scalar, this.y / scalar, this.z/scalar);
        }
        public double Length()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
        }
        public IVector Normalize()
        {
            return new Vector3D(this.x / Length(), this.y / Length(), this.z/Length());
        }
        public double DotProduct(IVector vector)
        {
            Vector3D other = vector as Vector3D;
            return (this.x * other.x + this.y * other.y + this.z* other.x);
        }
        public IVector CrossProduct(IVector vector)
        {
            Vector3D other = vector as Vector3D;
            return new Vector3D(
                this.y * other.z - this.z * other.y,
                -(this.x+other.z - this.z*other.x),
                this.x* other.y - this.y*other.x
                );
        }

        public void Print()
        {
            Console.WriteLine($"{this.GetType().Name} ({this.x}, {this.y}, {this.z})");
        }

        public object Clone()
        {
            return new Vector3D(this.x, this.y, this.z);
        }

        public int CompareTo(object obj)
        {
            
                IVector v3d = obj as IVector;
                if (this.Length() < v3d.Length()) return -1;
                if (this.Length() > v3d.Length()) return 1;
                return 0;
            
            

        }
    }


    internal class Program
    {
        public static void PrintOut(List<IVector> list)
        {
            foreach (IVector i in list)
            {
                Console.Write($"Độ dài vector : {i.Length()}");
                Console.Write("  ");
                i.Print();
                

            }
        }
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            List<IVector> list = new List<IVector>()
            {
                new Vector2D(3,2),
                new Vector2D(4,8),
                new Vector3D(1,-4),
                new Vector3D(2,-4,3),
                new Vector3D(3,-4,4),
               
            };


            Console.WriteLine("Câu 3");
            for (int i = 0; i < list.Count -1; i++)
            {
                list[i].Add(list[i+1]).Print();
                list[i].Subtract(list[i+1]).Print();
                list[i].Multiply(3).Print();
                list[i].Divide(2).Print();
                Console.WriteLine($"Độ dài  {list[i].GetType().Name} : {list[i].Length()}");
                list[i].Normalize().Print();
                Console.WriteLine($"DotProduct {list[i].GetType().Name}: {list[i].DotProduct(list[i+1])}");
                list[0].CrossProduct(list[i]);
                Console.WriteLine("--------------------------------");

            }


            Console.WriteLine("Câu 4");
            PrintOut(list);

            Console.WriteLine("--------------------------------");
            list.Sort();
            PrintOut(list);


            Console.WriteLine("--------------------------------");
            Console.WriteLine("Câu 5");
            IVector v3d = ((Vector2D)list[0]).ConvertToVector3D();
            v3d.Print();    

            Console.ReadKey();  
        }
    }
}

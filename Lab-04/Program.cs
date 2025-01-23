using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_04
{
    public abstract class Avector
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Avector()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Avector(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Vector {this.GetType().Name} ({this.X} , {this.Y})");
        }

        public abstract Avector Add(Avector other);
        public abstract Avector Subtract(Avector other);
        public abstract Avector Multiply(Avector other);
        public abstract Avector Divide(Avector other);
        public abstract float Dot(Avector other);
        public abstract float Module();
        public abstract float Angle(Avector other);

    }

    public class Vector2D : Avector
    {
        public Vector2D() : base() { }
        public Vector2D(float x, float y) : base(x, y) { }


        public override Avector Add(Avector other)
        {
            if (other is Vector2D vector2d)
            {
                return new Vector2D(this.X + vector2d.X, this.Y + vector2d.Y);
            }
            throw new InvalidOperationException("Có lỗi xảy ra ");
        }

        public override Avector Subtract(Avector other)
        {
            if ( other is Vector2D vector2d)
            {
            return new Vector2D(this.X - vector2d.X, this.Y - vector2d.Y);
            }
            throw new InvalidOperationException("Có lỗi xảy ra ");
        }

        public override Avector Multiply(Avector other)
        {
            if (other is Vector2D vector2d)
            {
                return new Vector2D(this.X * vector2d.X, this.Y * vector2d.Y);
            }
            throw new InvalidOperationException("Có lỗi xảy ra ");
        }

        public override Avector Divide (Avector other)
        {
            if (other is Vector2D vector2d)
            {
                return new Vector2D(this.X / vector2d.X, this.Y / vector2d.Y);
            }
            throw new InvalidOperationException("Có lỗi xảy ra ");
        }

        public override float Dot(Avector other)
        {
            if (other is Vector2D vector2d)
            {
                return this.X * vector2d.X + this.Y * vector2d.Y;
            }
            throw new NotImplementedException();
        }

        public override float Module()
        {
            
            return (float) Math.Sqrt(this.X * this.X + this.Y * this.Y);
            
            throw new NotImplementedException();
        }

        public override float Angle(Avector other)
        {
            if (other is Vector2D vector2d)
            {
                return Module()==0 || other.Module()== 0 ?(float) Math.Acos(Dot(other)) / (Module() * other.Module()) : -1;
            }
            throw new NotImplementedException();
        }
    }

    public class Vector3D : Avector
    {
        public float Z { get; set; }

                                       

        public override void ShowInfo()
        {
            Console.WriteLine($"Vector {this.GetType().Name} ({this.X} , {this.Y} , {this.Z})");
        }
        public Vector3D()
        {
            this.Z = 0;
        }

        public Vector3D(float x, float y,float z):base(x,y)
        {
            this.Z= z;
        }
        public override Avector Add(Avector other)
        {
            if (other is Vector3D vector3d)
            {
                return new Vector3D(this.X + vector3d.X, this.Y + vector3d.Y, this.Z + vector3d.Z);
            }
            throw new InvalidOperationException("Có lỗi xảy ra ");
        }

        public override Avector Subtract(Avector other)
        {
            if (other is Vector3D vector3d)
            {
                return new Vector3D(this.X - vector3d.X, this.Y - vector3d.Y, this.Z - vector3d.Z);
            }
            throw new InvalidOperationException("Có lỗi xảy ra ");
        }

        public override Avector Multiply(Avector other)
        {
            if (other is Vector3D vector3d)
            {
                return new Vector3D(this.Y * vector3d.Z - this.Z*vector3d.Y,this.Z*vector3d.X - this.X*vector3d.Z,this.X*vector3d.Y - this.Y*vector3d.X);
            }
            throw new InvalidOperationException("Có lỗi xảy ra ");
        }

        public override Avector Divide(Avector other)
        {
            return null;
        }


        public override float Dot(Avector other)
        {
            if (other is Vector3D vector3d)
            {
                return this.X * vector3d.X + this.Y * vector3d.Y +  this.Z * vector3d.Z;
            }
            throw new InvalidOperationException("Có lỗi xảy ra ");
        }


        public override float Module()
        {

            return (float)Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);

            throw new NotImplementedException();
        }

        public override float Angle(Avector other)
        {
            if (other is Vector3D vector3d)
            {
                return Module() == 0 || other.Module() == 0 ? (float)Math.Acos(Dot(other)) / (Module() * other.Module()) : -1;
            }
            throw new NotImplementedException();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 
            List<Avector> list = new List<Avector>();
            list.Add(new Vector2D(2,3)); //0
            list.Add(new Vector2D(4,-1)); //1
            list.Add(new Vector2D(-3,5)); //2
            list.Add(new Vector2D(0,7)); //3
            list.Add(new Vector2D(1,-2)); //4

            list.Add(new Vector3D(2,3,4)); //5
            list.Add(new Vector3D(1, -1, 5)); //6
            list.Add(new Vector3D(0, 2, -3)); //7
            list.Add(new Vector3D(-4, 0, 6)); //8
            list.Add(new Vector3D(3, 3, 3)); //9





            /*list[0].Add(list[1]).ShowInfo();
            list[0].Subtract(list[2]).ShowInfo();
            list[0].Multiply(list[3]).ShowInfo();
            list[0].Divide(list[4]).ShowInfo();

            Console.WriteLine($"Tích vô hướng vector2D : {list[0].Dot(list[1])}");
            Console.WriteLine($"Độ dài vector2D : {list[0].Module()}");
            Console.WriteLine($"Góc giữa 2 vector2D : {list[0].Angle(list[2])}");*/


            list[5].Add(list[6]).ShowInfo();
            list[5].Subtract(list[7]).ShowInfo();
            list[5].Multiply(list[8]).ShowInfo();

            Console.WriteLine($"Tích vô hướng vector3D : {list[5].Dot(list[6])}");
            Console.WriteLine($"Độ dài vector3D : {list[5].Module()}");
            Console.WriteLine($"Góc giữa 2 vector3D : {list[5].Angle(list[7])}");


            Console.ReadLine();
        }
    }
}

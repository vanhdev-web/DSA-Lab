using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    public class Vector2D
    {
        private float x;
        private float y; 

        public Vector2D()
        {
            this.x = 0;
            this.y = 0;
        }

        public Vector2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }


        public float X
        {
            get => X ;
            set => X = value;
        }

        public float Y
        {
            get => y;
            set => Y = value;
        }

        public void Print()
        {
            Console.WriteLine($"Vector2D <x: {this.x}, y: {this.y}>");
        }

        //Kiểm tra trực giao
        public bool isOrthogonal(Vector2D other)
        {
            return this.x * other.x + this.y * other.y == 0;
        }

        // tính độ dài
        public float Module()
        {
            return (float) Math.Sqrt(this.x * this.x + this.y * this.y);    
        }

        public float Angle(Vector2D other)
        {
            return (this.Module() - other.Module()) != 0 
                ? (float) Math.Acos( (this.x * this.x + this.y * this.y)/(this.Module() * other.Module()))
                : -1;
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
           Console.OutputEncoding = Encoding.UTF8;
           List<Vector2D> list = new List<Vector2D>();
           list.Add(new Vector2D(3, 4));
           list.Add(new Vector2D(-1, 2));
           list.Add(new Vector2D(5, -3));
           list.Add(new Vector2D(0, 6));
           list.Add(new Vector2D(-4, -5));
           list.Add(new Vector2D(1, -0.75f));

            foreach ( Vector2D v in list)
            {
                v.Print();
            }

            //kiểm tra vector trực giao
            Console.WriteLine(list[0].isOrthogonal(list[1]));
            Console.WriteLine(list[0].isOrthogonal(list[5]));

            //tính độ dài vector
            float module = list[0].Module();
            Console.WriteLine($"Độ dài vector : {module}");

            //tính góc
            float angle = list[0].Angle(list[4]);
            Console.WriteLine($"Góc giữa 2 vector : {angle} rad");
            Console.ReadKey();
        }
    }
}

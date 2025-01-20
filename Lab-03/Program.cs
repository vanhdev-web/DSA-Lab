using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03
{
    public class ComplexNumber
    {
        public double Real { set; get; }
        public double Imaginary { set; get; }

        public ComplexNumber()
        {
            this.Real = 0;
            this.Imaginary = 0;
        }

        public ComplexNumber(double  real, double imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        public ComplexNumber(ComplexNumber other)
        {
            this.Real = other.Real;
            this.Imaginary= other.Imaginary;
        }

        //Phép cộng
        public ComplexNumber Add(ComplexNumber other, double para =1)
        {
            return new ComplexNumber(this.Real + other.Real*para, this.Imaginary+ other.Imaginary*para);
        }


        //Phép trừ
        public ComplexNumber Substract(ComplexNumber other, double para = 1)
        {
            return new ComplexNumber(this.Real - other.Real * para, this.Imaginary - other.Imaginary * para);
        }


        //Phép nhân
        public ComplexNumber Multiple(ComplexNumber other, double para = 1)
        {
            return new ComplexNumber((this.Real * other.Real*para) - (this.Imaginary * other.Imaginary * para), (this.Real * other.Imaginary * para) + (this.Imaginary * other.Real * para));
        }
       

        //Phép chia số phức
        public ComplexNumber Divide(ComplexNumber other, double para = 1)
        {
            double deno = other.Imaginary * other.Imaginary + other.Real * other .Real;
            return new ComplexNumber ((this.Real*other.Real * para + this.Imaginary *other.Imaginary * para) /deno,(this.Imaginary*other.Real * para - this.Real*other.Imaginary * para) /deno);
        }

 

        //tính module 
        public double Module ()
        {
            return Math.Sqrt(this.Real * this.Real + this.Imaginary * this.Imaginary);  
        }

        public double Argument()
        {
            return Math.Atan(this.Imaginary / this.Real);
        }

        //cộng số phức với số thức
        public ComplexNumber Add(double a = 0, double b = 0, double c =0)
        {
            return new ComplexNumber (this.Real + a + b +c, this.Imaginary);    
        }

        //cộng nhiều số phức
        public ComplexNumber Add(params ComplexNumber[] cn)
        {
            double real = this.Real;
            double imaginary = this.Imaginary;  
            foreach (ComplexNumber a in cn)
            {
                real += a.Real;
                imaginary += a.Imaginary;   
            }
            return new ComplexNumber(real,imaginary);
        }

        public void Print(string method = "default")
        {
            switch (method)
            {
                case "default":
                    Console.WriteLine($"Complex Number : {this.Real} + {this.Imaginary}i ");
                    break;
                default:
                    Console.WriteLine($"{method} result : {this.Real} + {this.Imaginary}i ");
                    break;
            }
        }
        
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            ComplexNumber[] arrCN = new ComplexNumber[10];
            arrCN[0] = new ComplexNumber(3, 4);
            arrCN[1] = new ComplexNumber(-2, 7);
            arrCN[2] = new ComplexNumber(5, -6);
            arrCN[3] = new ComplexNumber(-1, -3);
            arrCN[4] = new ComplexNumber(8,2);
            arrCN[5] = new ComplexNumber(-4, 5);
            arrCN[6] = new ComplexNumber(7, -9);
            arrCN[7] = new ComplexNumber(0, 3);
            arrCN[8] = new ComplexNumber(-6, 2);
            arrCN[9] = new ComplexNumber(2, 0);


            //in số phức
            foreach ( ComplexNumber a in arrCN )
            {
                a.Print();
            }

            //cộng số phức
            arrCN[5].Add(arrCN[6]).Print("Add");
            arrCN[3].Add(arrCN[4],5).Print("Add");
           

            //trừ số phức
            arrCN[2].Substract(arrCN[6]).Print("Substract");
            arrCN[8].Substract(arrCN[4], 5).Print("Substract");


            //nhân số phức
            arrCN[7].Multiple(arrCN[8]).Print("Multiple");
            arrCN[5].Multiple(arrCN[4], 5).Print("Multiple");
           

            //chia số phức
            arrCN[8].Divide(arrCN[6]).Print("Divide");
            arrCN[2].Divide(arrCN[4], 2).Print("Divide");
            


            //tính module
            double moduleResult = arrCN[5].Module();
            Console.WriteLine("Module : " + moduleResult);

            //tính argument
            double argumentResult = arrCN[3].Argument();
            Console.WriteLine("Module : " + argumentResult + "radian");

            //cộng số phức với số thực
            arrCN[2].Add(4, 5).Print("AddReal");

            //cộng nhiều số phúc
            arrCN[0].Add(arrCN[1], arrCN[2], arrCN[3]).Print("AddMultipleComplexNumber");

















            Console.ReadKey();
        }
    }
}

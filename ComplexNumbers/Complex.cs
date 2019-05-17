using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComplexNumbers
{ 
    public class Complex
    {
        public double real;
        public double imaginary;

        public Complex(double real, double imaginary) 
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public override string ToString()
        {
          return (String.Format("{0}+{1}i", real, imaginary));
        }

        public static Complex sqr(Complex c1) //Корень
        {
            return new Complex(c1.real * c1.real - c1.imaginary * c1.imaginary, 2 * c1.imaginary * c1.real);
        }

        public static double abs(Complex c1) //Модуль
        {
            double absRes = Math.Sqrt(c1.real * c1.real + c1.imaginary * c1.imaginary);
            return absRes;
        }

        public static Complex operator -(Complex c1, Complex c2) 
        {
            return new Complex(c1.real - c2.real, c1.imaginary - c2.imaginary);
        }

        public static Complex operator +(Complex c1, Complex c2) 
        {
            return new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.real * c2.real - c1.imaginary * c2.imaginary, c1.real * c2.imaginary + c2.real * c1.imaginary);
        }

        public static Complex operator /(Complex c1, Complex c2)
        {
            return new Complex((c1.real * c2.real + c1.imaginary * c2.imaginary)/(c2.real * c2.real + c2.imaginary * c2.imaginary),
               (c2.real * c1.imaginary - c1.real * c2.imaginary)/(c2.real * c2.real + c2.imaginary * c2.imaginary));
        }

    }
}

/* 1-2.5-1
Программа-калькулятор с комплексными числами. Напишите аналог программы-калькулятора, вхо-
дящего в Windows, работающего только в обычном (неинжинерном) режиме.
Насонов Е. гр. 205
 */

 /*
  * 1*1%=0,01
  * 1/1%=100
  * 1+1%=1,01
  * 1-1%=0,99
  */

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
         
        /// <summary>
        /// Описывает класс Complex
        /// </summary>
        /// <param name="real">Целая часть числа</param>
        /// <param name="imaginary">Мнимая часть числа</param>
        public Complex(double real, double imaginary) 
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        /// <summary>
        /// Возвращает комплексное число в формате строки
        /// </summary>
        /// <returns>Строка комплексного числа</returns>
        public override string ToString()
        {
          return (String.Format("{0}+{1}i", real, imaginary));
        }
        /// <summary>
        /// Куб комплекскного числа
        /// </summary>
        /// <param name="c1">Число</param>
        /// <returns>Число в кубе</returns>
        public static Complex sqr(Complex c1) 
        {
            return new Complex(c1.real * c1.real - c1.imaginary * c1.imaginary, 2 * c1.imaginary * c1.real);
        }

        /// <summary>
        /// Оператор - для комплексных чисел
        /// </summary>
        /// <param name="c1">Первое число</param>
        /// <param name="c2">Второе число</param>
        /// <returns>Разница</returns>
        public static Complex operator -(Complex c1, Complex c2) 
        {
            return new Complex(c1.real - c2.real, c1.imaginary - c2.imaginary);
        }

        /// <summary>
        /// Оператор + для комплексных чисел
        /// </summary>
        /// <param name="c1">Первое число</param>
        /// <param name="c2">Второе число</param>
        /// <returns>Сумма</returns>
        public static Complex operator +(Complex c1, Complex c2) 
        {
            return new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);
        }
        /// <summary>
        /// Оператор * для комплексных чисел
        /// </summary>
        /// <param name="c1">Первое число</param>
        /// <param name="c2">Второе число</param>
        /// <returns>Произведение</returns>
        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.real * c2.real - c1.imaginary * c2.imaginary, c1.real * c2.imaginary + c2.real * c1.imaginary);
        }
        /// <summary>
        /// Оператор / для комплексных чисел
        /// </summary>
        /// <param name="c1">Первое число</param>
        /// <param name="c2">Второе число</param>
        /// <returns>Частное</returns>
        public static Complex operator /(Complex c1, Complex c2)
        {
            return new Complex((c1.real * c2.real + c1.imaginary * c2.imaginary)/(c2.real * c2.real + c2.imaginary * c2.imaginary),
               (c2.real * c1.imaginary - c1.real * c2.imaginary)/(c2.real * c2.real + c2.imaginary * c2.imaginary));
        }
    }
}

﻿/* 1-2.5-1
Программа-калькулятор с комплексными числами. Напишите аналог программы-калькулятора, вхо-
дящего в Windows, работающего только в обычном (неинжинерном) режиме.
Насонов Е. гр. 205
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ComplexNumbers
{
    /// <summary>
    /// Interaction logic for MainCalcWindow.xaml
    /// </summary>
    public partial class MainCalcWindow : Window
    {
        public Complex resultComplex, firstComplex, secondComplex, memoryComplex; //Комплексные числа
        private string input = "";

        /// <summary>
        /// Этот enum описывает тип вводимого числа для переключения и прочего
        /// </summary>
        public enum SelectedField
        {
            FirstReal,
            FirstImaginary,
            SecondReal,
            SecondImaginary
        }
        
        public SelectedField CurrentSelectedField = SelectedField.FirstReal; //текущее выбранное поле

        public MainCalcWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопок
        /// </summary>
        /// <param name="sender">Нажимаемая кнопка</param>
        /// <param name="e">Информация о собитии</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            try
            {
                switch (btn.Tag)
                {
                    case "divBtn": //Если нажата кнопка деления
                        GetNumbers();
                        resultComplex = firstComplex / secondComplex;
                        resultComplex.real = Math.Round(resultComplex.real, 8);
                        resultComplex.imaginary = Math.Round(resultComplex.imaginary, 8);
                        lblResult.Content = resultComplex.ToString();
                        break;
                    case "mulBtn": //Если нажата кнопка умножения
                        GetNumbers();
                        resultComplex = firstComplex * secondComplex;
                        lblResult.Content = resultComplex.ToString();
                        break;
                    case "addBtn": //Если нажата кнопка сложения
                        GetNumbers();
                        resultComplex = firstComplex + secondComplex;
                        lblResult.Content = resultComplex.ToString();
                        break;
                    case "subBtn": //Если нажата кнопка вычитания
                        GetNumbers();
                        resultComplex = firstComplex - secondComplex;
                        lblResult.Content = resultComplex.ToString();
                        break;
                    case "sqrBtn": //Если нажата кнопка возведения в 3 степень
                        GetNumbers();
                        firstComplex = Complex.sqr(firstComplex);
                        secondComplex = Complex.sqr(secondComplex);
                        lblResult.Content = firstComplex + "\r\n" + secondComplex;
                        break;
                    case "percentBtn": //Нажата кнопка нахождения процента
                        GetNumbers();
                        Complex divComplex = new Complex(0.01, 0);
                        firstComplex = firstComplex * divComplex;
                        MessageBox.Show(firstComplex.ToString(), "1 процент от первого числа");
                        resultComplex = (firstComplex * secondComplex);
                        lblResult.Content = resultComplex;

                        break;
                    case "clrBtn": //Кнопка отчистки
                        Clear();
                        break;

                    case "switchBtn": //Кнопка перехода
                        switch (CurrentSelectedField)
                        {
                            case SelectedField.FirstReal:
                                CurrentSelectedField = SelectedField.FirstImaginary;
                                stepLabel.Content = "2";
                                break;
                            case SelectedField.FirstImaginary:
                                CurrentSelectedField = SelectedField.SecondReal;
                                stepLabel.Content = "3";
                                break;
                            case SelectedField.SecondReal:
                                CurrentSelectedField = SelectedField.SecondImaginary;
                                stepLabel.Content = "4";
                                break;
                            case SelectedField.SecondImaginary:
                                break;
                        }
                        input = "";
                        break;
                    case "1divxBtn": //Кнопка 1/x
                        if (resultComplex == null)
                        {
                            if (SecondReal.Content.ToString() == "" && SecondImaginary.Content.ToString() == "")
                            {
                                resultComplex = (new Complex(1, 0) / GetNumbers(FirstReal.Content.ToString(), FirstImaginary.Content.ToString()));
                            }
                            else
                            {
                                resultComplex = (new Complex(1, 0) / GetNumbers(SecondReal.Content.ToString(), SecondImaginary.Content.ToString()));
                            }
                        }
                        else
                        {
                            resultComplex = (new Complex(1, 0) / resultComplex);
                        }
                        lblResult.Content = resultComplex;
                        break;

                    case "xxBtn": //Кнопка квадрата
                        if (resultComplex == null)
                        {
                            if (SecondReal.Content.ToString() == "" && SecondImaginary.Content.ToString() == "")
                            {
                                Complex tmp = GetNumbers(FirstReal.Content.ToString(), FirstImaginary.Content.ToString());
                                resultComplex = tmp * tmp;
                            }
                            else
                            {
                                Complex tmp = GetNumbers(SecondReal.Content.ToString(), SecondImaginary.Content.ToString());
                                resultComplex = tmp * tmp;
                            }
                        }
                        else
                        {
                            resultComplex = resultComplex * resultComplex;
                        }
                        lblResult.Content = resultComplex;
                        break;
                    case "changesignBtn": //Кнопка смены знака
                        try
                        {
                            switch (CurrentSelectedField)
                            {
                                case SelectedField.FirstReal:
                                    if (FirstReal.Content.ToString()[0] != '-')
                                        FirstReal.Content = '-' + FirstReal.Content.ToString();
                                    else
                                        FirstReal.Content = FirstReal.Content.ToString().Remove(0, 1);
                                    input = FirstReal.Content.ToString();
                                    break;
                                case SelectedField.FirstImaginary:
                                    if (FirstImaginary.Content.ToString()[0] != '-')
                                        FirstImaginary.Content = '-' + FirstImaginary.Content.ToString();
                                    else
                                        FirstImaginary.Content = FirstImaginary.Content.ToString().Remove(0, 1);
                                    input = FirstImaginary.Content.ToString();

                                    break;
                                case SelectedField.SecondReal:
                                    if (SecondReal.Content.ToString()[0] != '-')
                                        SecondReal.Content = '-' + SecondReal.Content.ToString();
                                    else
                                        SecondReal.Content = SecondReal.Content.ToString().Remove(0, 1);
                                    input = SecondReal.Content.ToString();

                                    break;
                                case SelectedField.SecondImaginary:
                                    if (SecondImaginary.Content.ToString()[0] != '-')
                                        SecondImaginary.Content = '-' + SecondImaginary.Content.ToString();
                                    else
                                        SecondImaginary.Content = SecondImaginary.Content.ToString().Remove(0, 1);
                                    input = SecondImaginary.Content.ToString();

                                    break;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {

                        }
                        break;

                    case "IsNumber": //Обработка ввода чисел
                        if (btn.Content.ToString() == ",")
                        {
                            if (!input.Contains(","))
                            {
                                input += btn.Content;
                            }
                        }
                        else
                        {
                            input += btn.Content;
                        }
                        switch (CurrentSelectedField)
                        {
                            case SelectedField.FirstReal:
                                FirstReal.Content = input;
                                break;
                            case SelectedField.FirstImaginary:
                                FirstImaginary.Content = input;
                                break;
                            case SelectedField.SecondReal:
                                SecondReal.Content = input;
                                break;
                            case SelectedField.SecondImaginary:
                                SecondImaginary.Content = input;
                                break;
                        }
                        break;

                    case "Memory": //Работа с памятью калькулятора
                        switch (btn.Content.ToString())
                        {
                            case "MS":
                                SaveToMemory();
                                break;
                            case "MC":
                                memoryComplex = null;
                                break;
                            case "MR":
                                ReadFromMemory();
                                break;
                            case "M+":
                                if (resultComplex != null)
                                {
                                    resultComplex += memoryComplex;
                                    lblResult.Content = resultComplex;
                                }
                                break;
                            case "M-":
                                if (resultComplex != null)
                                {
                                    resultComplex -= memoryComplex;
                                    lblResult.Content = resultComplex;
                                }
                                break;
                        }
                        break;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Заполните корректно все поля");
                Clear();
            }
        }
        /// <summary>
        /// Чтение из памяти калькулятора
        /// </summary>
        private void ReadFromMemory()
        {
            if (memoryComplex != null)
            {
                if (SecondReal.Content.ToString() != "" || SecondImaginary.Content.ToString() != "")
                {
                    FirstReal.Content = memoryComplex.real;
                    FirstImaginary.Content = memoryComplex.imaginary;
                }
                else
                {
                    SecondReal.Content = memoryComplex.real;
                    SecondImaginary.Content = memoryComplex.imaginary;
                }

            }
        }
        /// <summary>
        /// Сохранение в память калькулятора
        /// </summary>
        private void SaveToMemory()
        {
            if (resultComplex == null)
            {
                if (FirstReal.Content.ToString() != "" || FirstImaginary.Content.ToString() != "")
                {
                    memoryComplex = GetNumbers(FirstReal.Content.ToString(), FirstImaginary.Content.ToString());
                }
                if (SecondReal.Content.ToString() != "" || SecondImaginary.Content.ToString() != "")
                {
                    memoryComplex = GetNumbers(SecondReal.Content.ToString(), SecondImaginary.Content.ToString());
                }
            }
            else
            {
                memoryComplex = resultComplex;
            }
        }
        /// <summary>
        /// Очистить калькулятор
        /// </summary>
        private void Clear()
        {
            lblResult.Content = "Не посчитанно";
            input = "";
            FirstReal.Content = "";
            FirstImaginary.Content = "";
            SecondReal.Content = "";
            SecondImaginary.Content = "";
            CurrentSelectedField = SelectedField.FirstReal;
            resultComplex = null;
            stepLabel.Content = "1";
        }

        /// <summary>
        /// Заносит в первое и второе число информацию из полей
        /// </summary>
        private void GetNumbers()
        {
            firstComplex = new Complex(double.Parse(FirstReal.Content.ToString()), double.Parse(FirstImaginary.Content.ToString()));
            secondComplex = new Complex(double.Parse(SecondReal.Content.ToString()), double.Parse(SecondImaginary.Content.ToString()));
        }

        /// <summary>
        /// Выборочно заносит информацию из полей
        /// </summary>
        /// <param name="first">Первое число</param>
        /// <param name="second">Второе число</param>
        /// <returns></returns>
        private Complex GetNumbers(string first, string second)
        {
            if (first == "")
                first = "0";
            if (second == "")
                second = "0";
            return new Complex(double.Parse(first.ToString()), double.Parse(second.ToString()));
        }
    }
}

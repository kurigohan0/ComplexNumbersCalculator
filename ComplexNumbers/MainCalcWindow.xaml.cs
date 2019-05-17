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


        public enum SelectedField
        {
            FirstReal,
            FirstImaginary,
            SecondReal,
            SecondImaginary
        }

        public SelectedField CurrentSelectedField = SelectedField.FirstReal;

        public MainCalcWindow()
        {
            InitializeComponent();
        }

        private void GetNumbers()
        {
            firstComplex = new Complex(double.Parse(FirstReal.Content.ToString()), double.Parse(FirstImaginary.Content.ToString()));
            secondComplex = new Complex(double.Parse(SecondReal.Content.ToString()), double.Parse(SecondImaginary.Content.ToString()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            try
            {
                switch (btn.Tag)
                {
                    case "divBtn":
                        GetNumbers();
                        resultComplex = firstComplex / secondComplex;
                        resultComplex.real = Math.Round(resultComplex.real, 8);
                        resultComplex.imaginary = Math.Round(resultComplex.imaginary, 8);
                        lblResult.Content = resultComplex.ToString();
                        break;
                    case "mulBtn":
                        GetNumbers();
                        resultComplex = firstComplex * secondComplex;
                        lblResult.Content = resultComplex.ToString();
                        break;
                    case "addBtn":
                        GetNumbers();
                        resultComplex = firstComplex + secondComplex;
                        lblResult.Content = resultComplex.ToString();
                        break;
                    case "subBtn":
                        GetNumbers();
                        resultComplex = firstComplex - secondComplex;
                        lblResult.Content = resultComplex.ToString();
                        break;
                    case "sqrBtn":
                        GetNumbers();
                        firstComplex = Complex.sqr(firstComplex);
                        secondComplex = Complex.sqr(secondComplex);
                        lblResult.Content = firstComplex + "\r\n" + secondComplex;
                        break;
                    case "percentBtn":
                        GetNumbers();
                        Complex divComplex = new Complex(0.01, 0);
                        firstComplex = firstComplex * divComplex;
                        MessageBox.Show(firstComplex.ToString(), "1 процент от первого числа");
                        resultComplex = (firstComplex * secondComplex);
                        lblResult.Content = resultComplex;

                        break;
                    case "clrBtn":
                        Clear();
                        break;

                    case "switchBtn":
                        switch (CurrentSelectedField)
                        {
                            case SelectedField.FirstReal:
                                CurrentSelectedField = SelectedField.FirstImaginary;
                                break;
                            case SelectedField.FirstImaginary:
                                CurrentSelectedField = SelectedField.SecondReal;
                                break;
                            case SelectedField.SecondReal:
                                CurrentSelectedField = SelectedField.SecondImaginary;
                                break;
                            case SelectedField.SecondImaginary:
                                break;
                        }
                        input = "";
                        break;
                    case "1divxBtn":
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

                    case "xxBtn":
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

                    case "IsNumber":
                        input += btn.Content;

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

                    case "Memory":
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
        }
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

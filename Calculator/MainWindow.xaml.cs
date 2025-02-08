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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private double firstNumber = 0;
        private string operation = ""; 
        private bool isOperationClicked = false; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text == "0" || isOperationClicked)
            {
                txtDisplay.Text = "";
                isOperationClicked = false;
            }
            Button button = sender as Button;
            txtDisplay.Text += button.Content.ToString();
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            operation = button.Content.ToString();
            firstNumber = Convert.ToDouble(txtDisplay.Text);
            isOperationClicked = true;
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double secondNumber = Convert.ToDouble(txtDisplay.Text);
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                        result = firstNumber / secondNumber;
                    else
                    {
                        txtDisplay.Text = "Ошибка";
                        return;
                    }
                    break;
            }

            txtDisplay.Text = result.ToString();
            isOperationClicked = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            firstNumber = 0;
            operation = "";
            isOperationClicked = false;
        }

        private void Trigonometric_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            double number = Convert.ToDouble(txtDisplay.Text);
            double result = 0;

            switch (button.Content.ToString())
            {
                case "sin":
                    result = Math.Sin(number * Math.PI / 180);
                    break;
                case "cos":
                    result = Math.Cos(number * Math.PI / 180);
                    break;
                case "tg":
                    result = Math.Tan(number * Math.PI / 180);
                    break;
                case "ctg":
                    result = 1 / Math.Tan(number * Math.PI / 180);
                    break;
            }

            txtDisplay.Text = result.ToString();
            isOperationClicked = true;
        }

        private void InverseTrigonometric_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            double number = Convert.ToDouble(txtDisplay.Text);
            double result = 0;

            switch (button.Content.ToString())
            {
                case "arcsin":
                    result = Math.Asin(number) * 180 / Math.PI;
                    break;
                case "arccos":
                    result = Math.Acos(number) * 180 / Math.PI;
                    break;
                case "arctg":
                    result = Math.Atan(number) * 180 / Math.PI;
                    break;
                case "arcctg":
                    result = (Math.PI / 2 - Math.Atan(number)) * 180 / Math.PI;
                    break;
            }

            txtDisplay.Text = result.ToString();
            isOperationClicked = true;
        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            if (!txtDisplay.Text.Contains(",") && !txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ",";
            }
        }
    }
}
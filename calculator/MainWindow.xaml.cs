using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            reset();
            textBox1.Text = Convert.ToString(Convert.ToDouble(currentValue));
        }
        //used variables...
        private string currentValue;
        private string previousValue;
        private string lastOperationArgument;
        private char operation;
        private char lastOperation;
        
        //my methods
        private void reset()
        {
            operation = '=';
            lastOperation = '=';
            currentValue = "0";
            previousValue = "0"; 
            textBlock1.Text = "";
        }
        private void doOperation(){
            textBlock1.Text = Convert.ToString(Convert.ToDouble(previousValue)) + operation + Convert.ToString(Convert.ToDouble(currentValue)) + "=";
            if (operation != '=')
            {
                lastOperation = operation;
                lastOperationArgument = currentValue;
                switch (operation)
                {
                    case '+':
                        currentValue = Convert.ToString(Convert.ToDouble(previousValue) + Convert.ToDouble(currentValue));
                        break;
                    case '-':
                        currentValue = Convert.ToString(Convert.ToDouble(previousValue) - Convert.ToDouble(currentValue));
                        break;
                    case '*':
                        currentValue = Convert.ToString(Convert.ToDouble(previousValue) * Convert.ToDouble(currentValue));
                        break;
                    case '/':
                        if (Convert.ToDouble(currentValue) == 0) { currentValue = "INF"; break; }
                        currentValue = Convert.ToString(Convert.ToDouble(previousValue) / Convert.ToDouble(currentValue));
                        break;
                }

                textBox1.Text = currentValue;
                if (currentValue == "INF") currentValue = "0";
            }
        }
        private void addDigit(char digit){
            currentValue += digit;
            textBox1.Text = Convert.ToString(Convert.ToDouble(currentValue));
        }

        //button clicks events handles
        private void badd_Click(object sender, RoutedEventArgs e){
            if (currentValue != "")
            {
                doOperation();
                operation = '+';
                previousValue = currentValue;
                currentValue = "";
                textBox1.Text = currentValue;
                
            }
            else
            {
                operation = '+';
            }
            textBlock1.Text = Convert.ToString(Convert.ToDouble(previousValue)) + operation;
        }
        private void bsub_Click(object sender, RoutedEventArgs e){
            if (currentValue != "")
            {
            doOperation();
            operation = '-';
            previousValue = currentValue;
            currentValue = "";
            textBox1.Text = currentValue;
            }
            else operation = '-';
            textBlock1.Text = Convert.ToString(Convert.ToDouble(previousValue)) + operation;
        }
        private void bmul_Click(object sender, RoutedEventArgs e){
            if (currentValue != "")
            {
            doOperation();
            operation = '*';
            previousValue = currentValue;
            currentValue = "";
            textBox1.Text = currentValue;
            }
            else operation = '*';
            textBlock1.Text = Convert.ToString(Convert.ToDouble(previousValue)) + operation;
        }
        private void bdiv_Click(object sender, RoutedEventArgs e){
            if (currentValue != "")
            {
            doOperation();
            operation = '/';
            previousValue = currentValue;
            currentValue = "";
            textBox1.Text = currentValue;
            }
            else operation = '/';
            textBlock1.Text = Convert.ToString(Convert.ToDouble(previousValue)) + operation;

        }
        private void bresult_Click(object sender, RoutedEventArgs e)
        {
            if (currentValue != "")
            {
                doOperation();
                if (operation == '=')
                {
                    previousValue = currentValue;
                    currentValue = lastOperationArgument;
                    operation = lastOperation;
                    doOperation();
                }
                operation = '=';
            }
        }

        private void bca_Click(object sender, RoutedEventArgs e){
            reset();
            textBox1.Text = Convert.ToString(Convert.ToDouble(currentValue));
        }
        
        private void b0_Click(object sender, RoutedEventArgs e){addDigit('0');}
        private void b1_Click(object sender, RoutedEventArgs e){addDigit('1');}
        private void b2_Click(object sender, RoutedEventArgs e){addDigit('2');}
        private void b3_Click(object sender, RoutedEventArgs e){addDigit('3');}
        private void b4_Click(object sender, RoutedEventArgs e){addDigit('4');}
        private void b5_Click(object sender, RoutedEventArgs e){addDigit('5');}
        private void b6_Click(object sender, RoutedEventArgs e){addDigit('6');}
        private void b7_Click(object sender, RoutedEventArgs e){addDigit('7');}
        private void b8_Click(object sender, RoutedEventArgs e){addDigit('8');}
        private void b9_Click(object sender, RoutedEventArgs e){addDigit('9');}

        //unusable
        private void Window_Loaded(object sender, RoutedEventArgs e){

        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e){
        }
    }
}

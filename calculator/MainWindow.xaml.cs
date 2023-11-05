using Actions;
using ActionsOnExpressionStandart;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Net.Mime.MediaTypeNames;

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }
        private List<string> HistoryOper = new List<string>();
        
        private void numbersBtn_Click(object sender, RoutedEventArgs e)
        {
            //Ограничить колво символов если контент равен 16 занести его в fisrt 
            // если first и oper не пуст  то ограничить колво символов до 33
            // и если expression.Text == 0 то добавить запятую
            expressionTextBox.Text += ((Button)sender).Content.ToString()!;  
        }

        private void cButton_Click(object sender, RoutedEventArgs e)
        {
            historyEx.Document.Blocks.Clear();
            IOperation.historyOper.Clear();
        }

        private string tempfirst = "";
        private string tempsecond = "";
        private string tempoper = "";
        private bool tempminus;
        private void commaButton_Click(object sender, RoutedEventArgs e)
        {
            if (expressionTextBox.Text == "")
                expressionTextBox.Text += "0";

            GetNumbers(second: expressionTextBox.Text);
            if (tempsecond == "" && tempfirst != "" && tempoper != "")
                expressionTextBox.Text += "0";

            if (!IOperation.comm)
            {
                expressionTextBox.Text += ",";
                IOperation.comm = true;
            }
        }

        private void plusMinusButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void equlityButton_Click(object sender, RoutedEventArgs e)
        {
            IOperation.oper = false;

            GetNumbers(second: expressionTextBox.Text);
            if(tempsecond == "")
                return;
           Standart standart = new Standart(tempfirst, tempsecond, tempoper, out string? result, out List<string> historyOper);
           
           expressionTextBox.Text = result;
           
           HistoryOper = historyOper;
           historyEx.Document.Blocks.Clear();
           historyEx.AppendText(String.Join($"{Environment.NewLine}", HistoryOper));
           tempfirst = result ?? "";tempsecond = ""; tempoper = "";
        }

        private void ceButton_Click(object sender, RoutedEventArgs e)
        {
            expressionTextBox.Text = ""; IOperation.comm = false;
        }

        private void arrowButton_Click(object sender, RoutedEventArgs e)
        {
            string str = expressionTextBox.Text;
            if (str.Last() == ',')
                IOperation.comm = false;
            if (str.Last() == '*' || str.Last() == '/' || str.Last() == '-' || str.Last() == '+')
                IOperation.oper = false;
            str = str.Remove(str.Length - 1);
            expressionTextBox.Text = str;
        }

        private void operButton_Click(object sender, RoutedEventArgs e)
        {
            string operation = ((Button)sender).Content.ToString()!;             
                //поставить first*(-second) если second пуст и оператор выражения уже есть
            if(expressionTextBox.Text == "" && operation == "-" )
            {
                expressionTextBox.Text += operation;
                tempminus = true;
                return;
            }
            if (tempfirst != "" && tempoper != "" && operation == "-" && tempminus == true)
            {
                GetNumbers(second: expressionTextBox.Text);
                if(tempsecond == "")
                {
                    // поместить в () и сдвинуть select после скобок
                    expressionTextBox.Text += operation;
                    tempminus = false;
                }
                return;
            }
            if (!IOperation.oper)
            {
                GetNumbers(expressionTextBox.Text, operation);
                expressionTextBox.Text += operation;
                IOperation.oper = true;
                IOperation.comm = false;
            }
        }
        public void GetNumbers(string first = "", string op = "" , string second = "")
        {
            if(first != "")
                tempfirst = first;
            if(op != "")
                tempoper = op;
            if(tempfirst != "" && tempoper != "" && second != "")
            {
                second = expressionTextBox.Text.Replace(tempfirst + tempoper, "");
                tempsecond = second;
            }
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

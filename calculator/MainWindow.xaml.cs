using Actions;
using ActionsOnExpressionStandart;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
        //05/1 = 5(если первым числом 0 то ставить запятую, если ставится запятая а перед ней нет числа ставить 0)
        private string operation { get;set; }
        private void numbersBtn_Click(object sender, RoutedEventArgs e)
        {
            expressionTextBox.Text += ((Button)sender).Content.ToString()!;
        }

        private void cButton_Click(object sender, RoutedEventArgs e)
        {
            historyEx.Document.Blocks.Clear();
            IOperation.historyOper.Clear();
        }

        private void commaButton_Click(object sender, RoutedEventArgs e)
        {
            if(!IOperation.comm)
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

            Standart standart = new Standart(new StringBuilder(expressionTextBox.Text), operation, out string? result, out List<string> historyOper);
            expressionTextBox.Text = result;
            HistoryOper = historyOper;
            historyEx.Document.Blocks.Clear();
            historyEx.AppendText(String.Join($"{Environment.NewLine}", HistoryOper));
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

            if (!IOperation.oper)
            {
                expressionTextBox.Text += operation;
                IOperation.oper = true;
                IOperation.comm = false;
            }
        }
    }
}

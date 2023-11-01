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
        private bool comm { get; set; }
        private bool oper { get; set; }
        private List<string> HistoryOper = new List<string>();
        private string Number = "";
        internal string number
        {
            get
            {
                return Number;

            }
            set
            {
                if (oper == true && (value == "*" || value == "/" || value == "-" || value == "+")) value = "";
                if (value == "*" || value == "/" || value == "-" || value == "+") oper = true;

                switch (value)
                {
                    case "," when comm == true: value = ""; break;
                    case "," when comm == false: comm = true; goto default;
                    case "*" when oper == true: comm = false; goto default;
                    case "/" when oper == true: comm = false; goto default;
                    case "-" when oper == true: comm = false; goto default;
                    case "+" when oper == true: comm = false; goto default;
                    case "←" when 
                    expressionTextBox.Text.Last() == '*' ||
                    expressionTextBox.Text.Last() == '/' ||
                    expressionTextBox.Text.Last() == '-' ||
                    expressionTextBox.Text.Last() == '+'
                    : oper = false; expressionTextBox.Text = expressionTextBox.Text.Remove(expressionTextBox.Text.Length - 1); break;
                    case "←": expressionTextBox.Text = expressionTextBox.Text.Remove(expressionTextBox.Text.Length - 1); break;
                    case "CE": expressionTextBox.Text = ""; break;
                    default: Number = value; expressionTextBox.Text += Number; break;
                }

            }
        }

        private string Operation = "";
        internal string operation
        {
            get
            {
                return Operation;
            }
            set
            {
                oper = false;
                Operation = value;               
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            number = ((Button)sender).Content.ToString()!;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            operation = ((Button)sender).Content.ToString()!;


            Standart standart = new Standart(new StringBuilder(expressionTextBox.Text), Operation, out string? result,out List<string> historyOper);
            expressionTextBox.Text = result;     
            HistoryOper = historyOper;
            historyEx.Document.Blocks.Clear();
            historyEx.AppendText(String.Join($"{Environment.NewLine}", HistoryOper));
        }

        private void cButton_Click(object sender, RoutedEventArgs e)
        {
            historyEx.Document.Blocks.Clear();
            IOperation.historyOper.Clear();
        }
    }
}

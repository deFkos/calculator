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
        private string Number = "";
        internal string number
        {
            get
            {
                return Number;

            }
            set
            {
                FormattingExpression frmExp = new FormattingExpression();
                (string val,string st) var = frmExp.format(value, expressionTextBox.Text);
                expressionTextBox.Text = var.st;
                value = var.val;

            }
        }
        //вводим первое значение, прожимается какой-либо оператор,
        //фиксируем значение, после нажатие "равно" фиксируем второе значение
        //Abstract?
        //Отдельный класс, без свойств 
        //не работает стрелка
        //05/1 = 5
        //ошибка если первое отрицательное
        //каждому оператору свой event
        //
        private string Operation = "";
        internal string operation
        {
            get
            {
                return Operation;
            }
            set
            {
                IOperation.oper = false;
                IOperation.comm = true;
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

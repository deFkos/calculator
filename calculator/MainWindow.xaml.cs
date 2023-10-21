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
        private string Number = "";
        internal string number
        {
            get
            {
                return Number;

            }
            set
            {
                Number = value;
                expressionTextBox.Text += Number;
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
                Operation = value;
                
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            number = ((Button)sender).Content.ToString();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            operation = ((Button)sender).Content.ToString();


            Standart standart = new Standart(new StringBuilder(expressionTextBox.Text), Operation, out string result);
            expressionTextBox.Text = result;       
        }
    }
}

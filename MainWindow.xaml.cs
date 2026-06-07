using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double no = 0;
        double no1 = 0;
       
        string op;
        bool opreater = false;
        bool equail;
        bool isClear;
        String mybutton;
        char[] opreaters = { '+', '-', '÷','×' };
        public MainWindow()
        {
            InitializeComponent();
            MyTextBlock1.Text = "";
            MyTextBlock2.Text = "";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (opreater)
            {
                MyTextBlock1.Text = "";
                opreater = false;
               

            }
            if(isClear)
            {
                MyTextBlock1.Text = "";
                isClear = false;
            }
           
            if(no1 != 0) 
            {
                MyTextBlock2.Text += sender.ToString().Substring(32);
            }
            if (equail)
            {
                MyTextBlock1.Text = "";
                equail = false;
            }

            MyTextBlock1.Text += sender.ToString().Substring(32);
             mybutton = MyTextBlock1.Text;
          
            


            


        }
        

        private void Button_Operater(object sender, RoutedEventArgs e)
        {

            string newOp = sender.ToString().Substring(32);

           
            if (no1 != 0 && !string.IsNullOrEmpty(op) && !opreater)
            {
                ExecuteCalculation(); 
            }
            else
            {
                no1 = double.Parse(MyTextBlock1.Text);
                MyTextBlock2.Text = $"{no1}";
            }
           

            

            if (newOp == "+")
            {
                    MyTextBlock2.Text += $" + ";

            }
            if (newOp == "*")
            {
                MyTextBlock2.Text += $" × ";

            }
            if (newOp == "/")
            {
                MyTextBlock2.Text += $" ÷ ";

            }
            if (newOp == "-")
            {
                MyTextBlock2.Text += $" - ";

            }


            op = newOp;

            opreater = true;


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ExecuteCalculation();
            MyTextBlock2.Text = ""; 
            op = "";
            no1 = 0;
            equail = true;
           
           

        }
        private void clear(object sender, RoutedEventArgs e)
        {
            MyTextBlock1.Text = "0";
            MyTextBlock2.Text = "";
            no1 = 0;
            isClear = true;
            


        }
        private void dot(object sender, RoutedEventArgs e)
        {
            double nobefore = double.Parse(MyTextBlock1.Text);
            MyTextBlock1.Text += ".";

        }
        private void percent(object sender, RoutedEventArgs e)
        {
            no = double.Parse(MyTextBlock1.Text);
            double noAfter = no / 100;
            no = noAfter;
            MyTextBlock1.Text = noAfter.ToString();
        }

        private void minus(object sender, RoutedEventArgs e)
        {
            double no1 = double.Parse(MyTextBlock1.Text);
            double noAfter = no1 * -1;
            MyTextBlock1.Text = noAfter.ToString();
        }
        private void ExecuteCalculation()
        {
            double sno = double.Parse(MyTextBlock1.Text);

            switch (op)
            {
                case "+": no1 = no1 + sno; break;
                case "-": no1 = no1 - sno; break;
                case "*": no1 = no1 * sno; break;
                case "/":
                    if (sno != 0) no1 = no1 / sno;
                    else MessageBox.Show("You can't divide no by zero","Error",MessageBoxButton.OK,MessageBoxImage.Warning);
                    break;
            }

            MyTextBlock1.Text = no1.ToString();
        }
    }
}
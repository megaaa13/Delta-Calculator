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

namespace DeltaCalcuation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (First.Text.Length == 0 || Second.Text.Length == 0 || Third.Text.Length == 0)
            {
                MessageBox.Show("Please enter a number first.");
                return;
            }
            if (IsNumber(First.Text) == false || IsNumber(Second.Text) == false || IsNumber(Third.Text) == false)
            {
                MessageBox.Show("Please no letters , no symbols , no whitespaces.");
                return;
            }
            int a = Convert.ToInt32(First.Text);
            int b = Convert.ToInt32(Second.Text);
            int c = Convert.ToInt32(Third.Text);
            Output.Visibility = Visibility.Visible;
            if (a + b + c == 0)
            {
                int x4 = 1;
                int x5 = c / a;
                string _forme = $"{a}(x-1)(x-{x5})";
                string forme = _forme.Replace("--", "+");
                string numm = $"{a} + {b} + {c} = 0".Replace("+ -", "-");
                Output.Content = $"Cas Particulier => {numm}\nRacine 1 = {x4}\nRacine 2 = {x5}\nForme factorisée = {forme}";
            }
            else if (a + c == b)
            {
                int x6 = -1;
                int x7 = -c / a;
                string _forme = $"{a}(x+1)(x-{x7})";
                string forme = _forme.Replace("--", "+");
                string numm = $"{a} + {c} = {b}".Replace("+ -", "-");
                Output.Content = $"Cas Particulier => {numm}\nRacine 1 = {x6}\nRacine 2 = {x7}\nForme factorisée = {forme}";
            }
            else
            {
                double deltadb = (b * b) - (4 * a * c);
                int delta = Convert.ToInt32(deltadb);
                if (delta > 0)
                {
                    double Sqr = Math.Sqrt(delta);
                    double xx1 = (-b - Sqr) / (2 * a);
                    int x1 = Convert.ToInt32(xx1);
                    double xx2 = (-b + Sqr) / (2 * a);
                    int x2 = Convert.ToInt32(xx2);
                    string _forme = $"{a}(x-{x1})(x-{x2})";
                    string forme = _forme.Replace("--", "+");
                    Output.Content = $"Delta = {delta}\nRacine 1 = {x1}\nRacine 2 = {x2}\nForme factorisée = {forme}";
                }
                else if (delta == 0)
                {
                    double xx3 = (-b) / (2 * a);
                    int x3 = Convert.ToInt32(xx3);
                    string _forme = $"{a}(x-{x3})²";
                    string forme = _forme.Replace("--", "+");
                    Output.Content = $"Delta = {delta}\nRacine double = {x3}\nForme factorisée = {forme}";
                }
                else if (delta < 0)
                {
                    Output.Content = $"Delta = {delta}\nPas de solutions";
                }

            }
        }

        private bool IsNumber(string textbox)
        {
            bool isnumber = textbox.All(c => "0123456789+-".Contains(c));
            return isnumber;
        }
    }
}


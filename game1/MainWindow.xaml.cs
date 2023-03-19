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

namespace game1
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void leveTlacitko(object sender, RoutedEventArgs e)
        {

        }

        private void praveTlacitko(object sender, RoutedEventArgs e)
        {

        }

        public static Array Number(int dif)
        {
            Random rand = new Random();
            int num1;
            int num2;

            char[] znamenka = new char[] { '+', '-', '÷', '×' };
            char znamenko = znamenka[rand.Next(znamenka.Length)];

            char znamenko2 = znamenka[rand.Next(znamenka.Length)];

            if (dif == 1)
            {
                num1 = rand.Next(0, 10);
                num2 = rand.Next(0, 10);
            }
            else if (dif == 2)
            {
                num1 = rand.Next(10, 100);
                num2 = rand.Next(10, 100);
            }
            else
            {
                num1 = rand.Next(50, 500);
                num2 = rand.Next(50, 500);
            }

            int result = 0;
            int fakeresult = 0;

            int num3 = rand.Next(-100, 500);

            num2 = rand.Next(50, 500);
            switch (znamenko)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '÷':
                    result = num1 / num2;
                    break;
                case '×':
                    result = num1 * num2;
                    break;
            }

            switch (znamenko2)
            {
                case '+':
                    fakeresult = result + num3;
                    break;
                case '-':
                    fakeresult = result - num3;
                    break;
                case '÷':
                    fakeresult = result / num3;
                    break;
                case '×':
                    fakeresult = result * num3;
                    break;
            }

            string priklad = num1.ToString() + znamenko + num2.ToString();
            string[] returnValues = new string[3] { priklad, result.ToString(), fakeresult.ToString() };
            return returnValues;
        }

    }
}

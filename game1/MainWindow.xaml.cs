using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// 

    class Variables
    {
        public static int lives { get; set; }
        public static int score { get; set; }

        public static string spravnyVysledek { get; set; }
    }
    public partial class MainWindow : Window
    {
       

       

        public MainWindow()
        {
            InitializeComponent();

            

             Variables.lives = 3;
            Variables.score = 0;

             
            GameInit();

    }
        

        private void GameInit()
        {
            if (Variables.lives > 0) {
                zivoty.Content = "Životy : " + Variables.lives;
                score.Content = "Score : " + Variables.score;

                

                if (Variables.score < 10)
                {
                    string[] values = (string[])Number(1);

                    priklad.Content = values[0];

                    progress.Value = Variables.score *10;


                    Random rand = new Random();
                    int position = rand.Next(0, 1);

                    Variables.spravnyVysledek = values[1];

                    if (position == 1)
                    {
                        leftButton.Content = values[1];
                        rightButton.Content = values[2];
                    }
                    else
                    {
                        leftButton.Content = values[2];
                        rightButton.Content = values[1];
                    }

                }

                else if (Variables.score < 20)
                {
                    string[] values = (string[])Number(2);

                    priklad.Content = values[0];

                    progress.Value = Variables.score *5;
                    Variables.spravnyVysledek = values[1];

                    Random rand = new Random();
                    int position = rand.Next(0, 1);

                    if (position == 1)
                    {
                        leftButton.Content = values[1];
                        rightButton.Content = values[2];
                    }
                    else
                    {
                        leftButton.Content = values[2];
                        rightButton.Content = values[1];
                    }

                }

                else
                {
                    string[] values = (string[])Number(3);

                    progress.Value = Variables.score;

                    priklad.Content = values[0];
                    Variables.spravnyVysledek = values[1];
                    Random rand = new Random();
                    int position = rand.Next(0, 1);

                    if (position == 1)
                    {
                        leftButton.Content = values[1];
                        rightButton.Content = values[2];
                    }
                    else
                    {
                        leftButton.Content = values[2];
                        rightButton.Content = values[1];
                    }

                }
            }
            
        }
        private void leveTlacitko(object sender, RoutedEventArgs e)
        {
            string BtnName;
            BtnName = (sender as System.Windows.Controls.Button).Content.ToString();

            if(Variables.spravnyVysledek == BtnName)
            {
                Console.WriteLine("spravne");
                Variables.score+=1;

                GameInit();
            }
            else
            {
                Console.WriteLine("spatne");

                Variables.lives -= 1;

                Console.WriteLine(Variables.lives);

                GameInit();
            }
           
        }

        private void praveTlacitko(object sender, RoutedEventArgs e)
        {
            string BtnName;
            BtnName = (sender as System.Windows.Controls.Button).Content.ToString();

            if (Variables.spravnyVysledek == BtnName)
            {
                Console.WriteLine("spravne");

                Variables.score+=1;
                GameInit();
            }
            else
            {
                Console.WriteLine("spatne");
                Variables.lives -= 1;
                Console.WriteLine(Variables.lives);


                GameInit();
            }
        }

        public static Array Number(int dif)
        {
            Random rand = new Random();
            int num1;
            int num2;

            char[] znamenka = new char[] { '+', '-', '÷', '×' };
            char[] znamenka2 = new char[] { '+', '-'};
            char znamenko = znamenka[rand.Next(znamenka.Length)];

            char znamenko2 = znamenka2[rand.Next(znamenka2.Length)];

            if (dif == 1)
            {
                num1 = rand.Next(1, 10);
                num2 = rand.Next(1, 10);
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

            int num3 = rand.Next(1, 10);

           
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
               
            }

            string priklad = num1.ToString() + znamenko + num2.ToString();
            string[] returnValues = new string[3] { priklad, result.ToString(), fakeresult.ToString() };
            return returnValues;
        }

    }
}

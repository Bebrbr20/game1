using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    // Definování proměných
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

            
            // Reset statistiky
            Variables.lives = 5;
            Variables.score = 0;

            //Zapsání do souboru
            //string text = Variables.lives + "," + Variables.score;
            //string path = @"./stats.txt";

            //Spuštění funkce pro začnutí hry
            GameInit();
    }
        
        private void GameInit()
        {
            // Kontrola, zda-li má hráč dostatek životů
            if (Variables.lives > 0) {
                zivoty.Content = "Životy : " + Variables.lives;
                score.Content = "Score : " + Variables.score;
             
                // Obtížnost dle score
                if (Variables.score < 10)
                {
                    string[] values = (string[])Number(1);
                    priklad.Content = values[0];

                    // Progress bar
                    progress.Value = Variables.score *10;

                    Random rand = new Random();
                    int position = rand.Next(0, 100);

                    Variables.spravnyVysledek = values[1];

                    // Zamíchání správného výsledku mezi tlačítka
                    if (position%2 == 0)
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

                    // Progress bar
                    progress.Value = Variables.score *5;

                    Variables.spravnyVysledek = values[1];

                    Random rand = new Random();
                    int position = rand.Next(0, 100);

                    // Zamíchání správného výsledku mezi tlačítka
                    if (position % 2 == 0)
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
                    priklad.Content = values[0];
                    Variables.spravnyVysledek = values[1];

                    // Progress bar
                    progress.Value = Variables.score;
               
                    Random rand = new Random();
                    int position = rand.Next(0, 100);

                    // Zamíchání správného výsledku mezi tlačítka
                    if (position % 2 == 0)
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
            else
            {
                priklad.Content = "Konec hry, vaše score bylo :" + Variables.score;
                leftButton.Content = "";
                rightButton.Content = "";
            }
        }
        
        //handler pro stisknutí tlačitka
        private void tlacitko(object sender, RoutedEventArgs e)
        {
            //zjištění value tlačítka
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

       
        // generátor příkladů
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

            // uložení do array a následný return
            string priklad = num1.ToString() + znamenko + num2.ToString();
            string[] returnValues = new string[3] { priklad, result.ToString(), fakeresult.ToString() };
            return returnValues;
        }

    }
}

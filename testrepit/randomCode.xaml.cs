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
using System.Windows.Shapes;

using System.Windows.Threading;

namespace testrepit
{
    /// <summary>
    /// Логика взаимодействия для randomCode.xaml
    /// </summary>
    public partial class randomCode : Window
    {
        public static int randNum { get; set; }
        public randomCode()
        {
            InitializeComponent();

            var timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Start();

            Random rand = new Random();
            randNum = rand.Next(10000000, 99999999);
            randomNumber.Text = randNum.ToString();

        }

        private void timer_tick(object sender, EventArgs e)
        {
            randNum = 111111111;
            Close();
            
        }
    }
}

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

namespace testrepit
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void inSign_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            using (var db = new testingUsersEntities())
            {
                var login = db.Users.AsNoTracking().FirstOrDefault(u => u.login == inputLogin.Text && u.password == inputPassword.Password);
                var pass = db.Users.AsNoTracking().FirstOrDefault(u => u.password == inputPassword.Password);

                if (inputLogin.Text.Length == 0)
                    MessageBox.Show("Вы не ввели логин");
                else
                {
                    if (inputPassword.Password.Length == 0)
                        MessageBox.Show("Вы не ввели пароль");

                    else
                    {
                        if (pass == null)
                        {
                            MessageBox.Show("Неверный пароль");
                        }
                        else
                        {
                            if (pass.isAdmin == true)
                            {
                                string inpCode = inputCode.Text.ToString();
                                string code = randomCode.randNum.ToString();


                                if (inpCode == code)
                                {
                                    admin ad = new admin();
                                    ad.Show();
                                    Close();
                                }
                                else
                                {
                                    MessageBox.Show("Неверный код!");
                                }

                            }


                            else if (pass.isAdmin == false)
                            {
                                string inputCod = inputCode.Text.ToString();
                                string randCode = randomCode.randNum.ToString();

                                if (randCode == inputCod)
                                {
                                    noAdmin none = new noAdmin();
                                    none.Show();
                                    Close();
                                }
                                else
                                {
                                    MessageBox.Show("Неверный код!");
                                }
                            }
                        }

                    }
                }
            } 

                
        
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void getCode_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new testingUsersEntities())
            {
                var login = db.Users.AsNoTracking().FirstOrDefault(u => u.login == inputLogin.Text && u.password == inputPassword.Password);
                var pass = db.Users.AsNoTracking().FirstOrDefault(u => u.password == inputPassword.Password);

                if (login == null)
                    MessageBox.Show("Пользователь не найден");

                else
                {
                    
                    if (pass == null)
                    {
                        MessageBox.Show("Неверный пароль!");
                    }
                    else if(pass != null)
                    {
                        inputCode.IsEnabled = true;
                        randomCode ran = new randomCode();
                        ran.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль");
                    }
                }
            }
            
            
            
        }

        private void inputLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if(inputLogin.Text.Length > 0)
                {
                    inputPassword.IsEnabled = true;
                    inputPassword.Focus();
                    
                }
                else
                {
                    MessageBox.Show("Вы не ввели логин!");
                }
            }
        }

        private void inputPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (inputPassword.Password.Length > 0)
                {
                    inputCode.IsEnabled = true;
                    inputCode.Focus();

                }
                else
                {
                    MessageBox.Show("Вы не ввели пароль!");
                }
            }
        }
    }
}

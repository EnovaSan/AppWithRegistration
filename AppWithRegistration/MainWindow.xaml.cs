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

namespace AppWithRegistration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        AppContext db;
        

        public MainWindow()
        {
            InitializeComponent();
            db = new AppContext();
            
            List<Registrater> registraters = db.Registraters.ToList();     //создание листа данных

            string enterData = "";                                         //ввод данных в список
            foreach (Registrater registrater in registraters)
                enterData += "Login: " + registrater.Login + " | ";

            exampleText.Text = enterData;
        }

        private void Button_SignUp(object sender, RoutedEventArgs e)       //обработчик события на кнопку "Sign Up"
        {
            string login = textBoxLogin.Text.Trim();                       //получение данных после их ввода пользователем
            string pass = passBox.Password.Trim();                         //Trim() = удаление пробелов после ввода данных
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim();

            if(login.Length < 5)                                              //если пользователь ввел данные не корректно
            {
                textBoxLogin.ToolTip = "The data is not entered correctly";   //текст об ошибке
                textBoxLogin.Background = Brushes.DarkRed;                    //замена цвета заднего фона
            }
            else if(pass.Length < 5)
            {
                passBox.ToolTip = "The data is not entered correctly";
                passBox.Background = Brushes.DarkRed;
            }
            else if(pass != pass_2)
            {
                passBox_2.ToolTip = "The data is not entered correctly";
                passBox_2.Background = Brushes.DarkRed;
            }
            else if(email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "The data is not entered correctly";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else                                                          //если пользователь ввел данные корректно
            {
                textBoxLogin.ToolTip = "";                                //отсутсвие сообщения об ощибке
                textBoxLogin.Background = Brushes.Transparent;            //задний фон остается прозрачным

                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;

                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Fine!");                                 //вывод сообщения о том, что все прошло успешно
                Registrater registrater = new Registrater(login, pass, email);            //создание объекта для добавления данных в таблицу



                db.Registraters.Add(registrater);            //работа программы с таблицей (добавление объекта в таблицу)
                db.SaveChanges();                     //сохранение новых данных
            }
        }
    }
}

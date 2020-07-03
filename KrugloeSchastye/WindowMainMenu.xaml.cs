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

namespace KrugloeSchastye
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WindowMainMenu : Window
    {
        string Login { get; set; }
        string Dates { get; set; }
        public WindowMainMenu(string Login, string Dates)
        {
            InitializeComponent();
            this.Login = Login;
            this.Dates = Dates;
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainmenu.Title = $"Главное меню / {Login} / {Dates} ";
        }

        private void BtnSotrudniki_Click(object sender, RoutedEventArgs e)
        {
            new WindowSotrudniki(Login, Dates).Show();
            Close();
        }
    }
}

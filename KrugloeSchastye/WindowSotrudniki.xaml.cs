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

namespace KrugloeSchastye
{
    /// <summary>
    /// Логика взаимодействия для WindowSotrudniki.xaml
    /// </summary>
    public partial class WindowSotrudniki : Window
    {
        string Login;
        string Dates;
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public WindowSotrudniki(string Login, string Dates)
        {
            InitializeComponent();
            this.Login = Login;
            this.Dates = Dates;
        }

        private void Sotrudniki_Loaded(object sender, RoutedEventArgs e)
        {
            sotrudniki.Title = $"Сотрудники / {Login} / {Dates}";
            DataGird.ItemsSource = db.Employee.ToList();
        }

        private void Sotrudniki_Closed(object sender, EventArgs e)
        {
            new WindowMainMenu(Login, Dates).Show();
        }
    }
}

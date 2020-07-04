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

namespace KrugloeSchastye
{
    /// <summary>
    /// Логика взаимодействия для WindowRestorans.xaml
    /// </summary>
    public partial class WindowRestorans : Window
    {
        string Login { get; set; }
        string Dates { get; set; }

        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();

        public WindowRestorans(string Login, string Dates)
        {
            InitializeComponent();
            this.Login = Login;
            this.Dates = Dates;
        }

        private void Restorans_Loaded(object sender, RoutedEventArgs e)
        {
            restorans.Title = $"Рестораны / {Login} / {Dates}";
            DataGird.ItemsSource = db.Restaurants.ToList();
        }

        private void Restorans_Closed(object sender, EventArgs e)
        {
            new WindowMainMenu(Login, Dates).Show();
            Close();
        }
    }
}

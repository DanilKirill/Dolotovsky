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
    /// Логика взаимодействия для WindowZakaz.xaml
    /// </summary>
    public partial class WindowZakaz : Window
    {
        string Login { get; set; }
        string Dates { get; set; }
        public WindowZakaz(string Login, string Dates)
        {
            InitializeComponent();
            this.Login = Login;
            this.Dates = Dates;
        }
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            zakaz.Title = $"Заказы / {Login} / {Dates} ";
            dgZakaz.ItemsSource = db.Zakazi.ToList();
        }

        private void Zakaz_Closed(object sender, EventArgs e)
        {
            new WindowMainMenu(Login, Dates).Show();
            Close();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            new WindowZakazCreate(Login, Dates).Show();
        }

        private void DgZakaz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Zakazi zak = dgZakaz.SelectedItem as Zakazi;
                int idz = Convert.ToInt32(zak.idZakaza);
                dgBluda.ItemsSource = db.ZakazBluda.Where(t => t.idZakaza == idz).ToList();
            }
            catch
            { }
        }
    }
}

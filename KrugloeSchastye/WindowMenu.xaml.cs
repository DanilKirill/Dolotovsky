using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для WindowMenu.xaml
    /// </summary>
    public partial class WindowMenu : Window
    {
        string Login { get; set; }
        string Dates { get; set; }
        public WindowMenu(string Login, string Dates)
        {
            InitializeComponent();
            this.Login = Login;
            this.Dates = Dates;
        }
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        ObservableCollection<Menu> listMenu = new ObservableCollection<Menu>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            menu.Title = $"Меню / {Login} / {Dates} ";
            DataGridM.ItemsSource = db.Menu.ToList();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            new WindowMainMenu(Login, Dates).Show();
            Close();
        }

        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listMenu.Clear();
                Razdeli rmenu = cbxRazdelMenu.SelectedItem as Razdeli;
                var menus = db.Menu;
                var queryMenu = from Menu in menus
                                where Menu.RazdelMenu == rmenu.idRazdel
                                select Menu;
                foreach (Menu men in queryMenu)
                {
                    listMenu.Add(men);
                }
                DataGridM.ItemsSource = listMenu;
            }
            catch
            {

            }
        }

        private void CbEnableSearch_Checked(object sender, RoutedEventArgs e)
        {
            if (cbEnableSearch.IsChecked == true)
            {
                btnSort.IsEnabled = true;
                cbxRazdelMenu.IsEnabled = true;
            }
            else if(cbEnableSearch.IsChecked == false)
            {
                btnSort.IsEnabled = false;
                cbxRazdelMenu.IsEnabled = false;
            }
        }

        private void CbEnableSearch_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbEnableSearch.IsChecked == true)
            {
                btnSort.IsEnabled = true;
                cbxRazdelMenu.IsEnabled = true;
            }
            else if (cbEnableSearch.IsChecked == false)
            {
                btnSort.IsEnabled = false;
                cbxRazdelMenu.IsEnabled = false;
            }
        }
    }
}

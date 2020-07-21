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
        ObservableCollection<Employee> listSotr = new ObservableCollection<Employee>();
        public WindowSotrudniki(string Login, string Dates)
        {
            InitializeComponent();
            this.Login = Login;
            this.Dates = Dates;
        }

        private void Sotrudniki_Loaded(object sender, RoutedEventArgs e)
        {
            sotrudniki.Title = $"Сотрудники / {Login} / {Dates}";
            DataGirdS.ItemsSource = db.Employee.ToList();
        }

        private void Sotrudniki_Closed(object sender, EventArgs e)
        {
            new WindowMainMenu(Login, Dates).Show();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            new SotrudnikCreate(Login, Dates).Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Employee sot = DataGirdS.SelectedItem as Employee;
            if (sot != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить сотрудника? ", "Предупреждение", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    db.Employee.Remove(sot);
                    DataGirdS.SelectedIndex = DataGirdS.SelectedIndex == 0 ? 1 : DataGirdS.SelectedIndex - 1;
                    listSotr.Remove(sot);
                    db.SaveChanges();
                    DataGirdS.ItemsSource = db.Employee.ToList();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления");
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DataGirdS.ItemsSource = db.Employee.ToList();
            DataGirdS.IsReadOnly = false;
            db.SaveChanges();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            DataGirdS.IsReadOnly = true;
            DataGirdS.BeginEdit();
        }
    }
}

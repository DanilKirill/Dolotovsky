using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для WindowZakazCreate.xaml
    /// </summary>
    public partial class WindowZakazCreate : Window
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        string Login { get; set; }
        string Dates { get; set; }

        public WindowZakazCreate(string Login, string Dates)
        {
            InitializeComponent();
            this.Login = Login;
            this.Dates = Dates;
        }

        string OpenZak;
        string CloseZak;
        int idZak;

        private void BtnCreateZakaz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Zakazi zak = new Zakazi();
                zak.Stol = Convert.ToInt32(cbxNameStol.SelectedIndex + 1);
                zak.SummaZakaza = 0;
                zak.DateOpenZakaz = DateTime.Parse(OpenZak);
                db.Zakazi.Add(zak);
                db.SaveChanges();
                btnCreateZakaz.IsEnabled = false;
                cbxNameStol.IsEnabled = false;
                dgZakaz.ItemsSource = db.Zakazi.ToList().ToArray();
            }
            catch
            {
                MessageBox.Show("Выберите стол");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            createZak.Title = $"Создание заказа / {Login} / {Dates}";
            dgZakaz.ItemsSource = db.Zakazi.ToList();
            OpenZak = DateTime.Now.ToString();

            txtTime.Text = $"Заказ открыт: {OpenZak} \nЗаказ закрыт: {CloseZak}";
        }

        private void BtnAddBluda_Click(object sender, RoutedEventArgs e)
        {
            Zakazi zakazi = dgZakaz.SelectedItem as Zakazi;
            if (zakazi == null)
                MessageBox.Show("Выберите строку заказа");
            else
            {
                idZak = Convert.ToInt32(zakazi.idZakaza);
                ZakazBluda zb = new ZakazBluda();
                zb.idZakaza = idZak;
                zb.NameBludo = Convert.ToInt32(cbxNameBludo.SelectedIndex);
                zb.Kolvo = Convert.ToInt32(txtbxCount.Text);
                zb.Cena = Convert.ToInt32(txtbxPrice.Text);
                zb.Summa = Convert.ToInt32(txtbxSumma.Text);
                db.ZakazBluda.Add(zb);
                db.SaveChanges();
                dgBluda.ItemsSource = db.ZakazBluda.Where(t => t.idZakaza == idZak).ToList().ToArray();
            }
        }

        private void CbxNameBludo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int cbx = cbxNameBludo.SelectedIndex;
            //txtbxPrice.Text = db.Menu.Where(t => t.idBluda == cbx).Select(t => t.Price).ToString();
        }   

        private void TxtbxCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                txtbxSumma.Text = Convert.ToString(Convert.ToInt32(txtbxPrice.Text) * Convert.ToInt32(txtbxCount.Text));
            }
            catch
            { }
        }

        private void TxtbxPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                txtbxSumma.Text = Convert.ToString(Convert.ToInt32(txtbxPrice.Text) * Convert.ToInt32(txtbxCount.Text));
            }
            catch
            { }
        }

        private void BtnProveden_Click(object sender, RoutedEventArgs e)
        {
            CloseZak = DateTime.Now.ToString();
            txtTime.Text = $"Заказ открыт: {OpenZak} \nЗаказ закрыт: {CloseZak}";
            var g = db.Zakazi;
            var q =
                from s in g
                where s.idZakaza == idZak
                select s;
            foreach (var item in q)
            {
                item.DateCloseZakaz = DateTime.Parse(CloseZak);
            }
            db.SaveChanges();
            Close();
        }

        private void DgZakaz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Zakazi zak = dgZakaz.SelectedItem as Zakazi;
                int idz = Convert.ToInt32(zak.idZakaza);
                dgBluda.ItemsSource = db.ZakazBluda.Where(t => t.idZakaza == idz).ToList().ToArray();
            }
            catch
            { }
        }
    }
}

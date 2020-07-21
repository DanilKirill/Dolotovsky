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
    /// Логика взаимодействия для SotrudnikCreate.xaml
    /// </summary>
    public partial class SotrudnikCreate : Window
    {
        string Login { get; set; }
        string Dates { get; set; }
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public SotrudnikCreate(string Login, string Dates)
        {
            InitializeComponent();
            this.Login = Login;
            this.Dates = Dates;
        }

        private void CreateSotrudniks_Closed(object sender, EventArgs e)
        {

        }

        private void CreateSotrudniks_Loaded(object sender, RoutedEventArgs e)
        {
            createSotrudniks.Title = $"Создание сотрудника / {Login} / {Dates}";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee emp = new Employee();
                emp.Name = Convert.ToString(txtbxName.Text);
                emp.Surname = Convert.ToString(txtbxSurname.Text);
                emp.Patronymic = Convert.ToString(txtbxPatronymic.Text);
                emp.Telephone = Convert.ToString(txtbxTelephone.Text);
                emp.Restoran = Convert.ToInt32(cbxListRestorans.SelectedIndex + 1);
                emp.BirthDate = DateTime.Parse(dpBirthDate.Text);
                db.Employee.Add(emp);
                db.SaveChanges();
                Close();
            }
            catch (Exception error)
            {
                MessageBox.Show($"{error}", "Ошибка!");
            }
        }
    }
}

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

namespace magazin
{
    /// <summary>
    /// Логика взаимодействия для Registratia.xaml
    /// </summary>
    public partial class Registratia : Window
    {
        public Registratia()
        {
            InitializeComponent();
            //var data = position.getAll();
            //rol.ItemsSource = data;
            //rol.DisplayMemberPath = "name_position";
            //rol.SelectedValuePath = "id";
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string familia = fam.Text;
            string im = ima.Text;
            string log = login.Text;
            string pass = password.Password;

            if (familia.Length == 0 || familia.Length > 11 || !char.IsUpper(familia.ToCharArray()[0]))
            {
                fam.ToolTip = "Введено не норектно";
                fam.Background = Brushes.Red;
            }
            else if (im.Length == 0 || im.Length > 12 || !char.IsUpper(im.ToCharArray()[0]))
            {
                ima.ToolTip = "Введено не норектно";
                ima.Background = Brushes.Red;
            }
            else if (log.Length == 0 || log.Length > 20 || !char.IsUpper(log.ToCharArray()[0]))
            {
                login.ToolTip = "Введено не норектно";
                login.Background = Brushes.Red;
            }
            else if (pass.Length < 7 || pass.Length > 10 || !char.IsUpper(pass.ToCharArray()[0]))
            {
                password.ToolTip = "Введено не норектно";
                password.Background = Brushes.Red;
            }
            else
            {
                fam.ToolTip = "";
                fam.Background = Brushes.Transparent;
                ima.ToolTip = "";
                ima.Background = Brushes.Transparent;
                password.ToolTip = "";
                password.Background = Brushes.Transparent;
                login.ToolTip = "";
                login.Background = Brushes.Transparent;
                MessageBox.Show("kruta");

                User dann = new User();
                dann.surname = familia;
                dann.name = im;
                dann.login = log;
                dann.password = pass;
                dann.save();


            }


            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow taskWindow = new MainWindow();
            taskWindow.Show();
            this.Close();
        }
    }
}

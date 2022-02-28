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

namespace magazin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registratia taskWindow2 = new Registratia();
            taskWindow2.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string log = logg.Text;
            string pass = passh.Password;
            if (log.Length == 0 || log.Length > 20 || !char.IsUpper(log.ToCharArray()[0]))
            {
                logg.ToolTip = "Введено не норектно";
                logg.Background = Brushes.Red;
            }
            else if (pass.Length < 7 || pass.Length > 10 || !char.IsUpper(pass.ToCharArray()[0]))
            {
                passh.ToolTip = "Введено не норектно";
                passh.Background = Brushes.Red;
            }
            else
            {

                passh.ToolTip = "";
                passh.Background = Brushes.Transparent;
                logg.ToolTip = "";
                logg.Background = Brushes.Transparent;
            }
            User users = User.getByLoginPassword(log, pass);
            if (log == "admin" && pass == "admin")
            {
                WindowAdmin f4 = new WindowAdmin();
                f4.Show();
                Hide();
            }
            else
            {
                User user = User.getByLoginPassword(log, pass);
                if (user.exists())
                {
                    WindowUser f4 = new WindowUser(user);
                    f4.Show();
                    Hide();
                }
            }
            
            


        }
    }
}

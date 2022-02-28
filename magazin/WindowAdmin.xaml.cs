using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace magazin
{
    /// <summary>
    /// Логика взаимодействия для WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {


        public WindowAdmin()
        {
            InitializeComponent();
            var data = new ObservableCollection<Tovar>(Tovar.getAll());
            spisok.ItemsSource = data;
            spisok.DisplayMemberPath = "on";



        }



        private void dobavlenye_Click(object sender, RoutedEventArgs e)
        {
            string nazvine = naimenovanie.Text;
            string opisan = opisanie.Text;

            if (nazvine.Length == 0 || nazvine.Length > 255 || !char.IsUpper(nazvine.ToCharArray()[0]))
            {
                naimenovanie.ToolTip = "Введено не норектно";
                naimenovanie.Background = Brushes.Red;
            }
            else if (opisan.Length == 0 || opisan.Length > 255 || !char.IsUpper(opisan.ToCharArray()[0]))
            {
                opisanie.ToolTip = "Введено не норектно";
                opisanie.Background = Brushes.Red;
            }
            else
            {
                naimenovanie.ToolTip = "";
                naimenovanie.Background = Brushes.Transparent;
                opisanie.ToolTip = "";
                opisanie.Background = Brushes.Transparent;
                MessageBox.Show("molodec");

                Tovar dann = new Tovar();
                dann.nazvania = nazvine;
                dann.opisanie = opisan;
                dann.save();


            }


        }

        private void spisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            naimenovanie.Text = "";
            opisanie.Text = "";
            if (spisok.SelectedItem != null)
            {
                Tovar tov = (Tovar)spisok.SelectedItem;
                naimenovanie.Text = tov.nazvania;
                opisanie.Text = tov.opisanie;
            }


        }

        private void redaktirovanie_Click(object sender, RoutedEventArgs e)
        {
            string nazvine = naimenovanie.Text;
            string opisan = opisanie.Text;
            if (spisok.SelectedItem != null)
            {
                Tovar tov = (Tovar)spisok.SelectedItem;
                tov.nazvania = nazvine;
                tov.opisanie = opisan;
                tov.save();
            }
        }

        private void ydalenye_Click(object sender, RoutedEventArgs e)
        {
            if (spisok.SelectedItem != null)
            {
                Tovar tov = (Tovar)spisok.SelectedItem;
                tov.delete();
            }
        }

        private void updown_Click(object sender, RoutedEventArgs e)
        {
            var data = new ObservableCollection<Tovar>(Tovar.getAll());
            spisok.ItemsSource = data;


        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow f4 = new MainWindow();
            f4.Show();
            Hide();

        }
    }
}

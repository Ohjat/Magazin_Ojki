
using System.Collections.ObjectModel;

using System;

using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;

namespace magazin
{
    /// <summary>
    /// Логика взаимодействия для WindowUser.xaml
    /// </summary>
    public partial class WindowUser : System.Windows.Window
    {
        ObservableCollection<Tovar> tovars;

        private readonly string TemplainFind = @"C:\Test\test.docx";

        public WindowUser(User user) 


        {
            InitializeComponent();
            tovars = new ObservableCollection<Tovar>(Tovar.getAll());
            
            spisok.ItemsSource = tovars;
            spisok.DisplayMemberPath = "on";

            
          


            _user = user;

        }
        private User _user;


        private void dobavit_Click(object sender, RoutedEventArgs e)
        {
            spisok2.Items.Add(tovars[spisok.SelectedIndex]);
           

        }

        private void spisok2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void delite_Click(object sender, RoutedEventArgs e)
        {
            if (spisok2.SelectedItem != null)
            {
                spisok2.Items.Remove(spisok2.SelectedItem);
            }
        }

        private void zakaz_Click(object sender, RoutedEventArgs e)
        {
           
            string maill = maile.Text;

            Zakaz zak = new Zakaz();
            zak.id_polzovatel = _user.polzovatel;
            zak.save();

            

            foreach (object cpic in spisok2.Items) {
                
                    zakaz_tovar zas = new zakaz_tovar();
                    zas.id_zakaz = zak.id_polzovatel;
                    zas.id_tovar = (cpic as Tovar).tovar;
                    zas.save();

                MessageBox.Show("ваш заказ сформирован");


            }

            Mail mli = new Mail();
            mli.napisanie = maill;
            mli.save();


            



            var worobl = new Word.Application();
            worobl.Visible = false;

            try
            {
                var wordvar = worobl.Documents.Open(TemplainFind);
                Replase("{spisok}", maile.Text, wordvar);
                Replase("{name}", _user.name, wordvar);

                wordvar.SaveAs(@"C:\Test\Dokument.docx");
                worobl.Visible = true;
            }
            catch
            {
                MessageBox.Show("чето не так");
            }

        }

        private void Replase(string stub , string text , Word.Document WordDok)
        {
            var ranfe = WordDok.Content;
            ranfe.Find.ClearFormatting();
            ranfe.Find.Execute(FindText: stub, ReplaceWith: text);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow f4 = new MainWindow();
            f4.Show();
            Hide();

        }

      
        

      
    }
}
//SmtpClient client = new SmtpClient();
//client.UseDefaultCredentials = false;
//client.Port = 465;
//client.EnableSsl = true;
//client.DeliveryFormat = SmtpDeliveryFormat.International;
//client.DeliveryMethod = SmtpDeliveryMethod.Network;
//client.Host = "smtp.mail.ru";
//client.Credentials = new NetworkCredential("rekvizitor02@mail.ru", "");

//MailMessage mailMessage = new MailMessage();
//mailMessage.From = new MailAddress("");
//mailMessage.To.Add(maill);
//mailMessage.Body = "Разметка";
//mailMessage.Subject = "Заголовок";
//mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
//mailMessage.BodyTransferEncoding = System.Net.Mime.TransferEncoding.Base64;
//mailMessage.IsBodyHtml = true;
//mailMessage.Priority = MailPriority.Normal;
//mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

//client.Send(mailMessage);
//client.Dispose();




//Client.Credentials = new NetworkCredential("Prokudinfedor03@mail.ru", "");
//Client.EnableSsl = true;
//MailMessage mail = new MailMessage();
//mail.From = new MailAddress("Prokudinfedor03@mail.ru");
//mail.To.Add ( new MailAddress(maill));
//mail.Subject = "Test";
//mail.Body = _user.polzovatel.ToString();
//Client.Send(mail);


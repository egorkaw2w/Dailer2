using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dailer2;

namespace Dailer2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        DateTime day;
        List<Zametki> tips = new List<Zametki>();


        public MainWindow()
        {
            InitializeComponent();
            DateTime day = DateTime.Now;
            Calendar.Text = day.ToString("d");
            deserial();
            Tipsi.ItemsSource = null;

            Tipsi.ItemsSource = tips;
        }

        private void Deleter_Click(object sender, RoutedEventArgs e)
        {

            tips.Remove(Tipsi.SelectedItem as Zametki);
            Serializator.Write(tips, Convert.ToDateTime(Calendar.Text).ToString("d") + ".json");
            tips = Serializator.Read<List<Zametki>>(Convert.ToDateTime(Calendar.Text).ToString("d") + ".json");
            Tipsi.ItemsSource = tips;

        }

        private void Creater_Click(object sender, RoutedEventArgs e)
        {
            string num = NameTip.Text;
            string desc = DescTip.Text;
            DateTime time = Convert.ToDateTime(Calendar.Text);
            deserial();
            if (num != "" && desc != "" && Calendar.Text != "")
            {
                Zametki zametka = new Zametki(num, desc, time);

                tips.Add(zametka);
                Serializator.Write(tips, time.ToString("d") + ".json");
                Tipsi.ItemsSource = null;
                Tipsi.ItemsSource = tips;
            }
            else
            {
                MessageBox.Show("Еблан?");
            }
        }

        private void Saver_Click(object sender, RoutedEventArgs e)
        {
            Tipsi.ItemsSource = null;
            Tipsi.ItemsSource = tips;
        }



        private void NameTip_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DescTip_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void Calendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            deserial();
        }
        public void deserial()
        {
            try
            {
                tips = Serializator.Read<List<Zametki>>(Convert.ToDateTime(Calendar.Text).ToString("d") + ".json");

            }
            catch
            {
                tips = new List<Zametki>();
            }
            Tipsi.ItemsSource = tips;

        }

        private void Tipsi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Zametki info = (Tipsi.SelectedItem as Zametki);
            if (info == null)
            {
                NameTip.Text = "";
                DescTip.Text = "";
            }
            else
            {
                NameTip.Text = info.name;
                DescTip.Text = info.description;
            }

        }
    }

}
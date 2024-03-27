using System.Windows;
using System.Windows.Controls;

namespace MusicShool.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void BtnLog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Navigation.mainFrame.Navigate(new AutorizationEmployee());
        }
    }
}

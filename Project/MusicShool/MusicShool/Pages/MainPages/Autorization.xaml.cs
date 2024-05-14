using MusicShool.Pages.StudentPages;
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
            Navigation.mainFrame.Navigate(new StudentMainPage());
        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Navigation.mainFrame.Navigate(new AutorizationEmployee());
        }

        private void psbcheck_Checked(object sender, RoutedEventArgs e)
        {
            psbbox.PasswordChar = '\0';
        }
    }
}

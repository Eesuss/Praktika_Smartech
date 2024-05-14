using MusicShool.Pages.AdminPages;
using System.Windows.Controls;

namespace MusicShool.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class AutorizationEmployee : Page
    {
        public AutorizationEmployee()
        {
            InitializeComponent();
        }

        private void BtnLog_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Navigation.mainFrame.Navigate(new CreateLessonPage());

            //try
            //{
            //    Get get = new Get();
            //    var userData = get.AutorizAsync($"Users/{Login.Text} {Password.Password}");
            //    if (userData != null)
            //    {
            //        switch (userData.IdPost)
            //        {
            //            case 1:
            //                Navigation.mainFrame.Navigate(new Employees()); break;
            //            case 2:
            //                Navigation.mainFrame.Navigate(new TeacherPage()); break;
            //        }
            //    }
            //}
            //catch (NullReferenceException ex) { return; }


        }
    }
}

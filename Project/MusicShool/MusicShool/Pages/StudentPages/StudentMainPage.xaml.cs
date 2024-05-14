using System.Windows.Controls;
using System.Windows.Input;

namespace MusicShool.Pages.StudentPages
{
    /// <summary>
    /// Логика взаимодействия для StudentMainPage.xaml
    /// </summary>
    public partial class StudentMainPage : Page
    {
        public StudentMainPage()
        {
            InitializeComponent();
        }

        private void MenuPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Navigation.mainFrame.Navigate(new FirstCourse());
        }
    }
}

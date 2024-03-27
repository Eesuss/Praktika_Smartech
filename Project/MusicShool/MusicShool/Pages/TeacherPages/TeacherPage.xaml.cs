using MusicShool.Calen;
using System.Windows.Controls;

namespace MusicShool.Pages.TeacherPages
{
    /// <summary>
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        private readonly CalendarBackround background;
        public TeacherPage()
        {
            InitializeComponent();
            Kalender.IsTodayHighlighted = false;
            background = new CalendarBackround(Kalender);

            background.AddOverlay("circle", "/Resources/Images/Calend/circle.png");
            background.AddOverlay("tjek", "/Resources/Images/Calend/tjek.png");
            background.AddOverlay("cross", "/Resources/Images/Calend/cross.png");
            background.AddOverlay("box", "/Resources/Images/Calend/box.png");
            background.AddOverlay("gray", "/Resources/Images/Calend/gray.png");
        }
    }
}

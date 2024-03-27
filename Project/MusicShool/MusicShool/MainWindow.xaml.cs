using MusicShool.Pages.MainPages;
using System;
using System.Windows;

namespace MusicShool
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigation.mainFrame = FrmMain;
            FrmMain.Navigate(new Autorization());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrmMain.GoBack();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Вам некуда отсупать, остановитесь", "Стоп", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
        }
    }
}

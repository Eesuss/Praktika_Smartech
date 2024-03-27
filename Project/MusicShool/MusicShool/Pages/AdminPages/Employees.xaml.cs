using MusicShool.Entities;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MusicShool.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        public Employees()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            _ = pst();
        }

        private async Task pst()
        {
            DB.Queries.Post.Post post = new DB.Queries.Post.Post();
            try
            {
                User user = new User()
                {
                    LastName = lstnamebox.Text,
                    FirstName = FirstNamebox.Text,
                    MiddleName = Patronomicbox.Text,
                    IdPost = Cmb.SelectedIndex + 1,
                    Password = pswbox.Password,
                };

                // Отправка POST-запроса
                string response = await post.PostData(user, "Users/PostUser");
                Console.WriteLine($"Response from server: {response}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

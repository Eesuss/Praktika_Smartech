using MusicShool.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicShool.DB.Queries.Post
{
    public class Post
    {
        public static readonly string SvcIP = "https://localhost:7050/api/";
        public async Task<string> PostData(User user, string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonData = JsonConvert.SerializeObject(user);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync($"{SvcIP}{endpoint}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "IS SERVER RUNNING AT THE PORT?");
                    return null;
                }
            }
        }
    }
}

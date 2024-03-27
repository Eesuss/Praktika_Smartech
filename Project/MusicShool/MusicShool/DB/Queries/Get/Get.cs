using MusicShool.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;

namespace MusicShool.DB.Queries.Get
{
    public class Get
    {
        public static readonly string SvcIP = "https://localhost:7050/api/";


        public IList<T> LoadAll<T>(T entity, string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync($"{SvcIP}{endpoint}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsAsync<IList<T>>().Result;
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

        public User AutorizAsync(string endpoint)
        {
            // make an API request 
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync($"{SvcIP}{endpoint}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsAsync<User>().Result;
                    }
                    else
                        return default(User);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "IS SERVER RUNNING AT THE PORT?");
                    return default(User);
                }
            }
        }
    }
}
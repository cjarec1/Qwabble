﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class RestService
{
    HttpClient client;


    public RestService()
    {
        var authData = string.Format("{0}:{1}", "test", "pswd");
        var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

        client = new HttpClient();
        client.MaxResponseContentBufferSize = 256000;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
    }

    public async Task<string> GetCall(string url)
    {

        // RestUrl = http://developer.xamarin.com:8081/api/todoitems{0}
        var uri = new Uri(string.Format(url, string.Empty));
        string response = "Could not connect to server";// = await client.GetAsync(uri);
        try
        {
            response = (await client.GetAsync(uri)).ToString();

        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"				ERROR {0}", ex.Message);
        }

        return response;
    }

    public async Task PostCall(string body, string uri)
    {
        // RestUrl = http://developer.xamarin.com:8081/api/todoitems{0}

        try
        {
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await client.PostAsync(uri, content);


            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"				TodoItem successfully saved.");
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"				ERROR {0}", ex.Message);
        }
    }

}

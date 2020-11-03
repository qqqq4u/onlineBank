﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CommunicationEntities;
using Newtonsoft.Json;

namespace ClientLibrary
{
    public class Client
    {
        private HttpClient httpClient;

        public Client()
        {
            httpClient = new HttpClient();
        }

        public async Task<Response> RetrieveServerResponseAsync(Request request)
        {
            string data = JsonConvert.SerializeObject(request);

            StringContent content = new StringContent(data, Encoding.UTF8,"application/json");

            HttpResponseMessage responseMessage = await httpClient.PostAsync("http://localhost:21378/connection/", content);


            string responseJson = await responseMessage.Content.ReadAsStringAsync();


            return JsonConvert.DeserializeObject<Response>(responseJson);
        }
    }
}
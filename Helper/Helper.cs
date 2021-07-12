using System;
using System.Net.Http;

namespace e_shop.Client.Helper
{
    public class ProdutosAPI
    {
        public HttpClient initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44364/");
            return client;
        }
    }
}

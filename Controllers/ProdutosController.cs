using e_shop.Client.Helper;
using e_shop.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace e_shop.Client.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        ProdutosAPI _api = new();

        public async Task<IActionResult> Atualiza()
        {
            List<Produto> produtos = new List<Produto>();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("api/produtos");

            if (res.IsSuccessStatusCode)
            {
                var resultados = res.Content.ReadAsStringAsync().Result;
                produtos = JsonConvert.DeserializeObject<List<Produto>>(resultados);
            }
            else
            {
                return Error();
            }

            return View(produtos);
        }

        public async Task<IActionResult> Cria()
        {
            List<Produto> produtos = new List<Produto>();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("api/produtos");

            if (res.IsSuccessStatusCode)
            {
                var resultados = res.Content.ReadAsStringAsync().Result;
                produtos = JsonConvert.DeserializeObject<List<Produto>>(resultados);
            }
            else
            {
                return Error();
            }

            return View(produtos);
        }

        public async Task<IActionResult> Deleta()
        {
            List<Produto> produtos = new List<Produto>();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("api/produtos");

            if (res.IsSuccessStatusCode)
            {
                var resultados = res.Content.ReadAsStringAsync().Result;
                produtos = JsonConvert.DeserializeObject<List<Produto>>(resultados);
            }
            else
            {
                return Error();
            }

            return View(produtos);
        }

        public async Task<IActionResult> Lista()
        {
            List<Produto> produtos = new List<Produto>();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("api/produtos");

            if (res.IsSuccessStatusCode)
            {
                var resultados = res.Content.ReadAsStringAsync().Result;
                produtos = JsonConvert.DeserializeObject<List<Produto>>(resultados);
            }
            else
            {
                return Error();
            }

            return View(produtos);
        }

        public async Task<IActionResult> Detalhes()
        {
            List<Produto> produtos = new List<Produto>();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("api/produtos");

            if (res.IsSuccessStatusCode)
            {
                var resultados = res.Content.ReadAsStringAsync().Result;
                produtos = JsonConvert.DeserializeObject<List<Produto>>(resultados);
            }
            else
            {
                return Error();
            }

            return View(produtos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

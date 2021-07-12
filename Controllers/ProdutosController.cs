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
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace e_shop.Client.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        ProdutosAPI _api = new();

        public async Task<IActionResult> Update()
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            HttpClient client = _api.initial();

            // HTTP POST
            var postTask = client.PostAsJsonAsync<Produto>("api/produtos", produto);
            postTask.Wait();

            var res = postTask.Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return Error();
            }
        }

        public async Task<IActionResult> Delete()
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

        public async Task<IActionResult> List()
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

        public async Task<IActionResult> Details(int Id)
        {
            var produto = new Produto();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync($"api/produtos/{Id}");

            if (res.IsSuccessStatusCode)
            {
                var resultado = res.Content.ReadAsStringAsync().Result;
                produto = JsonConvert.DeserializeObject<Produto>(resultado);
            }
            else
            {
                return Error();
            }

            return View(produto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

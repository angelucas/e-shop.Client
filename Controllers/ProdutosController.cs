using e_shop.Client.Helper;
using e_shop.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace e_shop.Client.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IToastNotification toastNotification;
        ProdutosAPI _api = new();

        public ProdutosController(IToastNotification toastNotification) 
        {
            this.toastNotification = toastNotification;
        }

        // UPDATE
        public IActionResult Update(Produto produto)
        {
            HttpClient client = _api.initial();

            // http put
            var putTask = client.PutAsJsonAsync<Produto>($"api/produtos/{produto.ProdutoId}", produto);
            putTask.Wait();

            var res = putTask.Result;
            if (res.IsSuccessStatusCode)
            {
                toastNotification.AddSuccessToastMessage("Item atualizado!");
                return RedirectToAction("List");
            }
            else
            {
                toastNotification.AddErrorToastMessage("Ops! Erro ao criar.");
                return Error();
            }
        }

        // UPDATE
        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var produto = new Produto();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync($"api/produtos/{Id}");

            if (res.IsSuccessStatusCode)
            {
                var resultado = res.Content.ReadAsStringAsync().Result;
                produto = JsonConvert.DeserializeObject<Produto>(resultado);
                return View(produto);
            }
            else
            {
                toastNotification.AddErrorToastMessage("Ops! Erro ao atualizar.");
                return Error();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        // CREATE
        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            HttpClient client = _api.initial();

            // http post
            var postTask = client.PostAsJsonAsync<Produto>("api/produtos", produto);
            postTask.Wait();

            var res = postTask.Result;
            if (res.IsSuccessStatusCode)
            {
                toastNotification.AddSuccessToastMessage("Item adicionado com sucesso!");
                return RedirectToAction("List");
            }
            else
            {
                toastNotification.AddErrorToastMessage("Ops! Erro ao criar.");
                return Error();
            }
        }

        // DELETE
        public async Task<IActionResult> Delete(int Id)
        {
            var produto = new Produto();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/produtos/{Id}");

            if (res.IsSuccessStatusCode)
            {
                toastNotification.AddWarningToastMessage("Item deletado!");
                return RedirectToAction("List");
            }
            else
            {
                toastNotification.AddErrorToastMessage("Ops! Erro ao deletar.");
                return Error();
            }
        }

        // LIST
        [HttpGet]
        public async Task<IActionResult> List()
        {
            List<Produto> produtos = new List<Produto>();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("api/produtos");

            if (res.IsSuccessStatusCode)
            {
                var resultados = res.Content.ReadAsStringAsync().Result;
                produtos = JsonConvert.DeserializeObject<List<Produto>>(resultados);

                return View(produtos);
            }
            else
            {
                toastNotification.AddErrorToastMessage("Ops! Erro ao listar.");
                return Error();
            }
        }

        // DETAILS
        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var produto = new Produto();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync($"api/produtos/{Id}");

            if (res.IsSuccessStatusCode)
            {
                var resultado = res.Content.ReadAsStringAsync().Result;
                produto = JsonConvert.DeserializeObject<Produto>(resultado);

                return View(produto);
            }
            else
            {
                toastNotification.AddErrorToastMessage("Ops! Erro ao mostrar.");
                return Error();
            }
        }

        // ERROR
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

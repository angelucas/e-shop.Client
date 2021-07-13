using e_shop.Client.Helper;
using e_shop.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NToastNotify;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace e_shop.Client.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IToastNotification toastNotification;
        ProdutosAPI _api = new();

        public HomeController(ILogger<HomeController> logger, IToastNotification toastNotification)
        {
            _logger = logger;
            this.toastNotification = toastNotification;
        }
        
        public async Task<IActionResult> IndexAsync()
        {
            // TOASTER
            if (User.Identity.IsAuthenticated)
            {
                toastNotification.AddInfoToastMessage("Seja Bem-Vindo!");
            }

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
                return NotFound();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

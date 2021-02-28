using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hotsite.Models;
using MySql.Data.MySqlClient;

namespace Hotsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogWarning("isso é um alerta!!");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Interesse cad)
        {
            try{
            DatabaseService dbs = new DatabaseService();
            dbs.CadastraInteresse(cad);
             return Json(new {Status = "OK"});   
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return Json(new {Status = "ERR", Mensagem = "Deu ruim heim...falhouuuuu o banco de dados !!!"});
                
            }
            
            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        

    }
}

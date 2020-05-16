using OroGolden.WebApp.Business;
using OroGolden.WebApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebOroGold.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(EntGolden e)
        {
            try
            {
                BusGolden bus = new BusGolden();
                bus.NombreRepetido(e);
                bus.Agregar(e);                
                TempData["msj"] = "Tu cita esta confirmada " +e.Nombre;
                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Index");
            }
        }


    }
}
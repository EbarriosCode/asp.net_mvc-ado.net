using Model.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class DefaultController : Controller
    {
        private UsuarioLogic userLogic = new UsuarioLogic();
         
        // GET: Default
        public ActionResult Index()
        {
            return View(userLogic.Listar());
        }
    }
}
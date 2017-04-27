using Model.Entity;
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
        private RolLogic rolLogic = new RolLogic();
        // GET: Default
        [HttpGet]
        public ActionResult Index()
        {
            return View(userLogic.Listar());
        }

        public ActionResult Editar(int id)
        {
            ViewBag.Roles = rolLogic.ListarRoles();
            return View(id == 0 ? new Usuario() : userLogic.ObtenerUsuario(id));
        }

        public ActionResult Guardar(Usuario user)
        {
            try
            {
                var registro = user.id > 0 ?
                          userLogic.editarUsuario(user) :
                          userLogic.crearUsuario(user);

                return Redirect("~/");
            }
            catch (Exception ex)
            {
                return View("Error");
            }       
        }


    }
}
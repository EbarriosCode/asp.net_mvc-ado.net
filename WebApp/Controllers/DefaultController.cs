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
            //int registro = 0;            
            if (ModelState.IsValid)
            {
                if (user.id > 0)
                    userLogic.editarUsuario(user);

                else
                    userLogic.crearUsuario(user);

                return Redirect("~/");
            }

            else
            {
                //ViewBag.Error = user.id+" "+user.nombre + " " + user.apellido + " " + user.fechaNacimiento+" "+user.idRol;
                ViewBag.Error = "Ha ocurrido un error";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }
        }

        public ActionResult Eliminar(int id)
        {
            var resultado = userLogic.eliminarUsuario(id);

            if(!resultado)
            {
                ViewBag.Error = "Ha ocurrido un error";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }
            return Redirect("~/");
        }
    }
}
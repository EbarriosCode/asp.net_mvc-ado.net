using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Logic
{
    public class UsuarioLogic
    {
        private UsuarioDao userDao = new UsuarioDao();

        public List<Usuario> Listar()
        {
            return userDao.listarUsuarios();
        }

        public Usuario ObtenerUsuario(int id)
        {
            return userDao.getUsuario(id);
        }

        public bool crearUsuario(Usuario usuario)
        {
            return userDao.crearUsuario(usuario);
        }

        public bool editarUsuario(Usuario usuario)
        {
            return userDao.editarUsuario(usuario);
        }

        public bool eliminarUsuario(int id)
        {
            return userDao.eliminarUsuario(id);
        }
    }
}

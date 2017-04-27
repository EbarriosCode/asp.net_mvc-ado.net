using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Logic
{
    public class RolLogic
    {
        private RolesDao rolesDao = new RolesDao();

        public List<Rol> ListarRoles()
        {
            return rolesDao.listarRoles();
        }
    }
}

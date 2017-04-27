using Model.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class RolesDao
    {
        // listar los roles
        public List<Rol> listarRoles()
        {
            var roles = new List<Rol>();

            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion-context"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("SELECT * FROM Roles", conn);

                    using (var data = query.ExecuteReader())
                    {
                        while(data.Read())
                        {
                            // agregar el rol a la lista
                            var rolesAux = new Rol
                            {
                                idRol = Convert.ToInt32(data["idRol"]),
                                nombreRol = data["nombreRol"].ToString()
                            };

                            roles.Add(rolesAux);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return roles;
        }
    }
}

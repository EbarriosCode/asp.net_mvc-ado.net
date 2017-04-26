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
    public class UsuarioDao
    {
		public UsuarioDao getUsuario(int id)
        {
            var usuario = new Usuario();

			try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mvc-ado.net"].ToString()))
                {
                    var query = new SqlCommand("SELECT * FROM usuarios WHERE id = @id", conn);
                    query.Parameters.AddWithValue("@id", id);

                    using (var data = query.ExecuteReader())
                    {
                        data.Read();
						if(data.HasRows)
                        {
                            usuario.id = Convert.ToInt32(data["id"]);
                            usuario.nombre = data["nombre"].ToString();
                            usuario.apellido = data["apellido"].ToString();
                            usuario.fechaNacimiento = Convert.ToDateTime(data["fechaNacimiento"]);
                        }
                    }
                }
            }
			catch(Exception e)
            {
                throw;
            }

            return null;
        }

		
    }
}

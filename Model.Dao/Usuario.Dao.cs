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
		// obtener todos los usuarios de la bd
		public List<Usuario> listarUsuarios()
        {
            var usuarios = new List<Usuario>();

			try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion-context"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("execute getUsuarios", conn);

                    using (var data = query.ExecuteReader())
                    {
						while(data.Read())
                        {
                            // agregar el usuario al objeto lista
                            var user = new Usuario
                            {
                                id = Convert.ToInt32(data["idUsuario"]),
                                nombre = data["nombre"].ToString(),
                                apellido = data["apellido"].ToString(),
                                fechaNacimiento = Convert.ToDateTime(data["fechaNacimiento"]),
                                idRol = Convert.ToInt32(data["idRol"])
								};

                            usuarios.Add(user);
                        }
                    }

                    // agregamos el rol
                    foreach(var rol in usuarios)
                    {
                        query = new SqlCommand("select * from Roles where idRol = @id", conn);
                        query.Parameters.AddWithValue("@id", rol.idRol);

                        using (var read = query.ExecuteReader())
                        {
                            read.Read();
                            if(read.HasRows)
                            {
                                rol.Rol.idRol = Convert.ToInt32(read["idRol"]);
                                rol.Rol.nombreRol = read["nombreRol"].ToString();
                            }
                        }
                    }

                }
            }
			catch(Exception e)
            {
                throw;
            }

            return usuarios;
        }

		// obtener un usuario
		public Usuario getUsuario(int id)
        {
            var usuario = new Usuario();

			try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion-context"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("SELECT * FROM usuarios WHERE idUsuario = @id", conn);
                    query.Parameters.AddWithValue("@id", id);

                    using (var data = query.ExecuteReader())
                    {
                        data.Read();
						if(data.HasRows)
                        {
                            usuario.id = Convert.ToInt32(data["idUsuario"]);
                            usuario.nombre = data["nombre"].ToString();
                            usuario.apellido = data["apellido"].ToString();
                            usuario.fechaNacimiento = Convert.ToDateTime(data["fechaNacimiento"]);
                            usuario.idRol = Convert.ToInt32(data["idRol"]);
                        }
                    }
                }
            }
			catch(Exception e)
            {
                throw;
            }

            return usuario;
        }

		// insertar un usuario
		public bool crearUsuario(Usuario usuario)
        {
            bool respuesta = false;

			try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion-contexto"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("INSERT INTO usuarios(nombre,apellido,fechaNacimiento,idRol) VALUES (@p1,@p2,@p3,@p4)",conn);
                    query.Parameters.AddWithValue("@p1", usuario.nombre);
                    query.Parameters.AddWithValue("@p2", usuario.apellido);
                    query.Parameters.AddWithValue("@p3", usuario.fechaNacimiento);
                    query.Parameters.AddWithValue("@p4", usuario.idRol);

                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
			catch(Exception e)
            {
                throw;
            }

            return respuesta;
        }

        // actualizar un usuario
        public bool editarUsuario(Usuario usuario)
        {
            bool respuesta = false;

            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion-contexto"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("UPDATE usuarios SET nombre=@p1, apellido=@p2, fechaNacimiento=@p3 idRol=@p4 WHERE idUsuario=@p0)", conn);
                    query.Parameters.AddWithValue("@p0", usuario.id);
                    query.Parameters.AddWithValue("@p1", usuario.nombre);
                    query.Parameters.AddWithValue("@p2", usuario.apellido);
                    query.Parameters.AddWithValue("@p3", usuario.fechaNacimiento);
                    query.Parameters.AddWithValue("@p4", usuario.idRol);

                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception encontrada "+e);
                //throw;
            }

            return respuesta;
        }

		// eliminar un usuario
		public bool eliminarUsuario(int id)
        {
            var respuesta = false;

			try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion-contexto"].ToString()))
                {
                    conn.Open();
                    var query = new SqlCommand("DELETE FROM usuarios WHERE idUsuario = @p0", conn);
                    query.Parameters.AddWithValue("@p0", id);
                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
			catch(Exception ex)
            {
                throw;
            }

            return respuesta;
        }

    }
}

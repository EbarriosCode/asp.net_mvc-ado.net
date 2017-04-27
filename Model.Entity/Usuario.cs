using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Usuario
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El campo apellido es obligatorio")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "El campo fecha de nacimeinto es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime fechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo rol es obligatorio")]
        public int idRol { get; set; }
        public Rol Rol { get; set; }

        public Usuario()
        {
            Rol = new Rol();
        }
    }
}

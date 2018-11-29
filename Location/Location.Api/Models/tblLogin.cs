using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Location.Api.Models
{
    [Table("Login")]
    public class tblLogin
    {
            [Key]
            public int Id { get; set; }

            [MaxLength(50)]
            public string Nombres { get; set; }

            [MaxLength(50)]
            public string Apellidos { get; set; }

            [MaxLength(20)]
            public string Direccion { get; set; }

            [MaxLength(10)]
            public string Celular { get; set; }

            [MaxLength(1)]
            public string Estrato { get; set; }

            public DateTime FechaNacimiento { get; set; }

            public string Correo { get; set; }

            public string Contraseña { get; set; }
        }
}
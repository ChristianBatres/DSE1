using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace banco.Models
{
    public class cliente
    {
        [Key]
        public int id { get; set; }


        [StringLength(200)]
        [Required(ErrorMessage = "Campo requerido")]
        public string nombre { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Campo requerido")]
        public string primerApellido { get; set; }

        [StringLength(200)]
        public string segundoApellido { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Campo requerido")]
        public string telefono { get; set; }

        [StringLength(100)]
        [EmailAddress(ErrorMessage = "El correo no cumple con el formato correcto")]
        public string email { get; set; }

        public virtual ICollection<cuentaBancaria> CuentaBancarias { get; set; } // propiedad de navegación de colección
    }
}
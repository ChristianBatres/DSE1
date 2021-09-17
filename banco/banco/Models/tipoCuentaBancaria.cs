using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace banco.Models
{
    public class tipoCuentaBancaria
    {

        [Key]
        public int id { get; set; }


        [StringLength(200)]
        [Required(ErrorMessage = "Campo requerido")]
        public string tipo { get; set; }

        public bool Activo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace banco.Models
{
    
    public class tipoTransaccion
    {
        
        [Key]
        public int id { get; set; }


        [StringLength(25)]
        [Required(ErrorMessage = "Campo requerido")]
        public string tipo { get; set; }

        public virtual ICollection<transaccion> transacciones { get; set; } // propiedad de navegación de colección

    }

}

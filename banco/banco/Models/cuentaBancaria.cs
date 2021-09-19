using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace banco.Models
{
    public class cuentaBancaria
    {
        [Key]
        public int id { get; set; }


        [ForeignKey("cliente")] //se utilizar ya que para la llave forarea no se utiliza la convesión de nombres
        public int cliente_Id { get; set; } //llave foranea
        public virtual cliente cliente { get; set; } // propiedad de navegación de referencia

        [StringLength(20)]
        [Required(ErrorMessage = "Ingrese la moneda quee manejara la cuenta")]
        public string Moneda { get; set; }


        [ForeignKey("tipoCuentaBancaria")] //se utilizar ya que para la llave forarea no se utiliza la convesión de nombres
        public int tipo_id { get; set; } //llave foranea
        public virtual tipoCuentaBancaria tipoCuentaBancaria { get; set; } // propiedad de navegación de referencia

        public virtual ICollection<transaccion> transacciones { get; set; } // propiedad de navegación de colección


    }
}
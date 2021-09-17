
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace banco.Models
{
    public class transaccion
    {
        
        [Key]
        public int id { get; set; }

        [ForeignKey("cuentaBancaria")] //se utilizar ya que para la llave forarea no se utiliza la convesión de nombres
        public int cuentaBancaria_id { get; set; } //llave foranea
        public virtual cuentaBancaria cuentaBancaria { get; set; } // propiedad de navegación de referencia
        
        [ForeignKey("tipoTransaccion")] //se utilizar ya que para la llave forarea no se utiliza la convesión de nombres
        public int tipoTransaccion_id { get; set; } //llave foranea
        public virtual tipoTransaccion tipoTransaccion { get; set; } // propiedad de navegación de referencia

        
        [Required(ErrorMessage = "Campo requerido")]
        [Column(TypeName = "money")]
        public decimal monto { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Campo requerido")]
        public string Estado { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fechaTransaccion { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fechaAplicacion { get; set; }
       

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace banco.Models
{
    public class transacciones
    {
        [Key]
        public int id { get; set; }
        public int? cuentaBancaria_id { get; set; }
        public virtual cuentaBancaria cuentas { get; set; }

        public int? tipoTransaccion_id { get; set; }
        public virtual tipoTransaccion tipos { get; set; }

       
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
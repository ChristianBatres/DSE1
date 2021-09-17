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

        public int? cliente_id { get; set; }
        public virtual cliente clientes { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Ingresa la moneda que manejara la cuenta")]
        public string Moneda { get; set; }


        public int? tipo_id { get; set; }
        public virtual tipoCuentaBancaria tipos { get; set; }
    }
}
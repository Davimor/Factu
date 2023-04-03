using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DB.Models
{
    public class Contacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(200)]
        public TipoContacto Tipo { get; set; }
        [StringLength(200)]
        public string valor { get; set; } = "";
        [StringLength(200), DefaultValue(true)]
        public bool EnvioFactura { get; set; }
        public Tratamiento Tratamiento { get; set; }
    }
}

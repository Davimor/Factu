using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = "";
        [StringLength(20)]
        public string IdFiscal { get; set; } = "";
        [StringLength(200)]
        public string Direccion { get; set; } = "";
        public List<Contacto> Contactos { get; set; }
    }
}

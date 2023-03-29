using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Entidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(20)]
        public string IdFiscal { get; set; } = "";
        [Required]
        [StringLength(200)]
        public string Direccion { get; set; } = "";
        [Required]
        [StringLength(200)]
        public string EntidadBancaria { get; set; } = "";
        [Required]
        [StringLength(20), MinLength(20)]
        public string CCC { get; set; } = "";
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = "";
        [ForeignKey("CLienteFK")]
        public Cliente ClienteId { get; set; }
        public DateTime FechaFactura { get; set; }
        [ForeignKey("ConceptoFK")]
        public List<Concepto> Conceptos { get; set;}
        public double BaseImponible { get; set; }
        public double TotalImpuesto { get; set; }
        public double Retenciones { get; set; }
        public double TotalFactura { get; set; }

    }
}


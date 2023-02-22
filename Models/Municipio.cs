using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartamentosMunicipiosMVC.Models
{
    public class Municipio
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]

        public string? Nombre { get; set; }
        public string? CNRCompleto { get; set; }
        public float? Latitud { get; set; }
        public float? Longitud { get; set; }

        public int? DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }

    }
}

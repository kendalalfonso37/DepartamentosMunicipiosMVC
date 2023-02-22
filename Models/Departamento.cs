using System.ComponentModel.DataAnnotations;

namespace DepartamentosMunicipiosMVC.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Nombre { get; set; }
        public string? CNRCompleto { get; set; }
        public float? Latitud { get; set; }
        public float? Longitud { get; set; }

        public ICollection<Municipio>? Municipios { get; set; }
    }

}

using System.ComponentModel.DataAnnotations;

namespace DepartamentosMunicipiosMVC.DTOs
{
    public class DepartamentoCreationDTO
    {
        [Required]
        public string? Nombre { get; set; }
        public string? CNRCompleto { get; set; }
        public float? Latitud { get; set; }
        public float? Longitud { get; set; }

    }
}

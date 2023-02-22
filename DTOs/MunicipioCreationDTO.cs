using Microsoft.Build.Framework;

namespace DepartamentosMunicipiosMVC.DTOs
{
    public class MunicipioCreationDTO
    {
        [Required]
        public string? Nombre { get; set; }
        public string? CNRCompleto { get; set; }
        public float? Latitud { get; set; }
        public float? Longitud { get; set; }
    }
}

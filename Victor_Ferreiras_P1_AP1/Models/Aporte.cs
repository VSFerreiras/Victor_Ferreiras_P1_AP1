using System.ComponentModel.DataAnnotations;
namespace Victor_Ferreiras_P1_AP1.Models;

public class Aporte
{
    [Key]
    public int AporteId { get; set; }
    
    [Required(ErrorMessage = "El campo es requerido")]
    [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\s]+$", ErrorMessage = "La persona solo debe contener letras y espacios")]
    [StringLength(50)]
    public string Persona { get; set; }

    [Required(ErrorMessage = "El campo es requerido")]
    [StringLength(250)]
    public string Observacion { get; set; }

    [Required(ErrorMessage = "El campo es requerido")]
    [Range(1, double.MaxValue, ErrorMessage = "El campo debe ser mayor que 0")]
    public double Monto { get; set; }
    
    public DateTime Fecha { get; set; } = DateTime.Now;
}


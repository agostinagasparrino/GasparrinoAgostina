using GasparrinoAgostina.Entidades;
using System.ComponentModel.DataAnnotations;

namespace GasparrinoAgostina.Models
{
    public class BarcoModel
    {
        public int IdBarco { get; set; }

        [Required(ErrorMessage = "¡El nombre es requerido!")]
        [StringLength(20, ErrorMessage = "¡El nombre no puede superar los 20 caracteres!")]
        [RegularExpression("[a-zA-ZñÑáÁéÉíÍóÓúÚüÜ ]+", ErrorMessage = "¡El nombre solo puede contener letras y espacios!")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "¡La antiguedad es requerida!")]
        [Range(0, 199, ErrorMessage = "¡La antiguedad debe ser entre 0 y 199!")]
        public double Antiguedad { get; set; }

        [Required(ErrorMessage = "¡La tripulacion es requerida!")]
        [Range(1, 500, ErrorMessage = "¡La tripulacion debe ser entre 1 y 500!")]
        public int TripulacionMaxima { get; set; }
        public double Tasa { get; set; }

        

        public BarcoModel()
        {

        }

        public BarcoModel(Barco barco)
        {
            IdBarco = barco.IdBarco;
            Nombre = barco.Nombre;
            Antiguedad = barco.Antiguedad;
            TripulacionMaxima = barco.TripulacionMaxima;
            Tasa = barco.Tasa;
            
        }

        public static List<BarcoModel> MapearAListaModel(List<Barco> barcos)
        {
            return barcos.Select(b => new BarcoModel(b)).ToList();
        }

        public Barco MapearAEntidad()
        {
            return new Barco
            {
                IdBarco = IdBarco,
                Nombre = Nombre,
                Antiguedad = Antiguedad,
                TripulacionMaxima = TripulacionMaxima,
                Tasa = Tasa
            };
        }
    }

}

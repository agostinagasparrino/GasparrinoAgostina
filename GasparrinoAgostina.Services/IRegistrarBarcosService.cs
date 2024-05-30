using GasparrinoAgostina.Entidades;

namespace GasparrinoAgostina.Services
{
    public interface IRegistrarBarcosService
    {
        public void RegistrarBarco(Barco barco);
        public List<Barco> obtenerLista();

    }
    public class BarcosService : IRegistrarBarcosService
    {
        public static List<Barco> _barcos = new List<Barco>();
        public void RegistrarBarco(Barco barco)
        {
            barco.Tasa = (int)((barco.Antiguedad * 0.10) + (barco.TripulacionMaxima / 2));

            barco.IdBarco = _barcos.Count + 1;
             

            _barcos.Add(barco);
        }
        public List<Barco> obtenerLista()
        {
            return _barcos;
           
        }
    }
}

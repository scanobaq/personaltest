using System.ComponentModel.DataAnnotations;

namespace personaltest.Areas.Entities
{
    public class Poliza
    {
        public int Id { get; set; }
        public string? NumeroPoliza { get; set; }
        public string? NombreCliente { get; set; }

        public string? NumeroIdentificacion { get; set; }

        public DateTime FechaNacimientoCliente { get; set; }

        public DateTime FecchaExpedicionPoliza { get; set; }

        public string TipoCobertura { get; set; }
        public int ValorMaximoCubierto { get; set; }

        public string NombrePlanPoliza { get; set; }

        public string CiudadRecidenciaCliente { get; set; }

        public string DireccionRecidenciaCliente { get; set; }

        public string PlacaAutomotor { get; set; }

        public string ModeloAutomotor { get; set; }

        public bool TieneInspeccion { get; set; }
    }
}
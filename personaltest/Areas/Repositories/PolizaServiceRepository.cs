using personaltest.Areas.Entities;

namespace personaltest.Areas.Repositories
{
    public class PolizaServiceRepository : IPolizaServiceRepository
    {
        private List<TypePoliza> _typePolizas = new List<TypePoliza>(){
            new TypePoliza {NumeroPoliza = "1AK24", FechaInicio = new DateTime(2023, 1, 1), FechaVigencia = new DateTime(2023,12,31)}
        };

        public bool ValidarTypePoliza(string numeroPoliza, DateTime FecchaExpedicionPoliza)
        {
            var data = _typePolizas
            .Where
            (
                tp => tp.NumeroPoliza == numeroPoliza &&
                tp.FechaInicio <= FecchaExpedicionPoliza &&
                tp.FechaVigencia >= FecchaExpedicionPoliza
            ).FirstOrDefault();

            if (data == null) { return false; }

            return true;
        }
    }
}
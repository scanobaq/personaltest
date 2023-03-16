using personaltest.Areas.Entities;
using personaltest.Areas.Identity.Data;
using personaltest.ViewModels;

namespace personaltest.Areas.Repositories
{
    public class PolizaRepository : IPolizaRepository
    {
        private readonly personaltestIdentityDbContext _context;
        private readonly IPolizaServiceRepository _polizaServiceRepository;

        public PolizaRepository(personaltestIdentityDbContext context, IPolizaServiceRepository polizaServiceRepository)
        {
            _context = context;
            _polizaServiceRepository = polizaServiceRepository;
        }
        public IEnumerable<Poliza> getPolizas()
        {
            return _context.Polizas;
        }

        public async Task<Poliza> getPoliza(int numeroPoliza, string placaAutomotor)
        {
            return _context.Polizas.Where(p => p.Id == numeroPoliza || p.PlacaAutomotor == placaAutomotor).FirstOrDefault();
        }

        public async Task<ResponseViewModel<object>> AddPolizaAsync(PolizaViewModel polizaViewModel)
        {
            try
            {
                if (!_polizaServiceRepository.ValidarTypePoliza(polizaViewModel.NumeroPoliza, polizaViewModel.FecchaExpedicionPoliza))
                {
                    return (new ResponseViewModel<object>
                    {
                        IsSuccess = false,
                        Message = "La poliza a crear no esta vigente",
                        Result = null
                    });
                }

                var poliza = new Poliza
                {
                    NumeroPoliza = polizaViewModel.NumeroPoliza,
                    NombreCliente = polizaViewModel.NombreCliente,
                    NumeroIdentificacion = polizaViewModel.NumeroIdentificacion,
                    FechaNacimientoCliente = polizaViewModel.FechaNacimientoCliente,
                    FecchaExpedicionPoliza = polizaViewModel.FecchaExpedicionPoliza,
                    TipoCobertura = polizaViewModel.TipoCobertura,
                    ValorMaximoCubierto = polizaViewModel.ValorMaximoCubierto,
                    NombrePlanPoliza = polizaViewModel.NombrePlanPoliza,
                    CiudadRecidenciaCliente = polizaViewModel.CiudadRecidenciaCliente,
                    DireccionRecidenciaCliente = polizaViewModel.DireccionRecidenciaCliente,
                    PlacaAutomotor = polizaViewModel.PlacaAutomotor,
                    ModeloAutomotor = polizaViewModel.ModeloAutomotor,
                    TieneInspeccion = polizaViewModel.TieneInspeccion,
                };
                _context.Polizas.Add(poliza);
                await _context.SaveChangesAsync();

                return (new ResponseViewModel<object>
                {
                    IsSuccess = true,
                    Message = "La poliza fue creada",
                    Result = poliza
                });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
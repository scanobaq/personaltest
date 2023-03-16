using personaltest.Areas.Entities;
using personaltest.ViewModels;

namespace personaltest.Areas.Repositories
{
    public interface IPolizaRepository
    {
        IEnumerable<Poliza> getPolizas();

        Task<Poliza> getPoliza(int numeroPoliza, string placaAutomotor);

        Task<ResponseViewModel<object>> AddPolizaAsync(PolizaViewModel polizaVieModel);

    }
}
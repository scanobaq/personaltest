using personaltest.Areas.Entities;

namespace personaltest.Areas.Repositories
{
    public interface IPolizaServiceRepository
    {
        bool ValidarTypePoliza(string numeroPoliza, DateTime FecchaExpedicionPoliza);
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NuGet.Protocol.Core.Types;
using personaltest.Areas.Entities;
using personaltest.Areas.Identity.Data;
using personaltest.Areas.Repositories;
using personaltest.Controllers;
using Xunit;

namespace personalUnitTest;

public class CreatePoliza
{
    private readonly PolizasController _polizasController;

    private readonly personaltestIdentityDbContext _context;
    private readonly Mock<DbSet<Poliza>> _mockSomeClass;
    private readonly PolizaServiceRepository _polizaServiceRepository;
    private readonly PolizaRepository _polizarepository;
    private readonly PolizasController _polizaController;

    public CreatePoliza()
    {
        _polizaServiceRepository = new PolizaServiceRepository();
        _polizarepository = new PolizaRepository(_context, _polizaServiceRepository);
        _polizaController = new PolizasController(_polizarepository);
    }

    [Fact]
    public void Test1()
    {
        var result = _polizasController.GetPolizas();
        Assert.IsType<OkObjectResult>(result);
    }
}

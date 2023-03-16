using personaltest.Areas.Entities;
using personaltest.Helpers;

namespace personaltest.Areas.Identity.Data
{
    public class SeedDb
    {
        private readonly personaltestIdentityDbContext _dbContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(personaltestIdentityDbContext dbContext, IUserHelper userHelper)
        {
            _dbContext = dbContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dbContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var customer = await CheckUserAsync(0, "Cano", "Baquero", "Esneider", "Usuario prueba", DateTime.Now, true, "1", DateTime.Now, DateTime.Now, "snayder.cano@gmail.com", "Customer");
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");
        }

        private async Task<UserTest> CheckUserAsync(
            int codigoEmpresa,
            string apellido1,
            string apellido2,
            string nombre,
            string descripcion,
            DateTime fechaExpiracionPassword,
            bool indicadorReinicioPassword,
            string codigoEstado,
            DateTime fechaIngreso,
            DateTime fechaSalida,
            string email,
            string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserTest
                {
                    Apellido1 = apellido1,
                    Apellido2 = apellido2,
                    UserName = email,
                    Nombre = nombre,
                    Email = email
                };

                await _userHelper.AddUserAsync(user, "Personaltest2023?");
                await _userHelper.AddUserToRoleAsync(user, role);
                await _dbContext.SaveChangesAsync();
            }

            return user;
        }
    }
}
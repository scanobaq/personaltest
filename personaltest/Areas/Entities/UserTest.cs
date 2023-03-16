using Microsoft.AspNetCore.Identity;

namespace personaltest.Areas.Entities
{
    public class UserTest : IdentityUser
    {
        public string? Nombre { get; set; }
        public string? Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
        public string? CodigoEmpresa { get; set; }
    }

}
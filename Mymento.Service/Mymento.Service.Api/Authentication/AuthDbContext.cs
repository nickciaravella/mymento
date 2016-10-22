namespace Mymento.Service.Api.Authentication
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthDbContext()
            : base("AuthDbContext")
        {
        }
    }
}
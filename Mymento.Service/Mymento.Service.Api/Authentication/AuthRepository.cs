namespace Mymento.Service.Api.Authentication
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Mymento.Service.Api.Models;

    public class AuthRepository : IDisposable
    {
        private readonly AuthDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public AuthRepository()
        {
            dbContext = new AuthDbContext();
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(dbContext));
        }

        public Task<IdentityResult> RegisterUserAsync(UserModel userModel) =>
            userManager.CreateAsync(
                new IdentityUser { UserName = userModel.EmailAddress },
                userModel.Password);

        public Task<IdentityUser> FindUserAsync(string userName, string password) =>
            userManager.FindAsync(userName, password);

        public void Dispose()
        {
            dbContext.Dispose();
            userManager.Dispose();
        }
    }
}
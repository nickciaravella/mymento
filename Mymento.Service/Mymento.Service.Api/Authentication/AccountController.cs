namespace Mymento.Service.Api.Authentication
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Mymento.Service.Api.Models;

    [RoutePrefix("api/accounts")]
    public class AccountController : ApiController
    {
        private readonly AuthRepository _repo = null;

        public AccountController()
        {
            _repo = new AuthRepository();
        }

        [Route]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> PostAccountAsync(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUserAsync(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);
            return errorResult ?? Ok();
        }

        [Route]
        [HttpGet]
        [Authorize]
        public async Task<IHttpActionResult> GetAccountAsync()
        {
            // NOTE: This is just to test the [Authorize] attribute for now.
            await Task.Delay(0);
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}

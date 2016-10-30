namespace Mymento.Service.Api.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Mymento.Service.Api.Storage;

    [RoutePrefix("api/tasks")]
    public class TasksController : ApiController
    {
        [Route]
        [HttpGet]
        [Authorize]
        public async Task<IHttpActionResult> GetAllTasks()
        {
            var tasks = await new TasksStore()
                .GetTasks(User.Identity.GetUserId());

            return Ok(tasks);
        }
    }
}

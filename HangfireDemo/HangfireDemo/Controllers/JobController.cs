using Hangfire;
using HangfireDemo.Common;
using Microsoft.AspNetCore.Mvc;

namespace HangfireDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        [HttpPost(Name = "StartExampleJob")]
        public IActionResult StartExampleJob([FromBody] int delayInSeconds)
        {
            BackgroundJob.Enqueue<ExampleJob>(job => job.Execute(new ExampleJobParameters { DelayInSeconds = delayInSeconds, Value = "whatever" }));
            return Ok();
        }
    }
}
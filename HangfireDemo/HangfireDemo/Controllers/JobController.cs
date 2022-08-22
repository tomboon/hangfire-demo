using Hangfire;
using HangfireDemo.Common;
using Microsoft.AspNetCore.Mvc;

namespace HangfireDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        [HttpPost("StartExampleJob")]
        public IActionResult StartExampleJob([FromBody] int delayInSeconds)
        {
            BackgroundJob.Enqueue<ExampleJob>(job => job.Execute(new ExampleJobParameters { DelayInSeconds = delayInSeconds, Value = "whatever" }));
            return Ok();
        }

        [HttpPost("StartFailedJob")]
        [AutomaticRetry(Attempts = 2)]
        public IActionResult StartFailedJob()
        {
            BackgroundJob.Enqueue<FailedJob>(job => job.Execute());
            return Ok();
        }
    }
}
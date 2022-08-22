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
        public IActionResult StartFailedJob()
        {
            BackgroundJob.Enqueue<FailedJob>(job => job.Execute());
            return Ok();
        }

        [HttpPost("StartRecurringJob")]
        public IActionResult StartRecurringJob()
        {
            RecurringJob.AddOrUpdate<ExampleRecurringJob>(job => job.Execute(), Cron.Minutely);
            return Ok();
        }
    }
}
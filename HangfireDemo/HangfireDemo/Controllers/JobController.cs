using Hangfire;
using HangfireDemo.Common;
using HangfireDemo.Common2;
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

        [HttpPost("StartExampleJob2")]
        public IActionResult StartExampleJob2([FromBody] int delayInSeconds)
        {
            BackgroundJob.Enqueue<ExampleJob2>(job => job.Execute(new ExampleJob2Parameters { DelayInSeconds = delayInSeconds, Value = "whatever2" }));
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
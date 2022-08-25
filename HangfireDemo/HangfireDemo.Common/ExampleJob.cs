using Hangfire;

namespace HangfireDemo.Common
{
    public class ExampleJob
    {
        [Queue("server1")]
        public async Task Execute(ExampleJobParameters parameters)
        {
            await Task.Delay(TimeSpan.FromSeconds(parameters.DelayInSeconds));
        }
    }
}
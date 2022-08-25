using Hangfire;

namespace HangfireDemo.Common2
{
    public class ExampleJob2
    {
        [Queue("server2")]
        public async Task Execute(ExampleJob2Parameters parameters)
        {
            await Task.Delay(TimeSpan.FromSeconds(parameters.DelayInSeconds));
        }
    }
}
using Hangfire;

namespace HangfireDemo.Common
{
    [AutomaticRetry(Attempts = 2)]
    public class FailedJob
    {
        public async Task Execute()
        {
            throw new Exception("This job failed");
        }
    }
}
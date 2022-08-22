namespace HangfireDemo.Common
{
    public class FailedJob
    {
        public async Task Execute()
        {
            throw new Exception("This job failed");
        }
    }
}
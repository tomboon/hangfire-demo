namespace HangfireDemo.Common
{
    public class ExampleJob
    {
        public async Task Execute(ExampleJobParameters parameters)
        {
            await Task.Delay(TimeSpan.FromSeconds(parameters.DelayInSeconds));
        }
    }
}
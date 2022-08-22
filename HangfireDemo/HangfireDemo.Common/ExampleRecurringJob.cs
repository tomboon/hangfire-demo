namespace HangfireDemo.Common
{
    public class ExampleRecurringJob
    {
        public async Task Execute()
        {
            Console.WriteLine("Recurring job executed");
        }
    }
}
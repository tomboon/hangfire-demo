// See https://aka.ms/new-console-template for more information
using Hangfire;

//Hangfire
GlobalConfiguration.Configuration.UseSqlServerStorage(@"Server=(local);Data Source=.;initial catalog=HangfireDemo;Integrated Security=SSPI;Application Name=HangfireDemo");

var options = new BackgroundJobServerOptions
{
    ServerName = "hangfire server 2",
    Queues = new[] { "server2" },
};

using (var server = new BackgroundJobServer(options))
{
    Console.WriteLine("Hangfire Server started. Press any key to exit...");
    Console.ReadKey();
}
// See https://aka.ms/new-console-template for more information
using Hangfire;

//Hangfire
GlobalConfiguration.Configuration.UseSqlServerStorage(@"Server=(local);Data Source=.;initial catalog=HangfireDemo;Integrated Security=SSPI;Application Name=HangfireDemo");

using (var server = new BackgroundJobServer())
{
    Console.WriteLine("Hangfire Server started. Press any key to exit...");
    Console.ReadKey();
}
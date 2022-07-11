namespace WebSocketsNotWorkingInTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplication app = BuildApp(args);

            app.Run();
        }

        public static WebApplication BuildApp(string[] args, Action<WebApplicationBuilder>? build = null)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            build?.Invoke(builder);
            var app = builder.Build();

            app.MapControllers();
            app.UseWebSockets();
            return app;
        }
    }
}

using System.Net.WebSockets;
using WebSocketsNotWorkingInTests;
using Microsoft.AspNetCore.Hosting;
using static System.Net.WebRequestMethods;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:8080") };
            var app = Program.BuildApp(Array.Empty<string>(), builder =>
            {
                builder.WebHost.UseUrls("https://localhost:8080");
            });
            Task serverTask = app.RunAsync();
            // Wait for server to start...
            while (true)
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync("/");
                    if (response.IsSuccessStatusCode)
                        break;
                    await Task.Delay(100);
                }
                catch { }
            }

            using var ws = new ClientWebSocket();
            await ws.ConnectAsync(new Uri("wss://localhost:8080/ws"), CancellationToken.None);
            await serverTask;
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace WebSocketsNotWorkingInTests.Controllers;

public class WebSocketController : ControllerBase
{

    [HttpGet("/ws")]
    public async Task WS()
    {
        if (!HttpContext.WebSockets.IsWebSocketRequest)
        {
            HttpContext.Response.StatusCode = 400;
            return;
        }

        byte[] message = System.Text.Encoding.UTF8.GetBytes("Hello");
        using var ws = await HttpContext.WebSockets.AcceptWebSocketAsync();
        while (true)
        {
            await Task.Delay(1000);
            await ws.SendAsync(message, System.Net.WebSockets.WebSocketMessageType.Text, endOfMessage: true, cancellationToken: default);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace TestMQTT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MqttTestController : ControllerBase
{
    private readonly MqttService _mqtt;

    public MqttTestController(MqttService mqtt) => _mqtt = mqtt;

    [HttpPost("open")]
    public async Task<IActionResult> Open() =>
        Ok(await PublishAndLog("fox/str1s2/192.168.0.101/command", "open"));

    [HttpPost("close")]
    public async Task<IActionResult> Close() =>
        Ok(await PublishAndLog("fox/str1s2/192.168.0.101/command", "close"));

    private async Task<string> PublishAndLog(string topic, string msg)
    {
        await _mqtt.PublishAsync(topic, msg);
        return $"Sent '{msg}' to '{topic}'";
    }
}

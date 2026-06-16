namespace AirportWarehouse.Core.Request;

public class LoginRequest
{
    public string AgentNumber { get; set; } = null!;
    public string Password { get; set; } = null!;
}

namespace AirportWarehouse.Core.Dtos
{
    public class AgentDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string AgentNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Guid AirportId { get; set; }
        public string ShortName { get; set; } = null!;
        public bool IsActive { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}

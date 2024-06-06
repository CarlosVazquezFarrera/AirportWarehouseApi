namespace AirportWarehouse.Core.DTOs
{
    public class AgentDTO
    {
        public Guid Id { get; set; }

        public string AgentNumber { get; set; } = null!;

        public string ShortName { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

    }
}

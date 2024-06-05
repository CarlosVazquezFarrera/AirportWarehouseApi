namespace AirportWarehouse.Core.CustomEntities
{
    public class AgentBaseInfo
    {
        public Guid Id { get; set; }

        public int AgentNumber { get; set; }

        public string ShortName { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

    }
}

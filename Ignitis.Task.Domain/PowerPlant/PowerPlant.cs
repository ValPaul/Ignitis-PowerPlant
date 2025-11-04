namespace Ignitis.Domain.PowerPlant
{
    public class PowerPlant : Entity
    {
        public string Owner { get; private set; }
        public decimal Power { get; private set; }
        public DateTimeOffset ValidFrom {  get; private set; }
        public DateTimeOffset? ValidTo { get; private set; }

        /// <summary>
        /// For EF Core
        /// </summary>
        private PowerPlant() {}

        public PowerPlant (Guid id, string owner, decimal power, DateTimeOffset validFrom, DateTimeOffset? validTo, DateTimeOffset now) 
        {
            Id = id;
            Owner = owner;
            Power = power;
            ValidFrom = validFrom;
            ValidTo = validTo;
            EntityCreated(now);
        }

        public void Update (string owner, decimal power, DateTimeOffset validFrom, DateTimeOffset? validTo, DateTimeOffset modified)
        {
            Owner = owner;
            Power = power;
            ValidFrom = validFrom;
            ValidTo = validTo;
            Modify(modified);
        }
    }
}

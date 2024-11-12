namespace QDryClean.Domain.Entities
{
    public class Order : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

namespace QDryClean.Domain.Entities
{
    public class Employee : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

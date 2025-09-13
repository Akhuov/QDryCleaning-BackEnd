namespace QDryClean.Application.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public string? AdditionalPhoneNumber { get; set; }
        public decimal Points { get; set; } = decimal.Zero;
    }
}

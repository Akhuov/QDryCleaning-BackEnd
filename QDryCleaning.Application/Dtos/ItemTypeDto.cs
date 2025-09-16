namespace QDryClean.Application.Dtos
{
    public class ItemTypeDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ItemCategoryId { get; set; }
        public int ChargeId { get; set; }
    }
}

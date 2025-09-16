namespace QDryClean.Application.Dtos
{
    public class ItemTypeDto
    {
        public required string Name { get; set; }
        public int ItemCategoryId { get; set; }
        public int ChargeId { get; set; }
    }
}

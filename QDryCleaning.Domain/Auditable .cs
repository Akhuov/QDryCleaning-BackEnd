namespace QDryClean.Domain
{
    public class Auditable : BaseModel
    {
        public string CreatedAt { get; set; } = DateTime.Now.ToString("dd.MM.yy");
        public string? UpdatedAt { get; set; }
    }
}

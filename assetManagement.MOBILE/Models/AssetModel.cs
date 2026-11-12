namespace assetManagement.MOBILE.Models
{
    public class AssetModel
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public string serialNumber { get; set; } = "";
        public int categoryId { get; set; } = 0;
        public int? ownerId { get; set; }
        public DateTime? assignedAt { get; set; }
    }
}

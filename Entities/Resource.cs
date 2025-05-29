namespace ASP.Net.Entities
{
    public class Resource
    {
        public int Id { get; set; }
        public string Path { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public string Category { get; set; } = string.Empty; // e.g., "User", "Product", "Order"
        //public bool IsActive { get; set; } = true;
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

    }
}

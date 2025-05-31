namespace ASP.Net.Entities
{
    public class Resource
    {
        public int Id { get; set; }
        public string Path { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Priority { get; set; }
        public int? ParentId { get; set; }
        public string Icon { get; set; } = string.Empty;
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

    }
}

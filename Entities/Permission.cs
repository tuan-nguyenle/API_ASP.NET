namespace ASP.Net.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string Action { get; set; } = string.Empty; // e.g., "Create", "Read", "Update", "Delete"
        public string Description { get; set; } = string.Empty;
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

    }
}

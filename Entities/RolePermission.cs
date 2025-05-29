namespace ASP.Net.Entities
{
    public class RolePermission
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public int? ResourceId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime Assigned_At { get; set; }
        public DateTime? Revoked_At { get; set; }
    }
}

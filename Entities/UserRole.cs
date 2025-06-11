    namespace ASP.Net.Entities
    {
        public class UserRole
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public int RoleId { get; set; }
            public bool IsActive { get; set; } = true;
            public DateTime Assigned_At { get; set; }
            public DateTime? Revoked_At { get; set; }
        }
    }

﻿namespace ASP.Net.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

    }
}

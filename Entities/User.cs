namespace ASP.Net.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = "https://avatar.iran.liara.run/public/19";
        public Boolean IsActive { get; set; } = true;
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}

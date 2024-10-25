
namespace DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Username { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int LicenseNumber { get; set; }
        public string ProfilePictureFilePath { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AdministratorDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Username { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string PhoneNumber { get; set; }
    }
}

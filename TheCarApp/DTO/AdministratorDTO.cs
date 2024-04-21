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
        public string email { get; set; }
        public string password { get; set; }
        public byte[] passSalt { get; set; }
        public string Username { get; set; }
        public DateTime CreatedOn { get; set; }
        public string _phoneNumber { get; set; }
    }
}

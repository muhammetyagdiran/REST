using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Entities.DTOs.User
{
    public class UserLoginRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}

using REST.Entities.DTOs.User;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Business.Security
{
    public interface IJwtAuthService
    {
        JwtToken GenerateToken(UserLoginRequestDTO userLoginRequestDTO, IConfiguration configuration);
    }
}

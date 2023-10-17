using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace REST.Entities.DTOs.User
{
    public class UserLoginResponseDTO
    {
        public UserAddRequestDTO User { get; set; }
        [JsonPropertyName("jwtoken")]
        public string JWToken { get; set; }
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}

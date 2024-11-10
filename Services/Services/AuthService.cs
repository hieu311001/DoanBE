using Microsoft.IdentityModel.Tokens;
using ProductOrder.Entities;
using ProductOrder.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using ZstdSharp.Unsafe;
using ProductOrder.Repos.Interfaces;
using ProductOrder.Parameters;
using System.Security.Cryptography;
using ProductOrder.Model;

namespace ProductOrder.Services.Services
{
    public class AuthService : IAuthService
    {
        private IConfiguration _configuration;
        private IUserRepo _userRepo;

        public AuthService(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _configuration = configuration;
            _userRepo = serviceProvider.GetRequiredService<IUserRepo>();
        }

        /// <summary>
        /// Xử lý đăng nhập
        /// </summary>
        public ModelUserLogin Login(LoginParameter parameter)
        {
            UserEntity userDB = _userRepo.GetUserLogin(parameter.UserName);

            if (userDB == null)
            {
                throw new Exception("Không tồn tại tài khoản.");
            }

            bool isUser = CheckPassword(parameter.Password, userDB.Password);

            if (!isUser)
            {
                throw new Exception("Tài khoản hoặc mật khẩu không hợp lệ.");
            }

            string token = CreateToken(userDB);

            var modelUserLogin = new ModelUserLogin
            {
                UserID = userDB.UserID,
                Email = userDB.Email,
                FullName = userDB.FullName,
                PhoneNumber = userDB.PhoneNumber,
                Role = userDB.Role,
                StoreID = userDB.StoreID,
                AccessToken = token,
                Address = userDB.Address
            };

            return modelUserLogin;
        }

        /// <summary>
        /// Kiểm tra mật khẩu
        /// </summary>
        private bool CheckPassword(string str, string hashPassword)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(hashPassword))
            {
                return false;
            }

            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(str);

            byte[] hashBytes = MD5.Create().ComputeHash(bytes);

            StringBuilder sOutput = new StringBuilder(hashPassword.Length);

            int i = 0;
            for (i = 0; i < hashBytes.Length; i++)
            {
                sOutput.Append(hashBytes[i].ToString("X2"));
            }
            string hashStr = sOutput.ToString();

            if (hashStr.Length != hashPassword.Length)
            {
                return false;
            }

            bool isUser = false;

            int j = 0;
            while ((j < hashStr.Length) && (hashStr[j] == hashPassword[j]))
            {
                j += 1;
            }
            if (j == hashStr.Length)
            {
                isUser = true;
            }

            return isUser;
        }

        /// <summary>
        /// Tạo token
        /// </summary>
        public string CreateToken(UserEntity user)
        {
            var handler = new JwtSecurityTokenHandler();

            var privateKey = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("PrivateKey"));

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(privateKey),
                SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(1),
                Subject = GenerateClaims(user)
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        /// <summary>
        /// Tạo thông tin trong token
        /// </summary>
        private ClaimsIdentity GenerateClaims(UserEntity user)
        {
            var ci = new ClaimsIdentity();

            ci.AddClaim(new Claim("userId", user.UserID.ToString()));
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            ci.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));

            return ci;
        }
    }
}

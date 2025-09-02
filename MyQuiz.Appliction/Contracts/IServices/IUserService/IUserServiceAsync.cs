using MyQuiz.Dtos.AuthResult;
using MyQuiz.Dtos.RegisterDto;
using MyQuiz.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Contracts.IServices.IUserService
{
    public interface IUserServiceAsync
    {
        Task<AuthResult> LoginAsync(LoginDto dto);
        Task<AuthResult> RegisterAsync(RegisterDto registerDto);
    }
}

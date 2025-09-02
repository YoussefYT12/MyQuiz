using MyQuiz.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Contracts.IServices.IUserService
{
    public interface ITokenGenerator
    {
        string GenerateJwtToken(Priv_User user, IList<string> roles);
    }
}

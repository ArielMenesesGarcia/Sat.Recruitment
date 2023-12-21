using System;
using Sat.Recruitment.Transversal.Common;
using Sat.Recruitment.Application.DTO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Interface
{
    public interface IUserApplication
    {
        Task<Result<bool>> InsertAsync(UserDTO userDTO);
    }
}

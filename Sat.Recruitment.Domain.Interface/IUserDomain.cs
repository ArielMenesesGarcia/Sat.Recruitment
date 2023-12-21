using System;
using System.Threading.Tasks;
using Sat.Recruitment.Domain.Entity;

namespace Sat.Recruitment.Domain.Interface
{
    public interface IUserDomain
    {
        Task<bool> InsertAsync(User usuario);
    }
}

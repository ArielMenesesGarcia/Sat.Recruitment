using Sat.Recruitment.Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infrastructure.Interface
{
    public interface IUserRepository
    {
        Task<bool> InsertAsync(User user);
    }
}

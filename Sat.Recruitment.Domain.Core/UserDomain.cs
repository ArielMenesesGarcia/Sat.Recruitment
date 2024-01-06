using Sat.Recruitment.Domain.Entity;
using Sat.Recruitment.Domain.Interface;
using Sat.Recruitment.Infrastructure.Interface;
using Sat.Recruitment.Infrastructure.Repository;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserOperationsDomain _userOperations;

        public UserDomain(IUnitOfWork unit , IUserOperationsDomain userOperations)
        {
            _userRepository = unit.UserRepository;
            _userOperations = userOperations;
        }

        public async Task<bool> InsertAsync(User usuario)
        {
            usuario.Money = _userOperations.GetGif(usuario.UserType, usuario.Money);
            bool response = await _userRepository.InsertAsync(usuario);
            return response;
        }
    }
}

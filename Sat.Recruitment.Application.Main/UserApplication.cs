using System;
using System.Threading.Tasks;
using AutoMapper;
using Sat.Recruitment.Application.DTO;
using Sat.Recruitment.Application.Interface;
using Sat.Recruitment.Domain.Entity;
using Sat.Recruitment.Domain.Interface;
using Sat.Recruitment.Transversal.Common;
using Sat.Recruitment.Transversal.Mapper;

namespace Sat.Recruitment.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;

        public UserApplication( IUserDomain userDomain, IMapper mapper) {
         _userDomain = userDomain;
            _mapper = mapper;
        }
        public async Task<Result<bool>> InsertAsync(UserDTO userDTO)
        {
            var result = new Result<bool>();
            var newUser = _mapper.Map<User>(userDTO);
            var response = await _userDomain.InsertAsync(newUser);
            if (response)
            {
                result.Data = response;
                result.IsSuccess = true;
                result.Messaje = "Registro exitoso!.";
            }
            else
            {
                result.Messaje = "Registro duplicado";
            }

            return result;
        }
    }
}

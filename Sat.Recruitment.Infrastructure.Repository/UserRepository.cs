using System;
using System.Data;
using System.Threading.Tasks;
using Sat.Recruitment.Domain.Entity;
using Sat.Recruitment.Infrastructure.Interface;
using Sat.Recruitment.Transversal.Common;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using Sat.Recruitment.Transversal.Common;

namespace Sat.Recruitment.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDBConnectionFactory _dbConnection;

        public UserRepository(IDBConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<bool> InsertAsync(User user)
        {
            var _userCreated = false;
            try
            {
                using (var conn = _dbConnection.GetConnection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Name", user.Name);
                    parameters.Add("@Email", user.Email);

                    var exist = await conn.QueryAsync<int>("select count(*) from Users where Name = @Name and Email = @Email", param: parameters, commandType: CommandType.Text);
                    if (exist != null && exist.FirstOrDefault<int>() == 0)
                    {
                        parameters = new DynamicParameters();
                        parameters.Add("@Name", user.Name);
                        parameters.Add("@Email", user.Email);
                        parameters.Add("@Address", user.Address);
                        parameters.Add("@Phone", user.Phone);
                        parameters.Add("@UserType", user.UserType);
                        parameters.Add("@Money", user.Money);
                        string insertQuery = "insert into Users(Name, Email, Address, Phone, UserType, Money) Values (@Name, @Email, @Address, @Phone, @UserType, @Money)";
                        await conn.QueryAsync(insertQuery, param: parameters, commandType: CommandType.Text);
                        _userCreated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new BusinessCustomException("Error en el metodo InsertAsync(), EsxceptionMessage: "+ ex.Message);
            }
            
            return _userCreated;
        }
    }
}

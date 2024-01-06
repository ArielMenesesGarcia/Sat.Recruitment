using Sat.Recruitment.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public UnitOfWork(IUserRepository user)
        {
            UserRepository = user;
        }

        public void Dispose()
        {
           GC.SuppressFinalize(this);
        }
    }
}

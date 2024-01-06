using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Infrastructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
    }
}

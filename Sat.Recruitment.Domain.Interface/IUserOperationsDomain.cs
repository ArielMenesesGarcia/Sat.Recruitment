using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Interface
{
    public interface IUserOperationsDomain
    {
        decimal GetGif(string typeUser, decimal money);
    }
}

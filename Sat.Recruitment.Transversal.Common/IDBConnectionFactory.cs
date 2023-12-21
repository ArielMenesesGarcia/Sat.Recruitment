using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sat.Recruitment.Transversal.Common
{
    public interface IDBConnectionFactory 
    {
         IDbConnection GetConnection { get; }
    }
}

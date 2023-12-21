using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Sat.Recruitment.Transversal.Common;
 

namespace Sat.Recruitment.Infrastructure.Data
{
    public class ConnectionFactory : IDBConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get {
                var conexion = new SqlConnection();
                if (conexion == null) return null;

                conexion.ConnectionString = _configuration.GetConnectionString("RecruitmentConnection");
                conexion.Open();
                return conexion;
            } 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Transversal.Common
{
    public class BusinessCustomException : Exception
    {
        public BusinessCustomException()
        {
                
        }
        public BusinessCustomException(string message) : base(message) { }
    }
}

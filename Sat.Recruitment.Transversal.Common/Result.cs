using System;

namespace Sat.Recruitment.Transversal.Common
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Messaje { get; set; }
    }
}

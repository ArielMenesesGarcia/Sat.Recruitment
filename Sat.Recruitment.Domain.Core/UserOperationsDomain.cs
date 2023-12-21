using System;
using System.Collections.Generic;
using System.Text;
using Sat.Recruitment.Domain.Interface;

namespace Sat.Recruitment.Domain.Core
{
    public class UserOperationsDomain : IUserOperationsDomain
    {
        public decimal GetGif(string typeUser, decimal money)
        {
            decimal newValueMoney = 0;

            if (typeUser == "Normal")
            {
                if (money > 100)
                {
                    var percentage = Convert.ToDecimal(0.12);
                    //If new user is normal and has more than USD100
                    var gif = money * percentage;
                    newValueMoney = money + gif;
                }
                if (money < 100)
                {
                    if (money > 10)
                    {
                        var percentage = Convert.ToDecimal(0.8);
                        var gif = money * percentage;
                        newValueMoney = money + gif;
                    }
                }
            }
            if (typeUser == "SuperUser")
            {
                if (money > 100)
                {
                    var percentage = Convert.ToDecimal(0.20);
                    var gif = money * percentage;
                    newValueMoney = money + gif;
                }
            }
            if (typeUser == "Premium")
            {
                if(money > 100)
                {
                    var gif = money * 2;
                    newValueMoney = money + gif;
                }
            }

            return newValueMoney;
        }
    }
}

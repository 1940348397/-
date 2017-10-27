using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.MultiTableOpertion
{
    public class MultiTable_Coupon_Opertion
    {
        public void GetUserCouponInfo()
        {
            string sql = @"select * from( select row_number()over(order by tempcolumn)temprownumber, * from(select top 10 tempcolumn=0,* from TUser where  1=1  order by  UserId asc)t)tt where temprownumber>0";

        }
    }
}

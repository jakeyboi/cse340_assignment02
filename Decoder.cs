using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_jake_v1
{
    class Decoder
    {
        public static OrderClass decodeOrder(String orderStr)
        {
            OrderClass order = new OrderClass();
            Char[] delimiter = {','};
            String[] strArray = orderStr.Split(delimiter);
            order.setSenderId(strArray[0]);
            order.setCardNo(Convert.ToInt32(strArray[1]));
            order.setReceiverId(strArray[2]);
            order.setAmount(Convert.ToInt32(strArray[3]));
            order.setUnitPrice(Convert.ToInt32(strArray[4]));
            order.setTimestamp(Convert.ToDateTime(strArray[5]));
            return order;
        }
    }
}

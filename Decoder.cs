using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Decoder
    {
        public static OrderClass DecodeOrder(String orderStr)
        {
            OrderClass order = new OrderClass();
            Char[] delimiter = {','};
            String[] strArray = orderStr.Split(delimiter);
            order.SetSenderId(strArray[0]);
            order.SetCardNo(Convert.ToInt32(strArray[1]));
            order.SetReceiverId(strArray[2]);
            order.SetAmount(Convert.ToInt32(strArray[3]));
            order.SetUnitPrice(Convert.ToInt32(strArray[4]));
            order.SetTimestamp(Convert.ToDateTime(strArray[5]));
            return order;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Encoder
    {
        public static String EncodeOrder(OrderClass order)
        {
            String ordStr = order.GetSenderId() + "," + Convert.ToInt32(order.GetCardNo()) + "," + order.GetReceiverId()
                + "," + Convert.ToInt32(order.GetAmount()) + "," + Convert.ToInt32(order.GetUnitPrice()) + "," 
                + Convert.ToString(order.GetTimestamp());

            return ordStr;
        }
    }
}

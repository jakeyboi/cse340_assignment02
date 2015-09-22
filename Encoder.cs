using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_jake_v1
{
    class Encoder
    {
        public static String encodeOrder(OrderClass order)
        {
            String ordStr = order.getSenderId() + "," + Convert.ToInt32(order.getCardNo()) + "," + order.getReceiverId()
                + "," + Convert.ToInt32(order.getAmount()) + "," + Convert.ToInt32(order.getUnitPrice()) + "," 
                + Convert.ToString(order.getTimestamp());

            return ordStr;
        }
    }
}

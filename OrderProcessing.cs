using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Assignment2
{
    class OrderProcessing
    {
        private OrderClass order;
        private const double TAX = 1.1;
        private const double LOCATION_CHARGE = 10.00;

        public OrderProcessing(OrderClass order)
        {
            this.order = order;
        }

        public void ProcessNewOrder()
        {
            if (CardIsValid(order.GetCardNo()))
            {
                double totalCost = (order.GetUnitPrice() * order.GetAmount() + LOCATION_CHARGE) * TAX;
                Console.WriteLine("Total cost of order to " + order.GetReceiverId() + " from " + order.GetSenderId() 
                    + " is " + totalCost + " at unit price " + order.GetUnitPrice() + " at " + order.GetTimestamp());

                // swap the receiver/sender to send order confirmation back to the buffer
                String temp = order.GetReceiverId();
                order.SetReceiverId(order.GetSenderId());
                order.SetSenderId(temp);

                // Encode confirmation
                String confStr = Encoder.EncodeOrder(order);

                // Write to confirmationBuffer
                MainProgram.confirmationBuffer.sem.WaitOne();
                MainProgram.confirmationBuffer.SetOneCell(confStr);
            }
        }

        // credit card # must be between 5000 and 7000
        private bool CardIsValid(int cardNo)
        {
            return (cardNo >= 5000 && cardNo <= 7000);
        }
    }
}

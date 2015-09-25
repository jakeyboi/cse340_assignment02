using System;
using System.Threading;

namespace Assignment2
{
    class TravelAgency
    {
        // Track current price to compare with new prices
        private int currentPrice;

        // Constructor
        public TravelAgency()
        {
            currentPrice = 500;
        }

        // Event handler for the Airline to call when a price-cut event occurs
        public void TicketPriceCut(int newPrice)
        {
            int orderAmount = 0;
            int priceDifference = currentPrice - newPrice;

            // Only proceed if new price is less than current price
            if (priceDifference > 0)
            {
                if (priceDifference < 100)
                {
                    orderAmount = 5;
                }
                else if (priceDifference < 300)
                {
                    orderAmount = 15;
                }
                else if (priceDifference < 500)
                {
                    orderAmount = 25;
                }
                else if (priceDifference <= 800)
                {
                    orderAmount = 35;
                }

                // Create a new order
                OrderClass order = new OrderClass();
                order.SetSenderId(Thread.CurrentThread.Name);
                order.SetCardNo();
                order.SetReceiverId();
                order.SetAmount(orderAmount);
                order.SetUnitPrice(newPrice);

                // Encode the order for transmission
                String orderStr = Encoder.EncodeOrder(order);

                // Update current price
                currentPrice = newPrice;
            }
        }
    }
}
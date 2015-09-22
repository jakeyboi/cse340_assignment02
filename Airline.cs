using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Assignment02_jake_v1
{
    public delegate void priceCutEvent(int priceCut);

    class Airline
    {
        private int ticketsAvailable;
        private int ticketPrice;
        private int orderCounter;
        private int priceCutCounter;
        private PricingModel pricingModel;

        public static event priceCutEvent priceCut;

        public Airline()
        {
            ticketsAvailable = 100;
            ticketPrice = 500;
            orderCounter = 0;
            pricingModel = new PricingModel();
        }

        public void generateTicketPrice()
        {
            int newPrice = pricingModel.generateTicketPrice(ticketPrice, ticketsAvailable, orderCounter);
            if (ticketPrice > newPrice)
            {
                // price cut!! Trigger an event that calls the Travel Agency
                if(priceCut != null)
                {
                    priceCut(newPrice);
                }

                // need to verify what this is for?
                // if it reaches a certain number, the airline thread will terminate
                priceCutCounter++;
                ticketPrice = newPrice;
            }
            else
                ticketPrice = newPrice; // no event
        }

        public void orderProcessing(String ordStr)
        {
            orderCounter++;
            OrderClass order = Decoder.decodeOrder(ordStr);
            
            // need to set the order's ticket price to the airline's price
            order.setUnitPrice(ticketPrice);
            ticketsAvailable -= order.getAmount(); 

            // start thread running OrderProcessing class method 
            OrderProcessing ordPrc = new OrderProcessing(order);
            ordPrc.processOrderWithNewThread();

        }

    }
}

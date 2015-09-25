using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Assignment2
{
    public delegate void PriceCutDelegate(int priceCut);

    class Airline
    {
        private int ticketsAvailable;
        private int ticketPrice;
        private int orderCounter;
        private int priceCutCounter;
        private PricingModel pricingModel;

        public static event PriceCutDelegate PriceCutEvent;

        public Airline()
        {
            ticketsAvailable = 100;
            ticketPrice = 500;
            orderCounter = 0;
            pricingModel = new PricingModel();
        }

        public int GetTicketPrice()
        {
            return ticketPrice;
        }

        public void GenerateTicketPrice()
        {
            int newPrice = pricingModel.GenerateTicketPrice(ticketPrice, ticketsAvailable, orderCounter);
            if (newPrice < ticketPrice)
            {
                // price cut!! Trigger an event that calls the Travel Agency
                if (PriceCutEvent != null)
                {
                    PriceCutEvent(newPrice);
                }

                // need to verify what this is for?
                // if it reaches a certain number, the airline thread will terminate
                priceCutCounter++;
                ticketPrice = newPrice;
            }
            else
                ticketPrice = newPrice; // no event
        }

        public void OrderProcessing(String ordStr)
        {
            orderCounter++;
            OrderClass order = Decoder.DecodeOrder(ordStr);
            
            // need to set the order's ticket price to the airline's price
            order.SetUnitPrice(ticketPrice);
            ticketsAvailable -= order.GetAmount(); 

            // start thread running OrderProcessing class method 
            OrderProcessing ordPrc = new OrderProcessing(order);
            ordPrc.ProcessOrderWithNewThread();

        }

    }
}

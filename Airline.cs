using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Assignment2;

namespace Assignment2
{
    public delegate void PriceCutDelegate(String airlineId, int priceCut);

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
            priceCutCounter = 0;
            pricingModel = new PricingModel();
        }

        public int GetTicketPrice()
        {
            return ticketPrice;
        }

        public void AirlineFunc()
        {
            while (priceCutCounter <= 20)
            {
                Thread.Sleep(100);
                GenerateTicketPrice();
                
                // Read an order from the buffer
                String orderStr = MainProgram.orderBuffer.GetOneCell(Thread.CurrentThread.Name);

                // If an order for the airline was received, process order
                if (orderStr != null)
                {
                    OrderClass order = Decoder.DecodeOrder(orderStr);
                    MainProgram.orderBuffer.sem.Release(1);
                    orderCounter++;
                    ticketsAvailable -= order.GetAmount();
                    OrderProcessing orderProc = new OrderProcessing(order);
                    Thread orderProcThread = new Thread(new ThreadStart(orderProc.ProcessNewOrder));
                    orderProcThread.Start();
                }
            }
            MainProgram.airlineThreadCount--;
        }

        public void GenerateTicketPrice()
        {
            int newPrice = pricingModel.GenerateTicketPrice(ticketPrice, ticketsAvailable, orderCounter);
            if (newPrice < ticketPrice)
            {
                // price cut!! Trigger an event that calls the Travel Agency
                if (PriceCutEvent != null)
                {
                    PriceCutEvent(Thread.CurrentThread.Name, newPrice);
                }

                // if it reaches 20, the airline thread will terminate
                priceCutCounter++;
                ticketPrice = newPrice;
            }
            else
                ticketPrice = newPrice; // no event
        }
    }
}

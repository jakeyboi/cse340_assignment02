using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class PricingModel
    {
        private Random random;
        private const int HIGH_PRICE = 900;
        private const int LOW_PRICE = 100;

        public PricingModel()
        {
            random = new Random();
        }

        public int GenerateTicketPrice(int currentPrice, int ticketsAvailable, int ordersReceived)
        {
            int newPrice = 0;
            DateTime dt = new DateTime();
            int dow = (int)dt.DayOfWeek;

            // if it's sunday, mon, etc.
            if (dow == 0)
            {
                // if there's a lot of tickets left and there haven't been many orders, 
                // keep price lower. If there aren't many left and there have been several orders,
                // increase the price. Else, just have a standard sunday price.
                if (ticketsAvailable >= 50 && ordersReceived < 5)
                {
                    newPrice = random.Next(100, 200);
                }
                else if (ticketsAvailable < 50 && ordersReceived >= 5)
                {
                    newPrice = random.Next(301, 400);
                }
                else
                    newPrice = random.Next(201, 300); 
            }
            if (dow == 1)
            {
                if (ticketsAvailable >= 50 && ordersReceived < 5)
                {
                    newPrice = random.Next(200, 300);
                }
                else if (ticketsAvailable < 50 && ordersReceived >= 5)
                {
                    newPrice = random.Next(401, 500);
                }
                else
                    newPrice = random.Next(301, 400); 
            }
            if (dow == 2)
            {
                if (ticketsAvailable >= 50 && ordersReceived < 5)
                {
                    newPrice = random.Next(200, 300);
                }
                else if (ticketsAvailable < 50 && ordersReceived >= 5)
                {
                    newPrice = random.Next(401, 500);
                }
                else
                    newPrice = random.Next(301, 400); 
            }
            if (dow == 3)
            {
                if (ticketsAvailable >= 50 && ordersReceived < 5)
                {
                    newPrice = random.Next(200, 300);
                }
                else if (ticketsAvailable < 50 && ordersReceived >= 5)
                {
                    newPrice = random.Next(401, 500);
                }
                else
                    newPrice = random.Next(301, 400); 
            }
            if (dow == 4)
            {
                if (ticketsAvailable >= 50 && ordersReceived < 5)
                {
                    newPrice = random.Next(200, 300);
                }
                else if (ticketsAvailable < 50 && ordersReceived >= 5)
                {
                    newPrice = random.Next(401, 500);
                }
                else
                    newPrice = random.Next(301, 400); 

            }
            if (dow == 5)
            {
                if (ticketsAvailable >= 50 && ordersReceived < 5)
                {
                    newPrice = random.Next(500, 700);
                }
                else if (ticketsAvailable < 50 && ordersReceived >= 5)
                {
                    newPrice = random.Next(701, 900);
                }
                else
                    newPrice = random.Next(400, 600); 
            }
            if (dow == 6)
            {
                if (ticketsAvailable >= 50 && ordersReceived < 5)
                {
                    newPrice = random.Next(500, 700);
                }
                else if (ticketsAvailable < 50 && ordersReceived >= 5)
                {
                    newPrice = random.Next(701, 900);
                }
                else
                    newPrice = random.Next(400, 600); 
            }

            return newPrice;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

// Also need send a notification back to TravelAgency when order is completed
// probably just fire an event back when it's completed


//TODO: create event to fire back once order is completed

namespace Assignment02_jake_v1
{
    class OrderProcessing
    {
        private OrderClass order;
        private const double TAX = 0.1;
        private const double LOCATION_CHARGE = 10.00;

        // credit card # must be between 5000 and 7000


        // process the order here
        public OrderProcessing(OrderClass order)
        {
            this.order = order;
        }

        public void processNewOrder()
        {
            // check credit card # and calculate cost based on amount
            // unitPrice*NoOfTickets + Tax + LocationCharge

            // Buffer??? why not just a call back? would it go to the wrong agency? 
            // is there logic we could write to have an agency subscribe to a specific order?
            double totalCost = order.getUnitPrice() * order.getAmount() + TAX + LOCATION_CHARGE;

            // send order confirmation to TravelAgency/print on screen
            Console.WriteLine(totalCost);


            // send confirmation here?


            // BUFFER: Could just use an instance of the buffer class. use senderID?
        }

        // start a new thread to process the order here
        public void processOrderWithNewThread()
        {
            Thread orderThread = new Thread(processNewOrder);
            orderThread.Start();
        }
    }
}

using System;
using System.Threading;

namespace Assignment2
{

    public class MultiCellBuffer
    {
        private OrderClass[] buffer = new OrderClass[3];
        private bool writeable = true;

        public void SetOneCell(OrderClass order)
        {
            while (!writeable)
            {
                try
                {
                    Monitor.Wait(this);
                }
                catch { Console.WriteLine("Error in setOneCell method."); }
            }

            // Method logic here
        }

        public OrderClass GetOneCell()
        {
            while (writeable)
            {
                try
                {
                    Monitor.Wait(this);
                }
                catch { Console.WriteLine("Error in getOneCell method."); }
            }

            // Method logic here
        }
    }
}
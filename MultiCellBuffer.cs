using System;
using System.Threading;

namespace Assignment2
{
    public class MultiCellBuffer
    {
        private String[] buffer = new String[3];
        public Semaphore sem = new Semaphore(0, 3);

        public void SetOneCell(String orderStr)
        {
            lock (buffer)
            {
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (buffer[i] == null)
                    {
                        buffer[i] = orderStr;
                        return;
                    }
                }
            }
        }

        public String GetOneCell(String receiverId)
        {
            lock (buffer)
            {
                OrderClass order = new OrderClass();
                String orderStr = null;
                int orderIndex = -1;

                for (int i = 0; i < buffer.Length; i++)
                {
                    if (buffer[i] != null)
                    {
                        order = Decoder.DecodeOrder(buffer[i]);

                        if (order.GetReceiverId() == receiverId)
                        {
                            orderStr = buffer[i];
                            orderIndex = i;
                        }
                    }
                }

                if (orderStr != null)
                {
                    buffer[orderIndex] = null;
                }
                return orderStr;
            }
        }
    }
}
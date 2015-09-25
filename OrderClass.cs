using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class OrderClass
    {
        private String senderId;
        private int cardNo;
        private String receiverId;
        private int amount;
        private int unitPrice;
        private DateTime timestamp;

        public void SetSenderId(String senderId)
        {
            this.senderId = senderId;
        }

        public String GetSenderId()
        {
            return senderId;
        }

        public void SetCardNo(int cardNo)
        {
            this.cardNo = cardNo;
        }

        public int GetCardNo()
        {
            return cardNo;
        }

        public void SetReceiverId(String receiverId)
        {
            this.receiverId = receiverId;
        }

        public String GetReceiverId()
        {
            return receiverId;
        }

        public void SetAmount(int amount)
        {
            this.amount = amount;
        }

        public int GetAmount()
        {
            return amount;
        }

        public void SetUnitPrice(int unitPrice)
        {
            this.unitPrice = unitPrice;
        }

        public int GetUnitPrice()
        {
            return unitPrice;
        }

        public void SetTimestamp(DateTime timestamp)
        {
            this.timestamp = timestamp;
        }

        public DateTime GetTimestamp()
        {
            return timestamp;
        }


    }
}

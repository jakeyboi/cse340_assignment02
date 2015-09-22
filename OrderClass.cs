using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_jake_v1
{
    class OrderClass
    {
        private String senderId;
        private int cardNo;
        private String receiverId;
        private int amount;
        private int unitPrice;
        private DateTime timestamp;

        public void setSenderId(String senderId)
        {
            this.senderId = senderId;
        }

        public String getSenderId()
        {
            return senderId;
        }

        public void setCardNo(int cardNo)
        {
            this.cardNo = cardNo;
        }

        public int getCardNo()
        {
            return cardNo;
        }

        public void setReceiverId(String receiverId)
        {
            this.receiverId = receiverId;
        }

        public String getReceiverId()
        {
            return receiverId;
        }

        public void setAmount(int amount)
        {
            this.amount = amount;
        }

        public int getAmount()
        {
            return amount;
        }

        public void setUnitPrice(int unitPrice)
        {
            this.unitPrice = unitPrice;
        }

        public int getUnitPrice()
        {
            return unitPrice;
        }

        public void setTimestamp(DateTime timestamp)
        {
            this.timestamp = timestamp;
        }

        public DateTime getTimestamp()
        {
            return timestamp;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_jake_v1
{
    class Tester
    {
        static int Main(string[] args)
        {
            Airline airline = new Airline();

            for(int i = 0; i < 5; i++){
                airline.generateTicketPrice();
            }

            OrderClass ord = new OrderClass();
            ord.setSenderId("goob");
            ord.setReceiverId("meh");
            ord.setAmount(10);
            ord.setCardNo(1234);
            ord.setUnitPrice(200);
            DateTime dt = DateTime.Now;
            ord.setTimestamp(dt);

            String testa = Encoder.encodeOrder(ord);
            Console.WriteLine(testa);
            ord = Decoder.decodeOrder(testa);
            String testa1 = Encoder.encodeOrder(ord);
            Console.WriteLine(testa1);

            Console.ReadKey();
            return 0;
        }
    }
}

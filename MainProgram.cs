using System;
using Assignment2;
using System.Threading;

namespace Assignment2
{
    public class MainProgram
    {
        public static MultiCellBuffer orderBuffer = new MultiCellBuffer();
        public static MultiCellBuffer confirmationBuffer = new MultiCellBuffer();
        public static int airlineThreadCount = 0;

        public static void Main()
        {
            // Initialize Airline and TravelAgency objects
            Airline airline0 = new Airline();
            Airline airline1 = new Airline();
            Airline airline2 = new Airline();
            TravelAgency travelAgency = new TravelAgency();

            // Initialize and start Threads
            Thread airline0Thread = new Thread(new ThreadStart(airline0.AirlineFunc));
            airline0Thread.Name = "Airline 0";
            airline0Thread.Start();
            airlineThreadCount++;
            Thread airline1Thread = new Thread(new ThreadStart(airline1.AirlineFunc));
            airline1Thread.Name = "Airline 1";
            airline1Thread.Start();
            airlineThreadCount++;
            Thread airline2Thread = new Thread(new ThreadStart(airline2.AirlineFunc));
            airline2Thread.Name = "Airline 2";
            airline2Thread.Start();
            airlineThreadCount++;

            Thread[] travelAgencies = new Thread[5];

            for (int i = 100; i < 101; i++)
            {
                travelAgencies[i - 100] = new Thread(new ThreadStart(travelAgency.TravelAgencyFunc));
                travelAgencies[i - 100].Name = "Travel Agency " + i;
                travelAgencies[i - 100].Start();
            }

            // Bind TravelAgency event handler to Airline event
            Airline.PriceCutEvent += new PriceCutDelegate(travelAgency.TicketPriceCut);

            // Release 3 slots to start program
            orderBuffer.sem.Release(3);
            confirmationBuffer.sem.Release(3);

            Console.ReadLine();
        }
    }
}
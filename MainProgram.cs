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
            Thread[] airlines = new Thread[3];
            
            for (int i = 0; i < 3; i++)
            {
                airlines[i] = new Thread(new ThreadStart(airline0.AirlineFunc));
                airlines[i].Name = "AIRLINE " + i;
                airlines[i].Start();
                airlineThreadCount++;
            }

            Thread[] travelAgencies = new Thread[5];

            for (int i = 100; i < 105; i++)
            {
                travelAgencies[i - 100] = new Thread(new ThreadStart(travelAgency.TravelAgencyFunc));
                travelAgencies[i - 100].Name = "TRAVEL AGENCY " + i;
                travelAgencies[i - 100].Start();
            }

            // Bind TravelAgency event handler to Airline event
            Airline.PriceCutEvent += new PriceCutDelegate(travelAgency.TicketPriceCut);

            // Wait for all threads to start and block on the semaphore
            Thread.Sleep(500);

            // Release 3 slots to start program
            orderBuffer.sem.Release(3);
            confirmationBuffer.sem.Release(3);

            Console.ReadLine();
        }
    }
}
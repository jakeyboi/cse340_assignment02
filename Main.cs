using System;
using Assignment2;

public class Main
{
    public static MultiCellBuffer buffer = new MultiCellBuffer();

    public static void Main()
    {
        // Initialize Airline and TravelAgency objects
        Airline a0 = new Airline();
        Airline a1 = new Airline();
        Airline a2 = new Airline();
        TravelAgency travelAgency = new TravelAgency();

        // Initialize and start Threads
        Thread airline0 = new Thread(new ThreadStart(a0.GenerateTicketPrice()));
        Thread airline1 = new Thread(new ThreadStart(a1.GenerateTicketPrice()));
        Thread airline2 = new Thread(new ThreadStart(a2.GenerateTicketPrice()));
        airline0.Start();
        airline1.Start();
        airline2.Start();

        // Bind TravelAgency event handler to Airline event
        Airline.PriceCutEvent += new PriceCutDelegate(travelAgency.TicketPriceCut);

        // Start 5 TravelAgency threads
        Thread[] travelAgencies = new Thread[5];
        for (int i = 0; i < 5; i++)
        {
            travelAgencies[i].Name = (i + 1).ToString();
        }
    }
}
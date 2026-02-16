using System;
using System.Collections.Generic;
using System.Globalization; // Necessary for handling decimal points

class Program
{
    static void Main(string[] args)
    {
        // Force the program to use English/US formatting (dots instead of commas for decimals)
        // This ensures the output matches the assignment requirements regardless of system language.
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

        // 1. Initialize the list to store all activity types
        List<Activity> activities = new List<Activity>();

        // 2. Create activity instances with diverse data
        
        // Running in Kilometers (Standard)
        Running runKm = new Running("15 Feb 2026", 30, 4.8, "km");
        
        // Stationary Bicycle (Defaults to km/kph)
        StationaryBicycle bike = new StationaryBicycle("16 Feb 2026", 45, 20.0, "km");
        
        // Swimming in Kilometers (20 laps = 1km)
        Swimming swimKm = new Swimming("17 Feb 2026", 20, 20, "km");

        // --- THE MISSING ADDS ---
        
        // Running in Miles (3.0 miles is approx 4.8km)
        Running runMiles = new Running("18 Feb 2026", 30, 3.0, "miles");

        // Swimming in Miles (20 laps with mile calculation)
        Swimming swimMiles = new Swimming("19 Feb 2026", 25, 40, "miles");

        // 3. Add all objects to the same list using Polymorphism
        activities.Add(runKm);
        activities.Add(bike);
        activities.Add(swimKm);
        activities.Add(runMiles);
        activities.Add(swimMiles);

        // 4. Display the results
        Console.WriteLine("Exercise Tracking Log - Horizonte 593 Fitness");
        Console.WriteLine("---------------------------------------------");

        foreach (Activity activity in activities)
        {
            // Each class calculates its own metrics, but the output format is unified
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("\nExecution complete. Press any key to exit...");
        Console.ReadKey();
    }
}
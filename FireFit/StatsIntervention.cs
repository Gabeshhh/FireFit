using System;

namespace FireFit;

public class StatsInter
{
    public static void StatsInterventions()
    {
        Console.Clear();
        Console.WriteLine("--- Stats interventions ---");
        Dictionary<string, int> statsParMois = new Dictionary<string, int>();

        foreach (var i in Program.interventions)
        {
            string moisAnnee = i.Date.Substring(3);

            if (statsParMois.ContainsKey(moisAnnee))
            {
                statsParMois[moisAnnee]++;
            }
            else 
                statsParMois[moisAnnee] = 1;
        }

        foreach (var s in statsParMois)
        {
            Console.WriteLine($"{s.Key} : {s.Value} interventions");
        }
        
        Program.RetourMenu();
    }
}
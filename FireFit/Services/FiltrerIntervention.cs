using System;

namespace FireFit;

public class FiltrerInter
{
    public static void FiltreIntervention()
    {
        Console.WriteLine($"Par quel engin voulez-vous filtrer ?");
        string enginFiltre = Console.ReadLine();

        bool trouve = false;
        
        foreach (var i in Program.interventions)
        {
            if (i.Engin.Equals(enginFiltre, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"{i.Date} | {i.Engin} | {i.Intitule} | {i.Description}");
                trouve = true;
            }
        }

        if (!trouve)
        {
            Console.WriteLine("Aucune intervention pour cet engin.");
        }
        
        Program.RetourMenu();
    }
}
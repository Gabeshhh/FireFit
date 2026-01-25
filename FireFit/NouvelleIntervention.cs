using System;

namespace FireFit;

public class NouInter
{
    public static void NouvelleIntervention()
    {
        Console.Clear();
        Console.WriteLine("--- Nouvelle Intervention ---");

        Console.WriteLine("Date : ");
        string date = Console.ReadLine();

        Console.Write("Engin : ");
        string engin = Console.ReadLine();

        Console.WriteLine("Intitulé Intervention : ");
        string intitule = Console.ReadLine();

        Console.WriteLine("Ce qu'il y avait vraiment : "); 
        string description = Console.ReadLine();

        Intervention internvetion = new Intervention
        {
            Date = date,
            Engin = engin,
            Intitule = intitule,
            Description = description
        };

        Program.interventions.Add(internvetion);
        Program.SauvegarderInterventions();
        
        Console.Clear();
        Console.WriteLine("--- Internvetion enregistrée ---");
        
        Program.RetourMenu();
    }
}
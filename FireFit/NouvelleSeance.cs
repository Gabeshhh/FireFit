using System;

namespace FireFit;

public class NouvSeance
{
    public static void NouvelleSeance()
    {
        Console.Clear();
        Console.WriteLine("--- Nouvelle Séance ---");

        Console.WriteLine("Date : ");
        string date = Console.ReadLine();

        string nbExercices;
        int nombreExercices;
        Console.Write("Nombres Exercice : ");
        nbExercices = Console.ReadLine();
    
        if (!int.TryParse(nbExercices, out nombreExercices))
        {
            Console.WriteLine("Invalide");
            return;
        }

        List<string> nomExercices = new List<string>();
        for (int i = 0; i < nombreExercices; i++)
        {
            Console.WriteLine($"{i + 1} : ");
            string exo = Console.ReadLine();
            nomExercices.Add(exo);
        }
        
        Sport seance = new Sport
        {
            Date = date,
            NombreExo = nombreExercices,
            NomExo = nomExercices
        };

        Program.seanceSport.Add(seance);
        Program.SauvegarderSport();
        
        Console.Clear();
        Console.WriteLine("--- Internvetion enregistrée ---");
        
        Program.RetourMenu();
    }
}
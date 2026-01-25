using System;

namespace FireFit;

public class VoirSeances
{
    public static void VoirSeanceSport()
    {
        Console.Clear();
        Console.WriteLine("--- Liste des séances de sport ---");

        if (Program.seanceSport.Count == 0)
        {
            Console.WriteLine("Aucune séance enregistrée.");
            return;
        }

        foreach (var i in Program.seanceSport)
        {
            Console.WriteLine($"{i.Date} | {i.NombreExo} exercices");

            foreach (var exo in i.NomExo)
            {
                Console.WriteLine($"- {exo}");
            }
            Console.WriteLine();
        }
        
        Program.RetourMenu();
    }
}
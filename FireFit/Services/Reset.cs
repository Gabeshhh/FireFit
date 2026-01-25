using System;

namespace FireFit;

public class Reset
{
    public static void ReinitialiserDonnees()
    {
        Console.Clear();
        Console.WriteLine("⚠️ ATTENTION ⚠️");
        Console.WriteLine("Cette action supprimera TOUTES les données.");
        Console.WriteLine("Confirmer ? (O/N)");

        string confirmation = Console.ReadLine();

        if (confirmation?.ToUpper() != "O")
        {
            Console.WriteLine("Annulé.");
            Program.RetourMenu();
            return;
        }

        Program.interventions.Clear();
        Program.seanceSport.Clear();

        Program.SauvegarderInterventions();
        Program.SauvegarderSport();

        Console.WriteLine("Toutes les données ont été réinitialisées.");
        Program.RetourMenu();
    }
}
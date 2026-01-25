using System; 

namespace FireFit;

public class VoirInter
{
    public static void VoirIntervention()
    {
        Console.Clear();
        Console.WriteLine("--- Liste des interventions ---");

        if (Program.interventions.Count == 0)
        {
            Console.WriteLine("Aucune intervention enregistrée.");
            return;
        }

        foreach (var i in Program.interventions)
        {
            Console.WriteLine($"{i.Date} | {i.Engin} | {i.Intitule} | {i.Description}");
        }
        

        Console.WriteLine("Si vous voulez filtrer par engin tapez 1");
        string choix = Console.ReadLine();
        
        int choixUtilisateur;
        if (!int.TryParse(choix, out choixUtilisateur))
        {
            Console.WriteLine("Invalide");
            return;
        }

        if (choixUtilisateur == 1)
        {
            FiltrerInter.FiltreIntervention();
        }
        else
        {
            Console.WriteLine("Invalide");
            Program.RetourMenu();
        }
    }
}
using System;

namespace FireFit;

public class NbInter
{
        public static void VoirNombreInterventions()
    {
        Console.Clear();
        Console.WriteLine($"Vous avez au total : {Program.interventions.Count} interventions \n\n");
        
        // Voir le nombre d'intervention par engin
        Dictionary<string, int> enginInterventions = new Dictionary<string, int>();
        foreach (var i in Program.interventions)
        {
            string engin = i.Engin;

            if (enginInterventions.ContainsKey(engin))
            {
                enginInterventions[engin]++;
            }
            else
            {
                enginInterventions[engin] = 1;
            }
        }

        Console.WriteLine("--- Nombre interventions par engin ---");
        foreach (var x in enginInterventions)
        {
            Console.WriteLine($"{x.Key} : {x.Value}");
        }
        
        Program.RetourMenu();
    }
}
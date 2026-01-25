using System;
using System.Text.Json;
using System.IO;

namespace  FireFit;

public class Program
{
    // Création des variables qui permettent d'accéder aux var dans tout le fichier
    public static List<Intervention> interventions = new();
    public static List<Sport> seanceSport = new();
    public static bool continuer = true;
    
    static void Main()
    {
        ChargerInterventions();
        
        while (continuer)
        {
            AfficherMenu();
        }
    }
    
    // Fonction pour charger (Interventions - Séances) 
    static void ChargerSport()
    {
        if (!File.Exists("seancesport.json"))
            return;

        string json = File.ReadAllText("seancesport.json");

        var data = JsonSerializer.Deserialize<List<Sport>>(json);

        if (data != null)
            seanceSport = data;
    }
    
    // Fonction qui permets de charger les intervention pour les afficher dans la fonction 'VoirIntervention'
    static void ChargerInterventions()
    {
        if (!File.Exists("interventions.json"))
            return;

        string json = File.ReadAllText("interventions.json");

        var data = JsonSerializer.Deserialize<List<Intervention>>(json);

        if (data != null)
            interventions = data;
    }
    
    
    // Fonction pour la navigation de l'utilisateur
    public static void AfficherMenu()
    {
        Console.WriteLine("Que voulez-vous faire ?\n" +
                          "1. Entrée une nouvelle intervention\n" +
                          "2. Voir toutes les interventions\n" +
                          "3. Voir nombre interventions\n" +
                          "4. Nouvelle séance de sport\n" +
                          "5. Afficher séance de sport\n" +
                          "6. Réinitialiser les données\n" +
                          "7. Stats des internventions\n" +
                          "8. Quitter");

        string ChoixUtilisateur = Console.ReadLine();

        int Choix;
        if (!int.TryParse(ChoixUtilisateur, out Choix))
        {
            Console.WriteLine("Choix invalide.");
            return;
        }
        
        switch (Choix)
        {
            case 1:
                NouInter.NouvelleIntervention();
                break;
            case 2:
                VoirInter.VoirIntervention();
                break;
            case 3:
                NbInter.VoirNombreInterventions();
                break;
            case 4:
                NouvSeance.NouvelleSeance();
                break;
            case 5:
                VoirSeances.VoirSeanceSport();
                break;
            case 6:
                Reset.ReinitialiserDonnees();
                break;
            case 7:
                StatsInter.StatsInterventions();
                break;
            case 8:
                continuer = false;
                break;

            default:
                Console.WriteLine("Invalide.");
                Console.ReadKey();
                break;
        }
    }

    public static void RetourMenu()
    {
        Console.WriteLine("Appuyez sur une touche pour revenir au menu");
        Console.ReadKey();
    }
    
    // Fonction de sauvegarde (Interventions - Séances) 
    public static void SauvegarderInterventions()
    {
        string json = JsonSerializer.Serialize(interventions, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText("interventions.json", json);
    }

    // Fonction pour sauvegarder les séances de Sport
    public static void SauvegarderSport()
    {
        string json = JsonSerializer.Serialize(seanceSport, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText("seancesport.json", json);
    }
}
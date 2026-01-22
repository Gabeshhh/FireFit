using System;
using System.Text.Json;
using System.IO;

namespace  FireFit;

public class Program
{
    // Création des variables qui permettent d'accéder aux var dans tout le fichier
    static List<Intervention> interventions = new();
    private static List<Sport> seanceSport = new();
    static bool continuer = true;
    
    // Création de la fonction Main (Point d'entrée du programme - Appelle les autres fonctions)
    static void Main()
    {
        ChargerInterventions();
        
        while (continuer)
        {
            AfficherMenu();
        }
    }

    // Fonction pour afficher le menu
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
                NouvelleIntervention();
                break;
            case 2:
                VoirIntervention();
                break;
            case 3:
                VoirNombreInterventions();
                break;
            case 4:
                NouvelleSeance();
                break;
            case 5:
                VoirSeanceSport();
                break;
            case 6:
                ReinitialiserDonnees();
                break;
            case 7:
                StatsInterventions();
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

    // --------- INTERVENTION ---------
    // Fonction pour la création d'une intervention
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

        interventions.Add(internvetion);
        SauvegarderInterventions();
        
        Console.Clear();
        Console.WriteLine("--- Internvetion enregistrée ---");
        
        RetourMenu();
    }

    // Fonction pour voir les interventions enregistrées (via le fichier .json)
    public static void VoirIntervention()
    {
        Console.Clear();
        Console.WriteLine("--- Liste des interventions ---");

        if (interventions.Count == 0)
        {
            Console.WriteLine("Aucune intervention enregistrée.");
            return;
        }

        foreach (var i in interventions)
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
            FiltreIntervention();
        }
        else
        {
            Console.WriteLine("Invalide");
            RetourMenu();
        }
    }
    
    // Fonction qui permets de filtrer la recherche d'intervention
    static void FiltreIntervention()
    {
        Console.WriteLine($"Par quel engin voulez-vous filtrer ?");
        string enginFiltre = Console.ReadLine();

        bool trouve = false;
        
        foreach (var i in interventions)
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
        
        RetourMenu();
    }

    // Fonction pour voir le nombre d'intervention 
    static void VoirNombreInterventions()
    {
        Console.Clear();
        Console.WriteLine($"Vous avez au total : {interventions.Count} interventions \n\n");
        
        // Voir le nombre d'intervention par engin
        Dictionary<string, int> enginInterventions = new Dictionary<string, int>();
        foreach (var i in interventions)
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
        
        RetourMenu();
    }

    static void StatsInterventions()
    {
        Console.Clear();
        Console.WriteLine("--- Stats interventions ---");
        Dictionary<string, int> statsParMois = new Dictionary<string, int>();

        foreach (var i in interventions)
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
        
        RetourMenu();
    }
    
    // --------- SPORT ---------
    // Fonction pour la création d'une séance de sport
    static void NouvelleSeance()
    {
        Console.Clear();Console.Clear();
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

        seanceSport.Add(seance);
        SauvegarderSport();
        
        Console.Clear();
        Console.WriteLine("--- Internvetion enregistrée ---");
        
        RetourMenu();
    }

    static void VoirSeanceSport()
    {
        Console.Clear();
        Console.WriteLine("--- Liste des séances de sport ---");

        if (seanceSport.Count == 0)
        {
            Console.WriteLine("Aucune séance enregistrée.");
            return;
        }

        foreach (var i in seanceSport)
        {
            Console.WriteLine($"{i.Date} | {i.NombreExo} exercices");

            foreach (var exo in i.NomExo)
            {
                Console.WriteLine($"- {exo}");
            }
            Console.WriteLine();
        }
        
        RetourMenu();
    }
    
    
    // Fonction pour retourner au menu 
    static void RetourMenu()
    {
        Console.WriteLine("Appuyez sur une touche pour revenir au menu");
        Console.ReadKey();
    }
    
    // Fonction pour charger l'intervention dans le .json
    static void SauvegarderInterventions()
    {
        string json = JsonSerializer.Serialize(interventions, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText("interventions.json", json);
    }

    // Fonction pour sauvegarder les séances de Sport
    static void SauvegarderSport()
    {
        string json = JsonSerializer.Serialize(seanceSport, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText("seancesport.json", json);
    }
    
    // Fonction pour charger les séances de sport
    static void ChargerIntervention()
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
    
    // Fonction pour supprimer les données des fichiers json
    static void ReinitialiserDonnees()
    {
        Console.Clear();
        Console.WriteLine("⚠️ ATTENTION ⚠️");
        Console.WriteLine("Cette action supprimera TOUTES les données.");
        Console.WriteLine("Confirmer ? (O/N)");

        string confirmation = Console.ReadLine();

        if (confirmation?.ToUpper() != "O")
        {
            Console.WriteLine("Annulé.");
            RetourMenu();
            return;
        }

        interventions.Clear();
        seanceSport.Clear();

        SauvegarderInterventions();
        SauvegarderSport();

        Console.WriteLine("Toutes les données ont été réinitialisées.");
        RetourMenu();
    }
}
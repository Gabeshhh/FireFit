using System;
using System.Text.Json;
using System.IO;

namespace  FireFit;

public class Program
{
    // Création des variables qui permettent d'accéder aux var dans tout le fichier
    static List<Intervention> interventions = new(); 
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
        Console.WriteLine("Que voulez-vous faire ? \n1. Entrée une nouvelle intervention\n2. Voir toutes les interventions \n3. Voir nombre internvetions \n4. Quitter");

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
                continuer = false;
                break;
            default:
                Console.WriteLine("Invalide.");
                Console.ReadKey();
                break;
        }
    }

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
        Console.WriteLine("Appuyez sur une touche pour revenir au menu");
        Console.ReadKey();

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
            Console.WriteLine("Appuyez sur une touche pour revenir au menu");
            Console.ReadKey();
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
        
        Console.WriteLine("Appuyez sur une touche pour revenir au menu");
        Console.ReadKey();
    }

    // Fonction pour voir le nombre d'intervention 
    static void VoirNombreInterventions()
    {
        Console.WriteLine($"Vous avez au total : {interventions.Count} interventions \n\n");
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
}
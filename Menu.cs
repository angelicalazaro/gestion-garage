using GestionGarage.Models;
using GestionGarage.Models.Enums;
using GestionGarage.Models.Vehicules;

namespace GestionGarage;

public class MenuException : Exception
{
    public MenuException() : base()
    {
        
    }

    public MenuException(string message) : base(message)
    {
        
    }
}

public class Menu
{
    private Garage garage;

    public Menu(Garage garage)
    {
        this.garage = garage;
    }

    public void Start()
    {
        bool continuer = true;

        while (continuer)
        {
            try
            {
                AfficherMenu();
                int choix = GetChoixMenu();
                switch (choix)
                {
                    case 1:
                        AfficherVehicules();
                        break;
                    case 2:
                        AjouterVehicule();
                        break;
                    case 3:
                        SupprimerVehicule();
                        break;
                    case 4:
                        SelectionnerVehicule();
                        break;
                    case 5:
                        AfficherOptionsVehicule();
                        break;
                    case 6:
                        AjouterOptionsVehicule();
                        break;
                    case 7:
                        SupprimerOptions();
                        break;
                    case 8:
                        AfficherOptions();
                        break;
                    case 9:
                        AfficherMarques();
                        break;
                    case 10:
                        AfficherMoteurs();
                        break;
                    case 11:
                        ChargerGarage();
                        break;
                    case 12:
                        SauvegarderGarage();
                        break;
                    case 13:
                        Console.WriteLine("\n Au revoir !");
                        continuer = false;
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"\n ERREUR : {ex.Message}");
            }
            catch (MenuException ex)
            {
                Console.WriteLine($"\n ERREUR : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n ERREUR INATTENDUE: {ex.Message}");
            }
        }
    }

    private void AfficherMenu()
    {
        Console.WriteLine("\n------MENU GARAGE-----");
        Console.WriteLine("1. Afficher les véhicules");
        Console.WriteLine("2. Ajouter un véhicule");
        Console.WriteLine("3. Supprimer un véhicule");
        Console.WriteLine("4. Sélectionner un véhicule");
        Console.WriteLine("5. Afficher les options d'un véhicule");
        Console.WriteLine("6. Ajouter des options à un véhicule");
        Console.WriteLine("7. Supprimer des options à un vehicule");
        Console.WriteLine("8. Afficher les options");
        Console.WriteLine("9. Afficher les marques");
        Console.WriteLine("10. Afficher les types de moteur");
        Console.WriteLine("11. Charger le garage");
        Console.WriteLine("12. Sauvegarder le garage");
        Console.WriteLine("13. Quitter le menu");
        Console.WriteLine("-------------------------------");
        Console.Write("Votre choix : ");
    }

    // code convertir le choix de l'user
    private int GetChoix()
    {
        string? input = Console.ReadLine();

        try
        {
            return int.Parse(input);
        }
        catch (FormatException)
        {
            throw new FormatException("Le choix saisi n'est pas un nombre");
        }
    }

    private int GetChoixMenu()
    {
        int choix = GetChoix();
        if (choix < 1 || choix > 13)
        {
            throw new MenuException("Le choix doit être compris entre 1 et 13");
        }

        return choix;
    }

    private void AfficherVehicules()
    {
        Console.WriteLine("\n-----LISTE DES VÉHICULES-----");
        garage.Afficher();
    }

    private void AjouterVehicule()
    {
        
    }
    private void SupprimerVehicule()
    {
        // Ton code ici
    }

    // --- 4. Sélectionner un véhicule ---
    private void SelectionnerVehicule()
    {
        Console.WriteLine("\n------QUEL EST L'ID DU VÉHICULE ?------");
        GetChoix();
        TrouverVehiculeParId(GetChoix());
        

    }

    // --- 5. Afficher les options d'un véhicule ---
    private void AfficherOptionsVehicule()
    {
        
    }

    // --- 6. Ajouter des options à un véhicule ---
    private void AjouterOptionsVehicule()
    {
        // Ton code ici
    }

    // --- 7. Supprimer des options à un véhicule ---
    private void SupprimerOptions()
    {
        // Ton code ici
    }

    // --- 8. Afficher les options disponibles ---
    private void AfficherOptions()
    {
        Console.WriteLine("\n------OPTIONS DISPONIBLES-----");

        if (garage.Options.Count == 0)
        {
            Console.WriteLine("Aucune option disponible.");
            return;
        }

        foreach (var option in garage.Options)
        {
            option.Afficher();
        }
    }

    // --- 9. Afficher les marques ---
    private void AfficherMarques()
    {
        Console.WriteLine("\n-----MARQUES DISPONIBLES----");
        foreach (Marque marque in Enum.GetValues(typeof(Marque)))
        {
            Console.WriteLine($"- {marque}");
        }
    }

    // 10. Afficher les types de moteurs -> parcourir l'enum
    private void AfficherMoteurs()
    {
        Console.WriteLine("\n----TYPES DE MOTEURS DISPONIBLES----");
        foreach (TypeMoteur moteur in Enum.GetValues(typeof(Moteur)))
        {
            Console.WriteLine($"- {moteur}");
        }
    }

    // --- 11. Charger le garage (JSON) ---
    private void ChargerGarage()
    {
        // À faire à l'étape 3
    }

    // --- 12. Sauvegarder le garage (JSON) ---
    private void SauvegarderGarage()
    {
        // À faire à l'étape 3
    }

    // ========================================================
    // MÉTHODES UTILITAIRES (HELPERS)
    // ========================================================
    // 👇 AJOUTE TES MÉTHODES D'AIDE ICI
    

    // Trouve un véhicule dans le garage par son ID
    private Vehicule? TrouverVehiculeParId(int id)
    {
        foreach (var vehicule in garage.Vehicules)
        {
            if (vehicule.Id == id)
                return vehicule;
        }

        return null;
    }

    private Option? TrouverOptionParId(int id)
    {
        foreach (var option in garage.Options)
        {
            if (option.Id == id)
                return option;
        }

        return null;
    }

    private Moteur? TrouverMoteurParId(int id)
    {
        foreach (var moteur in garage.Moteurs)
        {
            if (moteur.Id == id)
                return moteur;
        }

        return null;
    }
}
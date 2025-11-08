using GestionGarage.Models;
using GestionGarage.Models.Enums;
using GestionGarage.Models.Vehicules;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

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
        Console.WriteLine("\n===== AJOUTER UN VÉHICULE =====");
        
        // 1. Choix du type de véhicule
        Console.WriteLine("\nQuel type de véhicule voulez-vous ajouter ?");
        Console.WriteLine("1. Voiture");
        Console.WriteLine("2. Camion");
        Console.WriteLine("3. Moto");
        Console.Write("Votre choix : ");
        
        try
        {
            int typeVehicule = GetChoix();
            
            if (typeVehicule < 1 || typeVehicule > 3)
            {
                Console.WriteLine("❌ Type de véhicule invalide");
                return;
            }
            
            // 2. Demander les infos communes
            Console.Write("\nNom du véhicule : ");
            string? nom = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(nom))
            {
                Console.WriteLine("Le nom ne peut pas être vide");
                return;
            }
            
            Console.Write("Prix (€) : ");
            decimal prix = decimal.Parse(Console.ReadLine());
            
            // 3. Choisir la marque
            Marque marque = ChoisirMarque();
            
            // 4. Choisir ou créer un moteur
            Moteur moteur = ChoisirOuCreerMoteur();
            
            // 5. Créer le véhicule selon son type
            Vehicule? nouveauVehicule = null;
            
            switch (typeVehicule)
            {
                case 1:
                    nouveauVehicule = CreerVoiture(nom, prix, marque, moteur);
                    break;
                case 2:
                    nouveauVehicule = CreerCamion(nom, prix, marque, moteur);
                    break;
                case 3:
                    nouveauVehicule = CreerMoto(nom, prix, marque, moteur);
                    break;
            }
            
            if (nouveauVehicule != null)
            {
                garage.AjouterVehicule(nouveauVehicule);
                Console.WriteLine($"\nVéhicule '{nom}' ajouté avec succès !");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur : Veuillez saisir un nombre valide");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }
    }

        
    // Methodes auxiliaires 

    private Marque ChoisirMarque()
    {
        Console.WriteLine("\n Marques disponibles :");
        
        // Créer un tableau des marques pour l'indexation
        Marque[] marques = (Marque[])Enum.GetValues(typeof(Marque));
        
        for (int i = 0; i < marques.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {marques[i]}");
        }
        
        Console.Write("Choisissez une marque (numéro) : ");
        int choix = GetChoix();
        
        if (choix < 1 || choix > marques.Length)
        {
            Console.WriteLine(" Choix invalide, marque par défaut : Peugeot");
            return Marque.Peugeot;
        }
        
        return marques[choix - 1];
    }

    private Moteur ChoisirOuCreerMoteur()
    {
        Console.WriteLine("\n Gestion du moteur :");
        Console.WriteLine("1. Choisir un moteur existant");
        Console.WriteLine("2. Créer un nouveau moteur");
        Console.Write("Votre choix : ");
        
        int choix = GetChoix();
        
        if (choix == 1 && garage.Moteurs.Count > 0)
        {
            // Afficher les moteurs existants
            Console.WriteLine("\n Moteurs disponibles :");
            foreach (var m in garage.Moteurs)
            {
                Console.WriteLine($"  ID {m.Id} : {m.Type} - {m.Puissance} CV");
            }
            
            Console.Write("Entrez l'ID du moteur : ");
            Moteur? moteur = TrouverMoteurParId(GetChoix());
            
            if (moteur != null)
            {
                return moteur;
            }
            
            Console.WriteLine(" Moteur introuvable, création d'un nouveau moteur...");
        }
        
        return CreerNouveauMoteur();
    }

    private Moteur CreerNouveauMoteur()
    {
        Console.WriteLine("\n Création d'un nouveau moteur");

        Console.WriteLine("\nTypes de moteur disponibles :");
        TypeMoteur[] types = (TypeMoteur[])Enum.GetValues(typeof(TypeMoteur));
        
        for (int i = 0; i < types.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {types[i]}");
        }
        
        Console.Write("Choisissez un type (numéro) : ");
        int choixType = GetChoix();
        
        TypeMoteur type = (choixType >= 1 && choixType <= types.Length) 
            ? types[choixType - 1] 
            : TypeMoteur.Essence;
        
        Console.Write("Puissance (CV) : ");
        int puissance = GetChoix();
        
        Moteur nouveauMoteur = new Moteur(type, puissance);
        garage.AjouterMoteur(nouveauMoteur);
        
        Console.WriteLine($" Moteur {type} de {puissance} CV créé !");
        
        return nouveauMoteur;
    }

    private Voiture CreerVoiture(string nom, decimal prix, Marque marque, Moteur moteur)
    {
        Console.WriteLine("\n Informations spécifiques à la voiture :");
        
        Console.Write("Chevaux fiscaux : ");
        int chevauxFiscaux = GetChoix();
        
        Console.Write("Nombre de portes : ");
        int nbPortes = GetChoix();
        
        Console.Write("Nombre de sièges : ");
        int nbSieges = GetChoix();
        
        Console.Write("Taille du coffre (m³) : ");
        decimal tailleCoffre = decimal.Parse(Console.ReadLine());
        
        return new Voiture(nom, prix, marque, moteur, chevauxFiscaux, nbPortes, nbSieges, tailleCoffre);
    }

    private Camion CreerCamion(string nom, decimal prix, Marque marque, Moteur moteur)
    {
        Console.WriteLine("\n Informations spécifiques au camion :");
        
        Console.Write("Nombre d'essieux : ");
        int nbEssieux = GetChoix();
        
        Console.Write("Poids de chargement (kg) : ");
        int poids = GetChoix();
        
        Console.Write("Volume de chargement (L) : ");
        int volume = GetChoix();
        
        return new Camion(nom, prix, marque, moteur, nbEssieux, poids, volume);
    }

    private Moto CreerMoto(string nom, decimal prix, Marque marque, Moteur moteur)
    {
        Console.WriteLine("\n Informations spécifiques à la moto :");
        
        Console.Write("Cylindrée (cc) : ");
        int cylindree = GetChoix();
        
        return new Moto(nom, prix, marque, moteur, cylindree);
    }
    private void SupprimerVehicule()
    {
        Console.WriteLine("\n------SUPPRIMER UN VÉHICULE------");
        if (garage.Vehicules.Count == 0)
        {
            Console.WriteLine("Aucun véhicule dans le garage");
            return;
        }
        Console.WriteLine("\nVéhicules disponibles : ");
        foreach (var vehicule in garage.Vehicules)
        {
            Console.WriteLine($" ID {vehicule.Id} : {vehicule.Nom}");
        }

        try
        {
            int id = GetChoix();
            Vehicule? vehicule = TrouverVehiculeParId(id);
            if (vehicule == null)
            {
                Console.WriteLine("Véhicule non trouvé avec cet ID");
            }
            else
            {
                Console.WriteLine($"Véhicule '{vehicule.Nom}' supprimé !");
                garage.Vehicules.Remove(vehicule);
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }
        
    }

    // --- 4. Sélectionner un véhicule ---
    private void SelectionnerVehicule()
    {
        Console.WriteLine("\n------QUEL EST L'ID DU VÉHICULE ?------");
        if (garage.Vehicules.Count == 0)
        {
            Console.WriteLine("Aucun véhicule dans le garage");
            return;
        }
        Console.WriteLine("\nVéhicules disponibles : ");
        foreach (var vehicule in garage.Vehicules)
        {
            Console.WriteLine($" ID {vehicule.Id} : {vehicule.Nom}");
        }
        try
        {
            int id = GetChoix();
            Vehicule? vehicule = TrouverVehiculeParId(id);
            if (vehicule == null)
            {
                Console.WriteLine("Véhicule non trouvé avec cet ID");
            }
            else
            {
                vehicule.Afficher();
            }

        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }
        
    }

    // --- 5. Afficher les options d'un véhicule ---
    private void AfficherOptionsVehicule()
    {
        Console.WriteLine("\n-----AFFICHER LES OPTIONS D'UN VÉHICULE-----");
        if (garage.Vehicules.Count == 0)
        {
            Console.WriteLine("Aucun véhicule dans le garage");
            return;
        }
        Console.WriteLine("\nVéhicules disponibles : ");
        foreach (var vehicule in garage.Vehicules)
        {
            Console.WriteLine($" ID {vehicule.Id} : {vehicule.Nom}");
        }
        try
        {
            int id = GetChoix();
            Vehicule? vehicule = TrouverVehiculeParId(id);
            if (vehicule == null)
            {
                Console.WriteLine("Véhicule non trouvé avec cet ID");
                return;
            }
            else
            {
                Console.WriteLine($"Options de '{vehicule.Nom}' : ");
                if (vehicule.Options.Count == 0)
                {
                    Console.WriteLine("Aucune option pour ce véhicule");
                }
                else
                {
                    foreach (var option in vehicule.Options)
                    {
                        Console.Write("  • ");
                        option.Afficher();
                    }
                }
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }
    }

    // --- 6. Ajouter des options à un véhicule ---
    private void AjouterOptionsVehicule()
    {
        Console.WriteLine("\n------AJOUTER UNE OPTION À UN VÉHICULE------");
        if (garage.Vehicules.Count == 0)
        {
            Console.WriteLine("Aucun véhicule dans le garage");
            return;
        }
    
        if (garage.Options.Count == 0)
        {
            Console.WriteLine("Aucune option disponible dans le catalogue");
            return;
        }
        Console.WriteLine("\nVéhicules disponibles :");
        foreach (var vehicule in garage.Vehicules)
            Console.WriteLine($"  ID {vehicule.Id} : {vehicule.Nom}");
    
        Console.WriteLine("\nEntrez l'ID du véhicule :");
    
        try
        {
            Vehicule? vehicule = TrouverVehiculeParId(GetChoix());
        
            if (vehicule == null)
            {
                Console.WriteLine("Véhicule introuvable");
                return;
            }
            Console.WriteLine($"\nCatalogue d'options disponibles :");
            foreach (var opt in garage.Options)
                Console.WriteLine($"  ID {opt.Id} : {opt.Nom} - {opt.Prix}€");

            Console.WriteLine("\nEntrez l'ID de l'option à ajouter :");
            Option? option = TrouverOptionParId(GetChoix());
        
            if (option == null)
            {
                Console.WriteLine("Option introuvable dans le catalogue");
                return;
            }

            if (vehicule.Options.Any(o => o.Id == option.Id))
            {
                Console.WriteLine($"L'option '{option.Nom}' est déjà installée sur ce véhicule");
                return;
            }
            vehicule.AjouterOption(option);
            Console.WriteLine($"Option '{option.Nom}' ajoutée à '{vehicule.Nom}'");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($" Erreur : {ex.Message}");
        }
    }

    // --- 7. Supprimer des options à un véhicule ---
    private void SupprimerOptions()
    {
        Console.WriteLine("\n------SUPPRIMER UNE OPTION D'UN VÉHICULE------");
        if (garage.Vehicules.Count == 0)
        {
            Console.WriteLine("Aucun véhicule dans le garage");
            return;
        }
        
        Console.WriteLine("\nVéhicules disponibles :");
        foreach (var v in garage.Vehicules)
            Console.WriteLine($"  ID {v.Id} : {v.Nom}");
    
        Console.WriteLine("\nEntrez l'ID du véhicule :");
    
        try
        {
            Vehicule? vehicule = TrouverVehiculeParId(GetChoix());
            if (vehicule == null)
            {
                Console.WriteLine(" Véhicule introuvable");
                return; 
            }
        
            if (vehicule.Options.Count == 0)
            {
                Console.WriteLine("Ce véhicule n'a aucune option");
                return; 
            }

            Console.WriteLine($"\nOptions de '{vehicule.Nom}' :");
            foreach (var opt in vehicule.Options)
                Console.WriteLine($"  ID {opt.Id} : {opt.Nom}");

            Console.WriteLine("\nEntrez l'ID de l'option à supprimer :");
            int idOption = GetChoix();

            Option? option = vehicule.Options.FirstOrDefault(option => option.Id == idOption);
        
            if (option == null)
            {
                Console.WriteLine(" Option introuvable");
            }
            else
            {
                vehicule.Options.Remove(option);
                Console.WriteLine($"Option '{option.Nom}' supprimée !");
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }
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
        foreach (TypeMoteur moteur in Enum.GetValues(typeof(TypeMoteur)))
        {
            Console.WriteLine($"- {moteur}");
        }
    }

    // --- 11. Charger le garage (JSON) ---
    private void ChargerGarage()
    {
        Console.WriteLine("\nChargement du garage...");
    
        if (!File.Exists("garage.json"))
        {
            Console.WriteLine("Aucun fichier de sauvegarde trouve.");
            return;
        }
    
        try
        {
            string json = File.ReadAllText("garage.json");
        
            var options = new JsonSerializerOptions
            {
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers = { AddPolymorphismSupport }
                }
            };
        
            Garage? garageCharge = JsonSerializer.Deserialize<Garage>(json, options);
        
            if (garageCharge != null)
            {
                this.garage = garageCharge;
                Console.WriteLine($"Garage '{garage.Nom}' charge avec succes !");
                Console.WriteLine($"Vehicules : {garage.Vehicules.Count}");
                Console.WriteLine($"Moteurs : {garage.Moteurs.Count}");
                Console.WriteLine($"Options : {garage.Options.Count}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors du chargement : {ex.Message}");
        }
    }

    private static void AddPolymorphismSupport(JsonTypeInfo typeInfo)
    {
        if (typeInfo.Type == typeof(Vehicule))
        {
            typeInfo.PolymorphismOptions = new JsonPolymorphismOptions
            {
                TypeDiscriminatorPropertyName = "$type",
                DerivedTypes =
                {
                    new JsonDerivedType(typeof(Voiture), "voiture"),
                    new JsonDerivedType(typeof(Camion), "camion"),
                    new JsonDerivedType(typeof(Moto), "moto")
                }
            };
        }
    }

    // --- 12. Sauvegarder le garage (JSON) ---
    private void SauvegarderGarage()
    {
        Console.WriteLine("\nSauvegarde du garage...");
    
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers = { AddPolymorphismSupport }
                }
            };
        
            string json = JsonSerializer.Serialize(garage, options);
            File.WriteAllText("garage.json", json);
        
            Console.WriteLine("Garage sauvegarde avec succes dans garage.json");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la sauvegarde : {ex.Message}");
        }
    }
    // Méthodes utilitaires pour trouver
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
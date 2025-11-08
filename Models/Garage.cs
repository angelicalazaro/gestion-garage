using GestionGarage.Models.Vehicules;

namespace GestionGarage.Models;
[Serializable]
public class Garage
{
    public string Nom { get; set; }
    public List<Vehicule> Vehicules { get; set; }
    public List<Moteur> Moteurs { get; set; }
    public List<Option> Options { get; set; }

    public Garage(string nom)
    {
        Nom = nom;
        Vehicules = new List<Vehicule>();
        Moteurs = new List<Moteur>();
        Options = new List<Option>();
    }

    public void AjouterVehicule(Vehicule vehicule)
    {
        Vehicules.Add(vehicule);
    }

    public void AjouterMoteur(Moteur moteur)
    {
        Moteurs.Add(moteur);
    }

    public void AjouterOption(Option option)
    {
        Options.Add(option);
    }

    public void Afficher()
    {
        Console.WriteLine($"------- Garage : {Nom}\n");
        Console.WriteLine($"Nombre de véhicules : {Vehicules.Count}\n");
        foreach (var vehicule in Vehicules)
        {
            vehicule.Afficher();
            Console.WriteLine();
        }
    }

    public void AfficherVoiture()
    {
        Console.WriteLine($"------Voitures du garage {Nom} : \n");
        foreach (var vehicule in Vehicules)
        {
            if (vehicule is Voiture)
            {
                vehicule.Afficher();
                Console.WriteLine();
            }
        }
    }    
    
    public void AfficherCamion()
    {
        Console.WriteLine($"------Camions du garage {Nom} : \n");
        foreach (var vehicule in Vehicules)
        {
            if (vehicule is Camion)
            {
                vehicule.Afficher();
                Console.WriteLine();
            }
        }
    }    
    
    public void AfficherMoto()
    {
        Console.WriteLine($"------Motos du garage {Nom} : \n");
        foreach (var vehicule in Vehicules)
        {
            if (vehicule is Moto)
            {
                vehicule.Afficher();
                Console.WriteLine();
            }
        }
    }

    public void TrierVehicule()
    {
        Vehicules.Sort();
    }
}
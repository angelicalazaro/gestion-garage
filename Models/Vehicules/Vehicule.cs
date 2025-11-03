using GestionGarage.Models.Enums;

namespace GestionGarage.Models.Vehicules;

public abstract class Vehicule : IComparable<Vehicule>
{
    private static int _increment = 0;
    public int Id { get; }
    public string Nom { get; set; }
    public decimal Prix { get; set; }
    public Marque Marque { get; set; }
    public Moteur Moteur { get; set; }
    public List<Option> Options { get; set; }
    
    public Vehicule(string nom, decimal prix, Marque marque, Moteur moteur)
    {
        _increment++;
        Id = _increment;
        Nom = nom;
        Prix = prix;
        Marque = marque;
        Moteur = moteur;
        Options = new List<Option>();
    }
    
    public void AjouterOption(Option option)
    {
        Options.Add(option);
    }
    
    public decimal ObtenirPrixHT()
    {
        return Prix;
    }
    
    public decimal ObtenirPrixOptions()
    {
        decimal total = 0;
        foreach (var option in Options)
        {
            total = total + option.Prix;
        }
        return total;
    }

    public abstract decimal CalculerTaxe();
    
    public decimal ObtenirPrixTotal()
    {
        return Prix + CalculerTaxe() + ObtenirPrixOptions();
    }
    
    public virtual void Afficher()
    {
        Console.WriteLine(" ----- Informations du véhicule -----");
        Console.WriteLine($"\nID : {Id} Nom : {Nom}");
        Console.WriteLine($"\nPrix HT : {ObtenirPrixHT()}");
        Moteur.Afficher(); // contient deja les methodes WriteLine
        Console.WriteLine($"\nOptions : ");
        if (Options.Count == 0)
        {
            Console.WriteLine("Aucune option sélectionnée");
        }
        else
        {
            foreach (var option in Options)
            {
                option.Afficher();
            }
        }
        Console.WriteLine($"\nPrix total des options : {ObtenirPrixOptions()}");
        Console.WriteLine($"\nTaxe calculée : {CalculerTaxe()}");
        Console.WriteLine($"\nPrix total du véhicule : {ObtenirPrixTotal()}");
    }

    public int CompareTo(Vehicule? other)
    {
        if (other == null) return 1;

        return this.Prix.CompareTo(other.Prix);
    }
}
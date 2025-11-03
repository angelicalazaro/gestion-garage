using GestionGarage.Models.Enums;

namespace GestionGarage.Models.Vehicules;

public class Camion : Vehicule
{
    public int NbEssieu { get; set; }
    public int Poids { get; set; }
    public int Volume { get; set; }

    public Camion(string nom, decimal prix, Marque marque, Moteur moteur, int nbEssieu, int poids, int volume) : base(nom, prix, marque, moteur)
    {
        NbEssieu = nbEssieu;
        Poids = poids;
        Volume = volume;
    }

    public override decimal CalculerTaxe()
    {
        return NbEssieu * 50m;
    }

    public override void Afficher()
    {
        base.Afficher();
        Console.WriteLine($"Nombre d'essieux : {NbEssieu}");
        Console.WriteLine($"Poids : {Poids}kg");
        Console.WriteLine($"Volume : {Volume}L");
    }
}
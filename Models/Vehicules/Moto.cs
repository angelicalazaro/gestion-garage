using GestionGarage.Models.Enums;

namespace GestionGarage.Models.Vehicules;

public class Moto : Vehicule
{
    public int Cylindree { get; set; }

    public Moto(string nom, decimal prix, Marque marque, Moteur moteur, int cylindree) : base(nom, prix, marque, moteur)
    {
        Cylindree = cylindree;
    }

    public override decimal CalculerTaxe()
    {
        return (int)(Cylindree * 0.3m);
    }

    public override void Afficher()
    {
        base.Afficher();
        Console.WriteLine($"Cylindrée : {Cylindree}cc");
    }
}
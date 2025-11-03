using GestionGarage.Models.Enums;

namespace GestionGarage.Models.Vehicules;

public class Voiture : Vehicule
{
    public int ChevauxFiscaux { get; set; }
    public int NbPorte { get; set; }
    public int NbSiege { get; set; }
    public decimal TailleCoffre { get; set; }
    
    public Voiture(string nom, decimal prix, Marque marque, Moteur moteur, int chevauxFiscaux, int nbPorte, int nbSiege, decimal tailleCoffre) : base(nom, prix, marque, moteur)
    {
        ChevauxFiscaux = chevauxFiscaux;
        NbPorte = nbPorte;
        NbSiege = nbSiege;
        TailleCoffre = tailleCoffre;
    }
    public override decimal CalculerTaxe()
    {
        return ChevauxFiscaux * 10m;
    }

    public override void Afficher()
    {
        base.Afficher();
        Console.WriteLine($"Chevaux fiscaux : {ChevauxFiscaux}");
        Console.WriteLine($"Nombre de portes : {NbPorte}");
        Console.WriteLine($"Nombre de sièges : {NbSiege}");
        Console.WriteLine($"Taille du coffre : {TailleCoffre}m3");
    }
}
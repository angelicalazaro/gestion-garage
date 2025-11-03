using GestionGarage.Models.Enums;

namespace GestionGarage.Models;

public class Moteur
{
    private static int _increment = 0;
    public int Id { get; }
    public TypeMoteur Type { get; set; }
    public int Puissance { get; set; }

    public Moteur(TypeMoteur type, int puissance)
    {
        _increment++;
        Id = _increment;
        Type = type;
        Puissance = puissance;
    }

    public void Afficher()
    {
        Console.WriteLine($"[ID : {Id} Type : {Type} Puissance : {Puissance}]");
    }
}
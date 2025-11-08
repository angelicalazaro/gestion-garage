namespace GestionGarage.Models;
[Serializable]
public class Option
{
    private static int _increment = 0;
    public int Id { get; }
    public string Nom { get; set; }
    public decimal Prix { get; set; }

    public Option(string nom, decimal prix)
    {
        _increment++;
        Id = _increment;
        Nom = nom;
        Prix = prix;
    }

    public void Afficher()
    {
        Console.WriteLine($"[ID : {Id} Option : {Nom} Prix : {Prix}€]");
    }
}
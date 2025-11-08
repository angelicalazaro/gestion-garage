using GestionGarage;
using GestionGarage.Models;
using GestionGarage.Models.Enums;
using GestionGarage.Models.Vehicules;

Console.WriteLine("========================================");
Console.WriteLine("   GESTION DE GARAGE - VROUM VROUM");
Console.WriteLine("========================================\n");

Garage garage = new Garage("Vroum Vroum Service");

Console.WriteLine("Initialisation du garage avec des donnees de test\n");

Moteur moteurEssence = new Moteur(TypeMoteur.Essence, 120);
Moteur moteurDiesel = new Moteur(TypeMoteur.Diesel, 150);
Moteur moteurElectrique = new Moteur(TypeMoteur.Electrique, 200);

garage.AjouterMoteur(moteurEssence);
garage.AjouterMoteur(moteurDiesel);
garage.AjouterMoteur(moteurElectrique);

Option gps = new Option("GPS", 500m);
Option toitOuvrant = new Option("Toit ouvrant", 1200m);
Option climatisation = new Option("Climatisation", 800m);

garage.AjouterOption(gps);
garage.AjouterOption(toitOuvrant);
garage.AjouterOption(climatisation);

Voiture voitureAlexita = new Voiture("Peugeot 107", 5000, Marque.Peugeot, moteurEssence, 5, 5, 4, 1.3m);
Voiture voitureAbdel = new Voiture("Golf", 3500m, Marque.Citroen, moteurDiesel, 5, 5, 3, 3.2m);

Camion camionPompiers = new Camion("Pompiers", 250000m, Marque.Renault, moteurDiesel, 3, 12, 8000);
Camion camionBob = new Camion("Bob le Flambeur", 99999m, Marque.Ferrari, moteurEssence, 4, 15000, 20000);

Moto moto1 = new Moto("Royal Enfield", 25000m, Marque.Audi, moteurEssence, 1000);
Moto flammeSupersonique = new Moto("Flamme Supersonique", 49999m, Marque.Peugeot, moteurElectrique, 300);

voitureAlexita.AjouterOption(toitOuvrant);
camionPompiers.AjouterOption(climatisation);
moto1.AjouterOption(gps);

garage.AjouterVehicule(voitureAlexita);
garage.AjouterVehicule(camionPompiers);
garage.AjouterVehicule(moto1);
garage.AjouterVehicule(voitureAbdel);
garage.AjouterVehicule(camionBob);
garage.AjouterVehicule(flammeSupersonique);

Console.WriteLine("Donnees de test chargees avec succes !");
Console.WriteLine($"  - Vehicules : {garage.Vehicules.Count}");
Console.WriteLine($"  - Moteurs disponibles : {garage.Moteurs.Count}");
Console.WriteLine($"  - Options disponibles : {garage.Options.Count}");
Console.WriteLine("\nLancement du menu interactif...");

Menu menu = new Menu(garage);
menu.Start();

Console.WriteLine("\nMerci d'avoir utilise l'application !");
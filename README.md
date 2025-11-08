🚗 Garage Management in french - C# Console Application

A complete garage management application developed in C#, featuring advanced OOP architecture, an interactive menu, and JSON persistence.

📸 Preview

![Main Menu](Images/menu1.png)

------------------------------------>

![Main Menu](Images/menu2.png)

🎯 Features

✅ Manage 3 types of vehicles (Car, Truck, Motorcycle)

✅ Engine and options management system

✅ Automatic tax calculation based on vehicle type

✅ Vehicle sorting by price (IComparable)

✅ Interactive menu with 13 features

✅ JSON save/load with polymorphism support

✅ Custom exception handling

✅ SOLID architecture

Architecture

GestionGarage/
├── Models/
│   ├── Enums/           # EngineType, Brand
│   ├── Vehicles/        # Abstract and derived classes
│   ├── Option.cs
│   ├── Engine.cs
│   └── Garage.cs
├── Menu.cs              # User interface
└── Program.cs

🛠️ Technologies

Language: C# 12

Framework: .NET 8

Serialization: System.Text.Json

IDE: JetBrains Rider

💻 Installation & Run

# Clone the repository
git clone https://github.com/angelicalazaro/gestion-garage.git

# Navigate to the folder
cd garage-garage

# Run the application
dotnet run
Applied Technical Concepts

Advanced OOP: Inheritance, polymorphism, abstract classes

Interfaces: IComparable for sorting

Custom exceptions: MenuException

JSON serialization: Polymorphism handling

Layered architecture: Models/UI separation

👤 Author

Angelica – Trainee Developer (RNCP "Application Designer and Developer" certification)
using System;
using System.IO;
using System.Text.Json;
using System.Threading;

class Program
{
    static string configFilePath = "config.json";

    class Config
    {
        public string Username { get; set; } = "default_user";
        public int RefreshRate { get; set; } = 60;
    }

    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== Välkommen till Konfigurationsverktyget ===\n");
        Console.ResetColor();
        Thread.Sleep(1000);

        Config config = LoadConfig();
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Konfigurationsmeny");
            Console.ResetColor();
            Console.WriteLine("1. Visa inställningar");
            Console.WriteLine("2. Ändra användarnamn");
            Console.WriteLine("3. Ändra uppdateringsfrekvens");
            Console.WriteLine("4. Avsluta");
            Console.Write("Välj ett alternativ: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowConfig(config);
                    break;
                case "2":
                    Console.Write("Ange nytt användarnamn: ");
                    config.Username = Console.ReadLine();
                    SaveConfig(config);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Användarnamn uppdaterat!");
                    Console.ResetColor();
                    break;
                case "3":
                    Console.Write("Ange ny uppdateringsfrekvens (i sekunder): ");
                    if (int.TryParse(Console.ReadLine(), out int newRate) && newRate > 0)
                    {
                        config.RefreshRate = newRate;
                        SaveConfig(config);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Uppdateringsfrekvens uppdaterad!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltigt värde! Ange en positiv siffra.");
                        Console.ResetColor();
                    }
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Avslutar programmet...");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    Console.ResetColor();
                    break;
            }
            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }

    static Config LoadConfig()
    {
        if (File.Exists(configFilePath))
        {
            string json = File.ReadAllText(configFilePath);
            return JsonSerializer.Deserialize<Config>(json) ?? new Config();
        }
        return new Config();
    }

    static void SaveConfig(Config config)
    {
        string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(configFilePath, json);
    }

    static void ShowConfig(Config config)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n=== Aktuella inställningar ===");
        Console.ResetColor();
        Console.WriteLine($"Användarnamn: {config.Username}");
        Console.WriteLine($"Uppdateringsfrekvens: {config.RefreshRate} sekunder\n");
    }
}

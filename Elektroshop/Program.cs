using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elektroshop;

using BabaElmo;

namespace Elektroshop {
    class Program {
        static void Main(string[] args) {
            /*
             * Lager init
            */
            Lager l = new Lager();
            Produkte g1 = new Geraete("Apple", "Handy", "iPhone6S", 699F);
            Produkte g2 = new Geraete("Apple", "Handy", "iPhone6S", 699F);
            Produkte g3 = new Geraete("Apple", "Handy", "iPhone5S", 599F);
            Produkte g4 = new Geraete("Apple", "Handy", "iPhone4S", 399F);
            Produkte g5 = new Geraete("Apple", "Handy", "iPhone4S", 399F);
            Produkte g6 = new Geraete("Apple", "Handy", "iPhone4S", 399F);
            Produkte g7 = new Geraete("Apple", "Handy", "iPhone4S", 399F);
            Produkte g8 = new Geraete("Apple", "Handy", "iPhone4S", 399F);
            Produkte g9 = new Geraete("Apple", "Handy", "iPhone4S", 399F);
            Produkte g10 = new Geraete("Apple", "Handy", "iPhone4S", 399F);
            Produkte g11 = new Geraete("Apple", "Handy", "iPhone4S", 299F);


            Produkte s1 = new Services("Reparatur", "iPhone6s Displayschaden", 99F);
            Produkte z1 = new Zubehoer("Kopfhörer", "Apple Airpods", 199F);

            l.Add(g1);
            l.Add(g2);
            l.Add(g3);
            l.Add(g4);
            l.Add(g5);
            l.Add(g6);
            l.Add(g7);
            l.Add(g8);
            l.Add(g9);
            l.Add(g10);
            l.Add(g11);
            l.Add(s1);
            l.Add(z1);


            /*
             * Verwaltung init
            */
            Verwaltung v = new Verwaltung();
            Person p1 = new Kunden(1, 100, "amana@koi.at", true, "Baba", "Elmo", "Sahulka");
            Person p2 = new Kunden(6, 3, "amana@bigmac.at", false, "Iskender", "Şiş", "Istanbul");
            Person p3 = new Mitarbeiter(11, 3999D, "Geschäftsführer", "Talha", "Anwar", "Korea");
            v.Add(p1);
            v.Add(p2);
            v.Add(p3);

            //Console.WriteLine(v.Serialize().ToString());
            

            while (true) {
                Console.WriteLine("Willkommen zur Elektroshop-Verwaltung");
                Console.WriteLine("1 - Produkte auflisten");
                Console.WriteLine("2 - Gerät hinzufügen");
                Console.WriteLine("3 - Service hinzufügen");
                Console.WriteLine("4 - Zubehör hinzufügen");
                Console.WriteLine("5 - Personen auflisten");
                Console.WriteLine("6 - Mitarbeiter hinzufügen");
                Console.WriteLine("7 - Kunde hinzufügen");
                Console.WriteLine("8 - Produkt verkaufen an Kunden");
                Console.WriteLine("9 - Vorlieben für Marken");
                Console.WriteLine("10 - Bisherige Einkäufe eines Kunden");
                Console.WriteLine("11 - Programm schließen");
                Console.WriteLine("-----------------------------------");

                switch (Console.ReadLine()) {

                    case "1":
                        l.PrintLagerbestand();
                        break;

                    case "2":
                        Console.Write("Marke: ");
                        string marke = Console.ReadLine();

                        Console.Write("Typ: ");
                        string typ = Console.ReadLine();

                        Console.Write("Bezeichnung: ");
                        string bezeichnung = Console.ReadLine();

                        Console.Write("Preis: ");
                        string preis = Console.ReadLine();

                        try {
                            Produkte g = new Geraete(marke, typ, bezeichnung, float.Parse(preis));
                            l.Add(g);
                            Console.WriteLine("Gerät hinzugefügt");
                        } catch { Console.WriteLine("Konnte nicht hinzugefügt werden, Prüfen Sie Ihre Eingaben!"); }
                break;

                    case "3":
                        Console.Write("Art: ");
                        string art = Console.ReadLine();

                        Console.Write("Bezeichnung: ");
                        bezeichnung = Console.ReadLine();

                        Console.Write("Preis: ");
                        preis = Console.ReadLine();

                        try {
                            Produkte s = new Services(art, bezeichnung, float.Parse(preis));
                            l.Add(s);
                            Console.WriteLine("Service hinzugefügt");
                        } catch { Console.WriteLine("Konnte nicht hinzugefügt werden, Prüfen Sie Ihre Eingaben!"); }

                        break;

                    case "4":
                        Console.Write("Verwendung: ");
                        string verwendung = Console.ReadLine();

                        Console.Write("Bezeichnung: ");
                        bezeichnung = Console.ReadLine();

                        Console.Write("Preis: ");
                        preis = Console.ReadLine();

                        try {
                            Produkte z = new Zubehoer(verwendung, bezeichnung, float.Parse(preis));
                            l.Add(z);
                            Console.WriteLine("Zubehör hinzugefügt");
                        } catch { Console.WriteLine("Konnte nicht hinzugefügt werden, Prüfen Sie Ihre Eingaben!"); }
                        break;

                    case "5":
                        v.PrintPersonen();
                        break;

                    case "6":
                        Console.Write("MitarbeiterNr: ");
                        string mitarbeiterNr = Console.ReadLine();

                        Console.Write("Gehalt: ");
                        string gehalt = Console.ReadLine();

                        Console.Write("Position: ");
                        string position = Console.ReadLine();

                        Console.Write("Vorname: ");
                        string vorname = Console.ReadLine();

                        Console.Write("Nachname: ");
                        string nachname = Console.ReadLine();

                        Console.Write("Adresse: ");
                        string adresse = Console.ReadLine();
                        try {
                            Person p = new Mitarbeiter(int.Parse(mitarbeiterNr), double.Parse(gehalt), position, vorname, nachname, adresse );
                            v.Add(p);
                            Console.WriteLine("Mitarbeiter wurde erfolgreich hinzugefügt");
                        } catch { Console.WriteLine("Konnte nicht hinzugefügt werden, Prüfen Sie Ihre Eingaben!"); }
                         break;

                    case "7":
                        Console.Write("KundenNr: ");
                        string kundenNr = Console.ReadLine();

                        Console.Write("Treuepunkte: ");
                        string treuepunkte = Console.ReadLine();

                        Console.Write("Mail: ");
                        string mail = Console.ReadLine();

                        Console.Write("Newsletter: (true oder false)");
                        string newsletter  = Console.ReadLine();

                        Console.Write("Vorname: ");
                        vorname = Console.ReadLine();

                        Console.Write("Nachname: ");
                        nachname = Console.ReadLine();

                        Console.Write("Adresse: ");
                        adresse = Console.ReadLine();
                        try {
                            Person p = new Kunden(int.Parse(kundenNr), int.Parse(treuepunkte), mail, bool.Parse(newsletter), vorname, nachname, adresse);
                            v.Add(p);
                            Console.WriteLine("Mitarbeiter wurde erfolgreich hinzugefügt");
                        } catch { Console.WriteLine("Konnte nicht hinzugefügt werden, Prüfen Sie Ihre Eingaben!"); }
                        break;

                    case "8":
                        Console.WriteLine("Buy Product");
                        break;

                    case "9":
                        Console.WriteLine("Vorlieben für Marken");
                        break;

                    case "10":
                        Console.WriteLine("Bisherige Einkäufe");
                        break;

                    case "11":
                        Environment.Exit(0);
                        break;

                    default:
                        ColouredWriteLine("Keine Funktionen mit dieser Eingabe!", ConsoleColor.White, ConsoleColor.Red);
                        break;
                }
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Drücken Sie Enter, um fortzufahren!");
                Console.ReadLine();
                Console.Clear();
            }
        }
        public static void ColouredWriteLine(string message, ConsoleColor background, ConsoleColor foreground) {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
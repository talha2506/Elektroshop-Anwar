using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elektroshop;

using BabaElmo;
using System.Xml.Linq;

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
            Produkte g12 = new Geraete("Samsung", "Tablet", "Galaxy Tab3 ", 200F);
            Produkte g13 = new Geraete("Huawei", "Handy", "P9", 450F);
            Produkte g14 = new Geraete("Huawei", "Handy", "P8 ", 350F);
            Produkte g15 = new Geraete("Samsung", "Handy", "Galaxy S5", 450F);
            Produkte g16 = new Geraete("Samsung", "Handy", "Galaxy S4", 350F);
            Produkte g17 = new Geraete("Samsung", "Handy", "Galaxy S3", 200F);





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
            l.Add(g12);
            l.Add(g13);
            l.Add(g14);
            l.Add(g15);
            l.Add(g16);
            l.Add(g17);
            l.Add(s1);
            l.Add(z1);


            /*
             * Verwaltung init
            */
            Verwaltung v = new Verwaltung();
            Person p1 = new Kunden(100, "amana@koi.at", true, "Baba", "Elmo", "Sahulka");
            Person p2 = new Kunden(100, "amana@koi.at", true, "Baba", "Elmo", "Sahulka");
            Person p3 = new Kunden(3, "amana@bigmac.at", false, "Iskender", "Şiş", "Istanbul");
            Person p4 = new Mitarbeiter(3999D, "Geschäftsführer", "Talha", "Anwar", "Korea");
            Person p5 = new Mitarbeiter(3999D, "Geschäftsführer", "Talha", "Anwar", "Korea");
            v.AddPerson(p1);
            v.AddPerson(p2);
            v.AddPerson(p3);
            v.AddPerson(p4);
            v.AddPerson(p5);

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
                Console.WriteLine("9 - Lager speichern");
                Console.WriteLine("10 - Personen speichern");
                Console.WriteLine("11 - Vorlieben für Marken");
                Console.WriteLine("12 - Bisherige Einkäufe");
                Console.WriteLine("13 - Daten von einzelnen Kunden bekommen");
                Console.WriteLine("14 - Daten von einzelnen Mitarbeitern bekommen");
                Console.WriteLine("15 - Programm schließen");
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
                            Person p = new Mitarbeiter(double.Parse(gehalt), position, vorname, nachname, adresse);
                            v.AddPerson(p);
                            Console.WriteLine("Mitarbeiter wurde erfolgreich hinzugefügt");
                        } catch { Console.WriteLine("Konnte nicht hinzugefügt werden, Prüfen Sie Ihre Eingaben!"); }
                        break;

                    case "7":

                        Console.Write("Treuepunkte: ");
                        string treuepunkte = Console.ReadLine();

                        Console.Write("Mail: ");
                        string mail = Console.ReadLine();

                        Console.Write("Newsletter: (true oder false)");
                        string newsletter = Console.ReadLine();

                        Console.Write("Vorname: ");
                        vorname = Console.ReadLine();

                        Console.Write("Nachname: ");
                        nachname = Console.ReadLine();

                        Console.Write("Adresse: ");
                        adresse = Console.ReadLine();
                        try {
                            Person p = new Kunden(int.Parse(treuepunkte), mail, bool.Parse(newsletter), vorname, nachname, adresse);
                            v.AddPerson(p);
                            Console.WriteLine("Mitarbeiter wurde erfolgreich hinzugefügt");
                        } catch { Console.WriteLine("Konnte nicht hinzugefügt werden, Prüfen Sie Ihre Eingaben!"); }
                        break;

                    case "8":
                        Console.WriteLine("Produkt kaufen");
                        l.PrintKennzeichen();
                        Console.Write("Produkt: ");
                        string input = Console.ReadLine();
                        Console.WriteLine();

                        v.PrintK_ID();

                        Console.Write("Kunde: ");
                        int kundennr = Convert.ToInt32(Console.ReadLine());
                        l.ChangeTreuepunkte(input, kundennr.ToString());

                        ((Kunden)v.GetFromKundenNr(kundennr)).Add(l.RemoveFromKennzeichen(input));
                        break;

                    case "9":
                        l.FillXml();
                        Console.WriteLine("Lager wurde gespeichert");
                        break;

                    case "10":
                        v.FillXml();
                        Console.WriteLine("Personen wurde gespeichert");
                        break;

                    case "11":
                        Console.WriteLine("Kunde auswählen:");
                        v.PrintK_ID();
                        Console.WriteLine("----------------------");
                        SortedDictionary<string, int> einkaufslist = new SortedDictionary<string, int>();
                        string k = Console.ReadLine();
                        var file = XElement.Load("../../personen.xml");
                        var erg = from kundenEinkauf in file.Descendants("Kennzeichnung")
                                  where kundenEinkauf.Attribute("K_ID").Value == k
                                  select kundenEinkauf.Element("Einkaufslisten").Element("Einkaufsliste");
                        foreach (var item in erg) {
                            item.Descendants("Geraete").ToList().ForEach(x => {
                                if (einkaufslist.ContainsKey(x.Element("Marke").Value)) {
                                    int anzahl = einkaufslist[x.Element("Marke").Value];
                                    einkaufslist.Remove(x.Element("Marke").Value);
                                    einkaufslist.Add(x.Element("Marke").Value, (anzahl + 1));
                                } else {
                                    einkaufslist.Add(x.Element("Marke").Value, 1);
                                }
                            });
                            foreach(var xn in einkaufslist) {
                                Console.WriteLine(xn.Key + ", " + xn.Value);
                            }
                            Console.WriteLine("--------------------------------------");

                            Console.WriteLine("Lieblingsmarke vom Kunden "+ k + ":");
                            var x1 = einkaufslist.Keys.ToList().OrderBy(x => x);
                            Console.WriteLine(x1.First());
                        }
                        break;

                    case "12":
                        Console.WriteLine("Bisherige Einkäufe");
                        v.PrintK_ID();
                        Console.Write("Kunde: ");
                        int kundenID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        v.PrintEinkaufe(kundenID);
                        break;

                    case "13":
                        v.PrintK_ID();
                        Console.WriteLine("Kunden-Nr eingeben");
                        string kunde = Console.ReadLine();
                        var xml = XElement.Load("../../personen.xml");
                        var erg1 = from x1 in xml.Descendants("Kennzeichnung")
                                   where x1.Attribute("K_ID").Value == kunde
                                   select new {
                                       Vorname = x1.Element("Vorname").Value,
                                       Nachname = x1.Element("Nachname").Value,
                                       Adresse = x1.Element("Adresse").Value,
                                       Mail = x1.Element("Mail").Value,
                                       Treuepunkte = x1.Element("Treuepunkte").Value
                                   };
                        Console.Clear();
                        foreach (var item in erg1) {
                            Console.WriteLine("Kunde: " + kunde);
                            Console.WriteLine(item.Vorname);
                            Console.WriteLine(item.Nachname);
                            Console.WriteLine(item.Adresse);
                            Console.WriteLine(item.Mail);
                            Console.WriteLine(item.Treuepunkte);
                        }
                        break;

                    case "14":
                        v.PrintM_ID();
                        Console.WriteLine("Mitarbeiter-Nr eingeben");
                        string mitarbeiter = Console.ReadLine();
                        var xml1 = XElement.Load("../../personen.xml");
                        var erg2 = from x1 in xml1.Descendants("Arbeiter")
                                   where x1.Attribute("M_ID").Value == mitarbeiter
                                   select new {
                                       Vorname = x1.Element("Vorname").Value,
                                       Nachname = x1.Element("Nachname").Value,
                                       Adresse = x1.Element("Adresse").Value,
                                       Position = x1.Element("Position").Value,
                                       Gehalt = x1.Element("Gehalt").Value
                                   };
                        Console.Clear();
                        foreach (var item in erg2) {
                            Console.WriteLine("Mitarbeiter: " + mitarbeiter);
                            Console.WriteLine(item.Vorname);
                            Console.WriteLine(item.Nachname);
                            Console.WriteLine(item.Adresse);
                            Console.WriteLine(item.Position);
                            Console.WriteLine(item.Gehalt);
                        }
                        break;

                    case "15":
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
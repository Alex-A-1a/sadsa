using System;
using System.Configuration;
using LibrarieModele;
using NivelStocareDate;

namespace EvidentaAlimente_Consola
{
    class Program
    {
        static void Main()
        {
            Aliment aliment = new Aliment();
            string numeFisier = ConfigurationManager.AppSettings["Alimente.txt"];
            AdministrareAlimente_FisierText adminAlimente = new AdministrareAlimente_FisierText("Alimente.txt");
            int nrAlimente = 0;
            adminAlimente.GetAlimente(out nrAlimente);
            string optiune;
            do
            {
                Console.WriteLine("I. Introducere informatii aliment.");
                Console.WriteLine("A. Afisarea ultimului aliment introdus.");
                Console.WriteLine("F. Afisare aliment din fisier.");
                Console.WriteLine("S. Salvare aliment in fisier.");
                Console.WriteLine("X. Inchidere program.");
                Console.WriteLine("Alegeti o optiune.");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "I":
                        aliment = CitireAlimentTastatura();
                        break;
                    case "A":
                        AfisareAliment(aliment);
                        break;
                    case "F":
                        Aliment[] alimente = adminAlimente.GetAlimente(out nrAlimente);
                        AfisareAlimente(alimente, nrAlimente);
                        break;
                    case "S":
                        int idAliment = nrAlimente + 1;
                        aliment.SetCod(idAliment);
                        adminAlimente.AddAliment(aliment);
                        nrAlimente = nrAlimente + 1;
                        break;
                    case "X":

                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta.");
                        break;
                }
            } while (optiune.ToUpper() != "X");
            Console.ReadKey();
        }
        public static void AfisareAliment(Aliment aliment)
        {
            string infoAliment = string.Format("Alimentul ce are codul #{0} este {1}, produs de {2}, este {3}, costa {4} lei si avem {5} bucati.",
                   aliment.GetCod(),
                   aliment.GetDenumire() ?? " NECUNOSCUT ",
                   aliment.GetProducator() ?? " NECUNOSCUT ",
                   aliment.GetTip() ?? " NECUNOSCUT ",
                   aliment.GetPret(),
                   aliment.GetStoc());
            Console.WriteLine(infoAliment);
        }
        public static void AfisareAlimente(Aliment[] alimente, int nrAlimente)
        {
            Console.WriteLine("Alimentele sunt:");
            for (int contor = 0; contor < nrAlimente; contor++)
            {
                AfisareAliment(alimente[contor]);
            }
        }
        public static Aliment CitireAlimentTastatura()
        {
            Console.WriteLine("Denumire: ");
            string Denumire = Console.ReadLine();
            Console.WriteLine("Producator: ");
            string Producator = Console.ReadLine();
            Console.WriteLine("Tip: ");
            string Tip = Console.ReadLine();
            Console.WriteLine("Pret: ");
            int Pret = int.Parse(Console.ReadLine());
            Console.WriteLine("Stoc: ");
            int Stoc = int.Parse(Console.ReadLine());
            Aliment aliment = new Aliment(Denumire, Producator, Tip, Pret, Stoc);
            return aliment;
        }
    }
}


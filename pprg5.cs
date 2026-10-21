using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        bool dziala = true;
        while (dziala)
        {
            Console.WriteLine();
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1 - Zadanie 1: Trzy sposoby odliczania");
            Console.WriteLine("2 - Zadanie 2: Suma wyprawy");
            Console.WriteLine("3 - Zadanie 3: Choinka z gwiazdek");
            Console.WriteLine("4 - Zadanie 4: Poprawna liczba tur");
            Console.WriteLine("5 - Zadanie 5: Symulacja walki turowej");
            Console.WriteLine("0 - Wyjście");
            Console.Write("Wybierz zadanie: ");

            string wybor = Console.ReadLine();
            Console.WriteLine();

            switch (wybor)
            {
                case "1": Zadanie1(); break;
                case "2": Zadanie2(); break;
                case "3": Zadanie3(); break;
                case "4": Zadanie4(); break;
                case "5": Zadanie5(); break;
                case "0": dziala = false; break;
                default: Console.WriteLine("Nieznana opcja."); break;
            }
        }
    }

    // ---------------------------------------------------------------
    // ZADANIE 1
    // ---------------------------------------------------------------
    static void Zadanie1()
    {
        // while
        Console.Write("while:      ");
        int i = 1;
        while (i <= 10)
        {
            Console.Write(i + " ");
            i++;
        }
        Console.WriteLine();

        // do-while
        Console.Write("do-while:   ");
        int j = 1;
        do
        {
            Console.Write(j + " ");
            j++;
        } while (j <= 10);
        Console.WriteLine();

        // for
        Console.Write("for:        ");
        for (int k = 1; k <= 10; k++)
        {
            Console.Write(k + " ");
        }
        Console.WriteLine();
        Console.WriteLine();

        // for - rosnąco / malejąco / parzyste
        Console.Write("Rosnąco: ");
        for (int a = 1; a <= 10; a++)
            Console.Write(a + " ");
        Console.WriteLine();

        Console.Write("Malejąco: ");
        for (int a = 10; a >= 1; a--)
            Console.Write(a + " ");
        Console.WriteLine();

        Console.Write("Parzyste: ");
        for (int a = 0; a <= 20; a += 2)
            Console.Write(a + " ");
        Console.WriteLine();

        Console.WriteLine("Start!");
        Console.WriteLine();

        // Odpowiedzi na pytania
        Console.WriteLine("Odpowiedzi:");
        Console.WriteLine("1. Najczytelniej znaną liczbę powtórzeń opisuje pętla for (start, warunek i krok są w jednym miejscu).");
        Console.WriteLine("2. Jeśli warunek while od początku jest fałszywy, pętla wykona się 0 razy.");
        Console.WriteLine("3. W tej samej sytuacji do-while wykona się 1 raz (warunek sprawdzany jest po wykonaniu ciała pętli).");
    }

    // ---------------------------------------------------------------
    // ZADANIE 2
    // ---------------------------------------------------------------
    static void Zadanie2()
    {
        int dni;
        do
        {
            Console.Write("Ile dni trwa wyprawa? (1-7) ");
            dni = int.Parse(Console.ReadLine());
        } while (dni < 1 || dni > 7);

        int lacznie = 0;
        int udaneDni = 0;

        for (int dzien = 1; dzien <= dni; dzien++)
        {
            Console.Write($"Złoto w dniu {dzien}: ");
            int zloto = int.Parse(Console.ReadLine());

            lacznie += zloto;
            if (zloto > 10)
                udaneDni++;
        }

        Console.WriteLine();
        Console.WriteLine($"Łącznie znaleziono: {lacznie} sztuk złota.");
        Console.WriteLine($"Dni z wynikiem powyżej 10: {udaneDni}.");
    }

    // ---------------------------------------------------------------
    // ZADANIE 3
    // ---------------------------------------------------------------
    static void Zadanie3()
    {
        int wysokosc;
        do
        {
            Console.Write("Podaj wysokość choinki (2-10): ");
            wysokosc = int.Parse(Console.ReadLine());
        } while (wysokosc < 2 || wysokosc > 10);

        // korona
        for (int wiersz = 1; wiersz <= wysokosc; wiersz++)
        {
            int spacje = wysokosc - wiersz;
            int gwiazdki = 2 * wiersz - 1;

            for (int s = 0; s < spacje; s++)
                Console.Write(" ");

            for (int g = 0; g < gwiazdki; g++)
                Console.Write("*");

            Console.WriteLine();
        }

        // pień
        for (int s = 0; s < wysokosc - 1; s++)
            Console.Write(" ");
        Console.WriteLine("*");

        Console.WriteLine();
        Console.WriteLine("Wyjaśnienie:");
        Console.WriteLine("W każdym kolejnym wierszu liczba spacji maleje o 1 (od wysokość-1 do 0),");
        Console.WriteLine("a liczba gwiazdek rośnie o 2 (1, 3, 5, 7...).");
        Console.WriteLine($"W ostatnim wierszu korony jest {2 * wysokosc - 1} gwiazdek (wzór: 2 * wysokość - 1).");
    }

    // ---------------------------------------------------------------
    // ZADANIE 4
    // ---------------------------------------------------------------
    static void Zadanie4()
    {
        int liczbaTur;

        while (true)
        {
            Console.Write("Podaj liczbę tur od 1 do 10: ");
            string tekst = Console.ReadLine();

            if (!int.TryParse(tekst, out liczbaTur))
            {
                Console.WriteLine("Wpisz liczbę całkowitą.");
                continue;
            }

            if (liczbaTur < 1)
            {
                Console.WriteLine("Liczba musi należeć do zakresu 1–10.");
                continue;
            }

            if (liczbaTur > 10)
            {
                Console.WriteLine("Liczba musi należeć do zakresu 1–10.");
                continue;
            }

            break; // poprawna wartość
        }

        Console.WriteLine($"Rozpoczynam grę na {liczbaTur} tur.");

        for (int tura = liczbaTur; tura >= 1; tura--)
        {
            Console.WriteLine($"Pozostało tur: {tura}");
        }
        Console.WriteLine("Start!");
    }

    // ---------------------------------------------------------------
    // ZADANIE 5 (z opcją losowych obrażeń dla chętnych)
    // ---------------------------------------------------------------
    static void Zadanie5()
    {
        Console.Write("Włączyć losowe obrażenia? (t/n): ");
        bool losowe = Console.ReadLine().Trim().ToLower() == "t";

        Random losowanie = new Random();

        int zdrowieBohatera = 60;
        int zdrowiePrzeciwnika = 45;
        int liczbaMikstur = 2;
        int numerTury = 1;
        bool ucieczka = false;

        while (zdrowieBohatera > 0 && zdrowiePrzeciwnika > 0 && !ucieczka)
        {
            Console.WriteLine();
            Console.WriteLine($"--- Tura {numerTury} ---");
            Console.WriteLine($"Bohater: {zdrowieBohatera} HP | Przeciwnik: {zdrowiePrzeciwnika} HP | Mikstury: {liczbaMikstur}");
            Console.WriteLine("1 - atak, 2 - mikstura, 3 - ucieczka");
            Console.Write("Wybierz akcję: ");

            string akcja = Console.ReadLine();
            bool poprawnaAkcja = false;

            switch (akcja)
            {
                case "1":
                    int obrazeniaBohatera = losowe ? losowanie.Next(8, 16) : 12;
                    zdrowiePrzeciwnika -= obrazeniaBohatera;
                    Console.WriteLine($"Bohater zadaje {obrazeniaBohatera} punktów obrażeń.");
                    poprawnaAkcja = true;
                    break;

                case "2":
                    if (liczbaMikstur > 0)
                    {
                        zdrowieBohatera += 15;
                        liczbaMikstur--;
                        Console.WriteLine("Bohater używa mikstury i odzyskuje 15 punktów życia.");
                        poprawnaAkcja = true;
                    }
                    else
                    {
                        Console.WriteLine("Nie masz już mikstur!");
                    }
                    break;

                case "3":
                    ucieczka = true;
                    Console.WriteLine("Bohater ucieka z walki.");
                    break;

                default:
                    Console.WriteLine("Nieznana opcja. Spróbuj ponownie.");
                    break;
            }

            // przeciwnik atakuje tylko po poprawnej akcji i tylko jeśli żyje
            if (poprawnaAkcja && zdrowiePrzeciwnika > 0)
            {
                int obrazeniaPrzeciwnika = losowe ? losowanie.Next(4, 10) : 7;
                zdrowieBohatera -= obrazeniaPrzeciwnika;
                Console.WriteLine($"Przeciwnik zadaje {obrazeniaPrzeciwnika} punktów obrażeń.");
            }

            if (poprawnaAkcja)
                numerTury++;
        }

        Console.WriteLine();
        if (ucieczka)
            Console.WriteLine("Uciekłeś z walki.");
        else if (zdrowiePrzeciwnika <= 0)
            Console.WriteLine("Zwycięstwo! Pokonałeś przeciwnika.");
        else
            Console.WriteLine("Porażka... Bohater został pokonany.");
    }
}

using pregatire_test_1___1.Exceptions;

namespace pregatire_test_1___1;

/*
Să se scrie un program C# care gestionează rezervările pentru zborul cu avionul pentru o companie aeriană. Pentru un zbor interesează numărul, data, aeroportul sursă și cel destinație și rezervările realizate. Rezervarea se face pe baza adresei de e-mail. Se cunoaște că există 2 tipuri de zboruri:

    Local: se pot face rezervări pentru maxim 6 persoane, iar prețul rezervării se calculează ca fiind nr. de persoane * 100 + nr. de bagaje * 25
    Transatlantic: se pot face rezervări pentru maxim 10 persoane și 10 bagaje, iar prețul rezervării se calculează ca fiind nr. de persoane * 500 + nr. de bagaje * 50 + 100

Sarcini:

    Implementați modelul OO care să reprezinte contextul de mai sus aplicând principiile POO – 6p
    Să se creeze compania cu câte un zbor din fiecare categorie și să se adauge cel puțin o rezervare la fiecare zbor – 1p
    Să se afișeze toate rezervările cu număr de persoane și valoare rezervării pentru un zbor – 1p
    Să se afișeze numărul de pasageri pentru un zbor – 1p
    Să se valideze numărul maxim de persoane pe validare – 1p
    BONUS: disponibilitatea locurilor pentru un zbor se face prin apelarea unui serviciu extern ce primește numarul zborului și numărul de personae și returnează un bool care indică daca mai sunt locuri, apelarea serviciului poate genera și următoarele excepții: zbor inexistent, serviciu indisponibil – (1p – 2p)

 */

class Program
{
    static void Main(string[] args)
    {
        var localFlight = new LocalFlight("20341", new DateOnly(2024, 12, 25), "Timisoara", "Iasi");
        var transatlanticFlight = new TransatlanticFlight("64983", new DateOnly(2024, 11, 21), "Paris", "New York");
        FlightCompany company = new FlightCompany(localFlight, transatlanticFlight);
        
        List<Reservation> locals = new List<Reservation>()
        {
            new Reservation("Ioan Cucea", "cucea.ioan@gamil.com", 5, 4, "local"),
            new Reservation("Jimmy To", "jimmyto@gamil.com", 10, 4, "local"),
        };
        List<Reservation> transatlantics = new List<Reservation>()
        {
            new Reservation("Elon Musk", "elonmus@gamil.com", 1, 20, "transatlantic"),
            new Reservation("Gordea George", "geogeo@gmail.com", 21, 21, "transatlantic"),
            new Reservation("John Doe", "johndoe@gmail.com", 19, 1, "transatlantic"),
        };
        foreach (var item in locals)
        {
            company.AddLocalFlightReservation(item);
        }
        foreach (var item in transatlantics)
        {
            company.AddTransatlanticFlightReservation(item);
        }
        
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("reservarile pentru zborul local sunt:");
        company.PrintLocalFlightReservations();
        Console.WriteLine("reservarile pentru zborul transatlantic sunt:");
        company.PrintTransatlanticFlightReservations();
        
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine($"nr de locuri rezervate pentur zborul local: {company.GetNumberOfLocalPassengers()}");
        Console.WriteLine($"nr de locuri rezervate pentur zborul transatlantic: {company.GetNumberOfTransatlanticPassengers()}");

        
        List<string> flightsToCheck = new List<string>()
        {
            "12345", "20341", "64983", "64983", "25343", "20341"
        };

        Console.WriteLine("---------------------------------------------------");
        foreach (var item in flightsToCheck)
        {
            try
            {
                var response = company.HasAvailableSeats(item, 2);
                if (response)
                    Console.WriteLine($"flight {item} has enough available places");
                else
                    Console.WriteLine($"flight {item} does not have enough available places");
            }
            catch (UnavailableFlightException e)
            {
                Console.WriteLine($"caught UnavailableFlightException: {e.Message}");
            }
            catch (ServiceOfflineException e)
            {
                Console.WriteLine($"caught UnavailableFlightException: {e.Message}");
            }
        }
    }
}
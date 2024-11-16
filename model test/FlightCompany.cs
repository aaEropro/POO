using System.Security.Cryptography;
using pregatire_test_1___1.Exceptions;

namespace pregatire_test_1___1;

public class FlightCompany
{
    private LocalFlight _localFlight;
    private TransatlanticFlight _transatlanticFlight;

    public FlightCompany(LocalFlight localFlight, TransatlanticFlight transatlanticFlight)
    {
        _localFlight = localFlight;
        _transatlanticFlight = transatlanticFlight;
    }

    /// <summary>
    /// attempts to add a reservation to the local flight.
    /// prints an error if the reservation is invalid.
    /// </summary>
    public void AddLocalFlightReservation(Reservation reservation)
    {
        if (reservation.GetPersonsPerReservation() > 6)
        {
            Console.WriteLine($"nr maxim de locuri pentru rezervare la zborul local este 6, " +
                              $"pe rezervare sunt {reservation.GetPersonsPerReservation()}");
            return;
        }
        
        _localFlight.AddReservation(reservation);
    }

    /// <summary>
    /// attempts to add a reservation to the transatlantic flight.
    /// prints an error if the reservation is invalid.
    /// </summary>
    public void AddTransatlanticFlightReservation(Reservation reservation)
    {
        if (reservation.GetPersonsPerReservation() > 10)
        {
            Console.WriteLine($"nr maxim de locuri pentru rezervare la zborul local este 10, " +
                              $"pe rezervare sunt {reservation.GetPersonsPerReservation()}");
            return;
        }
        
        _transatlanticFlight.AddReservation(reservation);
    }

    /// <summary>
    /// prints the approved reservations for the local flight
    /// </summary>
    public void PrintLocalFlightReservations()
    {
        _localFlight.PrintReservations();
    }
    
    /// <summary>
    /// prints the approved reservations for the transatlantic flight
    /// </summary>
    public void PrintTransatlanticFlightReservations()
    {
        _transatlanticFlight.PrintReservations();
    }

    public int GetNumberOfLocalPassengers() => _localFlight.GetNumberOfPassengers();
    public int GetNumberOfTransatlanticPassengers() => _transatlanticFlight.GetNumberOfPassengers();

    /// <summary>
    /// returns `true` if the flight has enough available seats, else `false` or thorws an error.
    /// </summary>
    public bool HasAvailableSeats(string flightNumber, int personCount)
    {
        var random = new Random();

        if (random.Next(1, 5) == 1)
        {
            throw new ServiceOfflineException("serviciu indisponibil momentan");
        }
        
        if (_localFlight.GetFlightNumber() != flightNumber && _transatlanticFlight.GetFlightNumber() != flightNumber)
        {
            throw new UnavailableFlightException($"nu exista zborul cu numarul {flightNumber}");
        }
            
        return random.Next(0, 1) == 1;
    }
}
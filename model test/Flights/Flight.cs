namespace pregatire_test_1___1;

public class Flight
{
    private string _flightNumber;
    private DateOnly _flightDate;
    private string _startAirport;
    private string _endAirport;
    
    protected List<Reservation> Reservations;
    
    private int _reservedSeats = 0;
    private int _maxReservedSeats = 6;

    public Flight(string flightNumber, DateOnly flightDate, string startAirport, string endAirport)
    {
        _flightNumber = flightNumber;
        _flightDate = flightDate;
        _startAirport = startAirport;
        _endAirport = endAirport;
        
        Reservations = new List<Reservation>();
    }
    
    public string GetFlightNumber() => _flightNumber;
    public int GetNumberOfPassengers() => _reservedSeats;
    
    public void PrintReservations()
    {
        Console.WriteLine(string.Join("\n", Reservations.Select(r => r.ToString())));
    }
    
    public void AddReservation(Reservation reservation)
    {
        Reservations.Add(reservation);
    }

}
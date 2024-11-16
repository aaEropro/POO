namespace pregatire_test_1___1;

public class LocalFlight : Flight
{
    private int _reservedSeats = 0;
    private int _maxReservedSeats = 6;

    public LocalFlight(string flightNumber, DateOnly flightDate, string startAirport, string endAirport)
        : base(flightNumber, flightDate, startAirport, endAirport)
    {
    }
}
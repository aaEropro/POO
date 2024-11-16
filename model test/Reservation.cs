namespace pregatire_test_1___1;

public class Reservation
{
    private string _email;
    private string _fullName;
    private int _personsPerReservation;
    private int _nrBagaje;
    private string _flightType;

    public Reservation(string fullName, string email, int personsPerReservation, int nrBagaje, string flightType)
    {
        _fullName = fullName;
        _email = email;
        _personsPerReservation = personsPerReservation;
        _nrBagaje = nrBagaje;
        _flightType = flightType;
    }

    /// <summary>
    /// calculates the price of the reservation
    /// </summary>
    public double GetReservationPrice()
    {
        if (_flightType.ToLower() == "local")
        {
            return _personsPerReservation * 100 + _nrBagaje * 25;
        }
        else
        {
            return _personsPerReservation * 500 + _nrBagaje * 50 + 100;
        }
    }
    
    public int GetPersonsPerReservation() => _personsPerReservation;

    public override string ToString()
    {
        return $"{_fullName}, {_personsPerReservation} persons, {GetReservationPrice()} euros";
    }
}
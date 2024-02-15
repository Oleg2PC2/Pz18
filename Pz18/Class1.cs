using System;

public enum TransportType
{
    Trolleybus,
    Bus,
    Train
}

public class PublicTransport
{
    private static int totalTransportCount = 0;

    public string LicensePlate { get; }
    private string assignedDriver;
    public string AssignedDriver
    {
        get { return assignedDriver; }
        set { assignedDriver = string.IsNullOrWhiteSpace(value) ? "не назначен" : value; }
    }
    public TransportType Type { get; }
    public TimeOnly DepartureTime { get; }
    public TimeOnly EndTime { get; }

    // Конструктор с пустым водителем
    public PublicTransport(string licensePlate, TransportType type, TimeOnly departureTime, TimeOnly endTime)
        : this(licensePlate, "", type, departureTime, endTime)
    {
    }

    // Основной конструктор
    public PublicTransport(string licensePlate,
        string assignedDriver,
        TransportType type,
        TimeOnly departureTime,
        TimeOnly endTime)
    {
        if (!IsValidLicensePlate(licensePlate))
        {
            throw new ArgumentException("Неверный формат номерного знака.");
        }

        LicensePlate = licensePlate;
        AssignedDriver = assignedDriver;
        Type = type;
        DepartureTime = departureTime;
        EndTime = endTime;

        totalTransportCount++;
    }

    public bool IsOnRoute()
    {
        TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
        return currentTime >= DepartureTime && currentTime <= EndTime;
    }

    public void PrintInfo()
    {
        string status = IsOnRoute() ? "в рейсе" : "в парке";
        Console.WriteLine($"Госномер: {LicensePlate}");
        Console.WriteLine($"Прикрепленный водитель: {AssignedDriver}");
        Console.WriteLine($"Тип транспорта: {Type}");
        Console.WriteLine($"Состояние: {status}");
    }

    public static void PrintTotalTransportCount()
    {
        Console.WriteLine($"Общее количество транспорта: {totalTransportCount}");
    }

    private bool IsValidLicensePlate(string licensePlate)
    {
        // Проверяем формат госномера "LL NNN LL"
        if (licensePlate.Length != 9)
            return false;

        for (int i = 0; i < licensePlate.Length; i++)
        {
            if (i == 2 || i == 6)
            {
                if (!char.IsDigit(licensePlate[i]))
                    return false;
            }
            else
            {
                if (!char.IsLetter(licensePlate[i]))
                    return false;
            }
        }

        return true;
    }
}

using System;

public enum BuildingType
{
    Residential,
    Commercial
}

public class Building
{
    private static int nextBuildingNumber = 1;
    private int _buildingNumber;
    private int _height;
    private int _floors;
    private int _apartmentsPerFloor;
    private int _apartmentsPerEntrance;
    private BuildingType _buildingType;

    public int BuildingNumber
    {
        get => _buildingNumber;
        private set
        {
            _buildingNumber = value;
        }
    }

    public int Height
    {

        get => _height;
        private set
        {
            _height = value;
        }
    }

    public int Floors
    {
        get => _floors;
        private set
        {
            _floors = value;
        }
    }

    public int ApartmentsPerFloor
    {
        get => _apartmentsPerFloor;
        private set
        {
            _apartmentsPerFloor = value;
        }
    }

    public int ApartmentsPerEntrance
    {
        get => _apartmentsPerEntrance;
        private set
        {
            _apartmentsPerEntrance = value;
        }
    }

    public BuildingType BuildingType
    {
        get => _buildingType;
        private set
        {
            _buildingType = value;
        }
    }

    public Building() : this(0, 0, 0, 0, BuildingType.Residential)
    {
    }

    public Building(int height, int floors, int apartmentsPerFloor, int apartmentsPerEntrance, BuildingType buildingType)
    {
        BuildingNumber = GenerateBuildingNumber();
        Height = height;
        Floors = floors;
        ApartmentsPerFloor = apartmentsPerFloor;
        ApartmentsPerEntrance = apartmentsPerEntrance;
        BuildingType = buildingType;
    }

    private int GenerateBuildingNumber()
    {
        return nextBuildingNumber++;
    }

    public void CalculateTotalApartments()
    {
        int totalApartments = Floors * ApartmentsPerFloor;
        Console.WriteLine("Total apartments: " + totalApartments);
    }

    public void CalculateApartmentsPerEntranceOnFloor(int floor)
    {
        if (floor <= Floors)
        {
            int apartmentsPerEntranceOnFloor = ApartmentsPerEntrance * (floor == 0 ? Floors : (Floors - floor));
            Console.WriteLine("Apartments per entrance on floor " + floor + ": " + apartmentsPerEntranceOnFloor);
        }
        else
        {
            Console.WriteLine("Invalid floor number");
        }
    }

    public void CalculateTotalApartmentsPerEntrance()
    {
        int totalApartmentsPerEntrance = ApartmentsPerEntrance * (Floors - 1);
        Console.WriteLine("Total apartments per entrance: " + totalApartmentsPerEntrance);
    }

    public void PrintBuildingInfo()
    {
        Console.WriteLine("Building Number: " + BuildingNumber);
        Console.WriteLine("Height: " + Height);
        Console.WriteLine("Floors: " + Floors);
        Console.WriteLine("Apartments per floor: " + ApartmentsPerFloor);
        Console.WriteLine("Apartments per entrance: " + ApartmentsPerEntrance);
        Console.WriteLine("Building type: " + BuildingType);
    }
}

class Program
{
    static void Main()
    {
        Building building1 = new Building(10, 5, 2, 3, BuildingType.Residential);
        building1.PrintBuildingInfo();

        building1.CalculateTotalApartments();
        building1.CalculateApartmentsPerEntranceOnFloor(2);
        building1.CalculateTotalApartmentsPerEntrance();
    }
}
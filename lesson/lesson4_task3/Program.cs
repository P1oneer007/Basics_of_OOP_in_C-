using System;
using System.Collections.Generic;

public class Building
{
    public int BuildingId { get; }

    public Building(int buildingId)
    {
        BuildingId = buildingId;
    }
}

public class Creator
{
    private static Dictionary<int, Building> _buildingObjects = new Dictionary<int, Building>();

    private Creator()
    {
        throw new NotImplementedException("Constructor is private. Use factory methods.");
    }

    public static Building CreateBuild(int buildingId)
    {
        Building newBuilding = new Building(buildingId);
        _buildingObjects[buildingId] = newBuilding;
        return newBuilding;
    }

    public static Building CreateBuildWithName(int buildingId, string buildingName)
    {
        Building newBuilding = new Building(buildingId);
        // Additional property assignment example
        // newBuilding.Name = buildingName;
        _buildingObjects[buildingId] = newBuilding;
        return newBuilding;
    }

    public static void RemoveBuilding(int buildingId)
    {
        if (_buildingObjects.ContainsKey(buildingId))
        {
            _buildingObjects.Remove(buildingId);
        }
    }

    // Test example
    public static void Main()
    {
        Building building1 = Creator.CreateBuild(1);
        Building building2 = Creator.CreateBuildWithName(2, "Office Building");

        foreach (var item in _buildingObjects)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }

        Creator.RemoveBuilding(1);

        foreach (var item in _buildingObjects)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
    }
}
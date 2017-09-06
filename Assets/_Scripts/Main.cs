using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    
    public UnitsFactory UnitsFactory;
    public ObstaclesFactory ObstaclesFactory;

    // Use this for initialization
    void Start ()
    {
        ArrayList unitsToCreate = new ArrayList()
        {
            typeof(Marine).ToString(),
            typeof(Battlecruiser).ToString(),
            typeof(Goliath).ToString(),
            typeof(Valkyrie).ToString(),
            typeof(Medik).ToString()
        };

        foreach (string unitType in unitsToCreate)
        {
            if (UnitsFactory.isUnitRegistered(unitType))
            {
                UnitsFactory.createTerranUnit(unitType);
            }
        }
        
        var obst = (CircleObstacle) ObstaclesFactory.createObstacle(typeof(CircleObstacle));
    }
}

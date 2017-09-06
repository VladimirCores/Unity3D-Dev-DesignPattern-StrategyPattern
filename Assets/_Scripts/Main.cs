using UnityEngine;
using System.Collections;
using System;

public class Main : MonoBehaviour {
    
    public UnitsFactory UnitsFactory;
    public ObstaclesFactory ObstaclesFactory;

    // Use this for initialization
    void Start ()
    {
        ArrayList unitsToCreate = new ArrayList()
        {
            UnitsFactory.TerranUnitTypes.Marine,
            UnitsFactory.TerranUnitTypes.Battlecruiser,
            UnitsFactory.TerranUnitTypes.Goliath,
            UnitsFactory.TerranUnitTypes.Medik,
            UnitsFactory.TerranUnitTypes.Valkyrie
        };

        foreach (UnitsFactory.TerranUnitTypes unitType in unitsToCreate)
        {
            if (UnitsFactory.isUnitRegistered(unitType))
                UnitsFactory.createTerranUnit(unitType);
        }
        
        var obst = (CircleObstacle) ObstaclesFactory.createObstacle(typeof(CircleObstacle));
    }
}

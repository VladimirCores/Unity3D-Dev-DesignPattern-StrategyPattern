using UnityEngine;
using System.Collections;
using System;

public class Main : MonoBehaviour {
    
    public UnitsFactory unitsFactory;
    public ObstaclesFactory obstaclesFactory;

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

		// Create only registered unit
		if(unitsFactory) foreach (UnitsFactory.TerranUnitTypes unitType in unitsToCreate)
        {
            if (unitsFactory.isUnitRegistered(unitType))
                unitsFactory.createTerranUnit(unitType);
        }
		else Debug.LogError("> UNIT FACTORY -> DOES NOT SET");

		// Create obstacle instance
		if(obstaclesFactory) {
			var obst = (CircleObstacle) obstaclesFactory.createObstacle(typeof(CircleObstacle));
		} else Debug.LogError("> OBSTACLES FACTORY -> DOES NOT SET");
    }
}

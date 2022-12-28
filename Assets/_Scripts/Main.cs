using UnityEngine;
using System.Collections;
using System;

public class Main : MonoBehaviour {
    
    public UnitsFactory unitsFactory;
    public ObstaclesFactory obstaclesFactory;

    // Use this for initialization
    void Start ()
    {
        // Create only registered units
		InstantiateUnits(new ArrayList(){
			UnitsFactory.TerranUnitTypes.Marine,
			UnitsFactory.TerranUnitTypes.Battlecruiser,
			UnitsFactory.TerranUnitTypes.Goliath,
			UnitsFactory.TerranUnitTypes.Medik,
			UnitsFactory.TerranUnitTypes.Valkyrie
		});

		// Create obstacle instances
		InstantiateObstacles (new ArrayList() {
				ObstaclesFactory.ObstaclesTypes.CircleObstacle
			});
    }

	private void InstantiateUnits(ArrayList unitsToCreate)
	{
		// Create only registered unit
		if (unitsFactory) {
			foreach (UnitsFactory.TerranUnitTypes unitType in unitsToCreate)
				if (unitsFactory.isUnitRegistered(unitType))
					unitsFactory.createTerranUnit(unitType);
		}	
		else Debug.LogError("> UNIT FACTORY -> WAS NOT SET");
	}

	private void InstantiateObstacles(ArrayList obstaclesToCreate)
	{
		// Create only registered unit
		if(obstaclesFactory) {
			foreach (ObstaclesFactory.ObstaclesTypes obstacleType in obstaclesToCreate)
				if (obstaclesFactory.isObstacleRegistered(obstacleType))
					obstaclesFactory.createObstacle(obstacleType);
		}
		else Debug.LogError("> OBSTACLES FACTORY -> WAS NOT SET");
	}
}

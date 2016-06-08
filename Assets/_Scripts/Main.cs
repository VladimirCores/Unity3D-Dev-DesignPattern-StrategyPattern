using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    
    public UnitsFactory UnitsFactory;
    public ObstaclesFactory ObstaclesFactory;

    // Use this for initialization
    void Start () {
        //var marine      = (Marine)UnitsFactory       .createTerranUnit(typeof(Marine));
        //var battlecr    = (Battlecruiser)UnitsFactory.createTerranUnit(typeof(Battlecruiser));
        //var goliath     = (Goliath)UnitsFactory      .createTerranUnit(typeof(Goliath));
        //var valkyrie    = (Valkyrie)UnitsFactory     .createTerranUnit(typeof(Valkyrie));
        var medik       = (Medik)UnitsFactory        .createTerranUnit(typeof(Medik));

        var obst = (CircleObstacle) ObstaclesFactory.createObstacle(typeof(CircleObstacle));
    }
}

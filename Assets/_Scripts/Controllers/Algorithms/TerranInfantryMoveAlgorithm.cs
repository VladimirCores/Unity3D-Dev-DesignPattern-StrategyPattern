using UnityEngine;
using System.Collections;

public class TerranInfantryMoveAlgorithm : IMovable {

    public TerranInfantryMoveAlgorithm()
    {

    }

    public void move(Transform target, Vector2 position)
    {
        target.position = position;
        Debug.Log(string.Format("Terran Infantry : is moving by going"));
    }
}

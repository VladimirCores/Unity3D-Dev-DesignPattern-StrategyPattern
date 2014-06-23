using UnityEngine;
using System.Collections;

public class TerranAviationMoveAlgorithm : IMovable {

    public TerranAviationMoveAlgorithm()
    {

    }

    public void move(Transform target, Vector2 position)
    {
        target.position = position;
        Debug.Log(string.Format("Terran Aviation : is moving by flying"));
    }
}

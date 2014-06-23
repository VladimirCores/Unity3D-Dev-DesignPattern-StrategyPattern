using UnityEngine;
using System.Collections;

public class TerranAviationMoveAlgorithm : MonoBehaviour, IMovable
{   
    public TerranAviationMoveAlgorithm()
    {

    }

    public void move(Vector2 position)
    {
        this.transform.position = position;
        Debug.Log(string.Format("Terran Aviation : is moving by flying"));
    }
}

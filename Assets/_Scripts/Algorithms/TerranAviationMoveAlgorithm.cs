using UnityEngine;
using System.Collections;
using System;

public class TerranAviationMoveAlgorithm : MonoBehaviour, IMovable
{   
    public TerranAviationMoveAlgorithm()
    {

    }

    public void changeSpeed(float value)
    {
        
    }

    public void move(Vector2 position)
    {
        this.transform.position = position;
        Debug.Log(string.Format("Terran Aviation : is moving by flying"));
    }
}

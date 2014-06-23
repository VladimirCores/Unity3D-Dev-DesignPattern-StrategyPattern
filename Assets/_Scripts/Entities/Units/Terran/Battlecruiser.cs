using UnityEngine;
using System.Collections;

public class Battlecruiser : Unit {
	void Start () {
        Name = "Battlecruiser";
        SetMoveAlgorithm(typeof(TerranAviationMoveAlgorithm));
	}

    //override public void move(Vector2 position)
    //{
    //    float distance = Vector2.Distance(transform.position, position);
    //    this.transform.position = position;
    //    Debug.Log(string.Format("Unit > {0} is flying;", Name));
    //}
}

using UnityEngine;
using System.Collections;

public class Valkyrie : Unit {
	void Start () {
        Name = "Valkyrie";
        parameters.moveAlgorithm = Unit.MoveAlgorithm.Null;
        SetMoveAlgorithm(typeof(NullMoveAlgorithm));
    }

    //override public void move(Vector2 position)
    //{
    //    float distance = Vector2.Distance(transform.position, position);
    //    this.transform.position = position;
    //    Debug.Log(string.Format("Unit > {0} is flying;", Name));
    //}
}

using UnityEngine;
using System.Collections;

public class Goliath : Unit {

	void Start () {
        Name = "Goliath";
        parameters.moveAlgorithm = Unit.MoveAlgorithm.Jump;
        SetMoveAlgorithm(typeof(TerranJumpMoveAlgorithm));
	}
}

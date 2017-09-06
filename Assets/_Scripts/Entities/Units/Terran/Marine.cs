using UnityEngine;
using System.Collections;

public class Marine : Unit {
	void Start () {
        Name = "Marine";
        parameters.moveAlgorithm = Unit.MoveAlgorithms.Infantry;
        SetMoveAlgorithm(typeof(TerranInfantryMoveAlgorithm));
	}
}

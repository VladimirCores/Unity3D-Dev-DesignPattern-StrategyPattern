using UnityEngine;
using System.Collections;

public class Medik : Unit {

	// Use this for initialization
	void Start () {
        Name = "Medik";
        SetMoveAlgorithm(typeof(TerranWiggleMoveAlgorithm));
    }
}

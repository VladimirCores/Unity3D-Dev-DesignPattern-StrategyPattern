using UnityEngine;
using System.Collections;

public class Goliath : Unit 
{
	void Start () 
	{
        Name = "Goliath";
        SetMoveAlgorithm(Unit.MoveAlgorithm.Jump);
	}
}

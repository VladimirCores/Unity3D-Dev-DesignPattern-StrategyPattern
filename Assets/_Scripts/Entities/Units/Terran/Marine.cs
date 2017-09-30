using UnityEngine;
using System.Collections;

public class Marine : Unit 
{
	void Start () 
	{
        Name = "Marine";
		SetMoveAlgorithm(Unit.MoveAlgorithm.Infantry);
	}
}

using UnityEngine;
using System.Collections;

public class Battlecruiser : Unit 
{
	void Start () 
	{
			Name = "Battlecruiser";
			SetMoveAlgorithm(Unit.MoveAlgorithm.Aviation);
	}
}

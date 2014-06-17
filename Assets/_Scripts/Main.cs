using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    
    public UnitsFactory Factory;

	// Use this for initialization
	void Start () {
        Marine marine = (Marine)Factory.createTerranUnit(typeof(Marine));
        Battlecruiser battlecruiser = (Battlecruiser)Factory.createTerranUnit(typeof(Battlecruiser));
        Goliath goliath = (Goliath)Factory.createTerranUnit(typeof(Goliath));
        Valkyrie valkyrie = (Valkyrie)Factory.createTerranUnit(typeof(Valkyrie));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

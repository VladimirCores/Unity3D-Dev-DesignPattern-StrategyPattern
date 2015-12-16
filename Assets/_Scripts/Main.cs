using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    
    public UnitsFactory Factory;

	// Use this for initialization
	void Start () {
        var marine = (Marine)Factory.createTerranUnit(typeof(Marine));
        var battlecruiser = (Battlecruiser)Factory.createTerranUnit(typeof(Battlecruiser));
        var goliath = (Goliath)Factory.createTerranUnit(typeof(Goliath));
        var valkyrie = (Valkyrie)Factory.createTerranUnit(typeof(Valkyrie));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

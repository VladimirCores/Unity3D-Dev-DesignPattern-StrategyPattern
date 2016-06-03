using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    
    public UnitsFactory Factory;

	// Use this for initialization
	void Start () {
        var marine      = (Marine)Factory       .createTerranUnit(typeof(Marine));
        var battlecr    = (Battlecruiser)Factory.createTerranUnit(typeof(Battlecruiser));
        var goliath     = (Goliath)Factory      .createTerranUnit(typeof(Goliath));
        var valkyrie    = (Valkyrie)Factory     .createTerranUnit(typeof(Valkyrie));
        var medik       = (Medik)Factory        .createTerranUnit(typeof(Medik));

    }


}

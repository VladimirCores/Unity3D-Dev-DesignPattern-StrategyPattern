using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class UnitsFactory : MonoBehaviour {

    public enum TerranTypes
    {
        Marine,
        Goliath,
        Valkyrie,
        Battlecruiser
    }

    public Transform UnitsContainer;
    public TerranUnit[] Terran;

    private Dictionary<string, GameObject> _terranUnits = new Dictionary<string, GameObject>();

    void Awake()
    {
        TerranUnit unit;
        String unitName;
        for (int i = 0; i < Terran.Length; i++)
        {
            unit = Terran[i];
            unitName = unit.type.ToString();
            _terranUnits.Add(unitName, unit.gameobject);
        }
    }

    public MonoBehaviour createTerranUnit(Type unitype)
    {
        string type = unitype.ToString();
        GameObject result = (GameObject)Instantiate(_terranUnits[type]);
        result.transform.parent = UnitsContainer;
        return (MonoBehaviour)result.GetComponent(type);
    }
    
    [Serializable]
    public class TerranUnit 
    {
        [HideInInspector]
        public String name;
        public TerranTypes type;
        public GameObject gameobject;
    }
}

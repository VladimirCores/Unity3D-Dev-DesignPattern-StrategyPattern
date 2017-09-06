using UnityEngine;
using System;
using System.Collections.Generic;

public class UnitsFactory : MonoBehaviour
{
    [Serializable]
    public class TerranUnit
    {
        [HideInInspector]
        public String name;
        public TerranTypes type;
        public GameObject gameObject;
    }

    public enum TerranTypes
    {
        Marine,
        Goliath,
        Valkyrie,
        Battlecruiser,
        Medik
    }

    public Transform UnitsContainer;
    public TerranUnit[] Terrans;

    private Dictionary<string, GameObject> _terranUnits = new Dictionary<string, GameObject>();

    void Awake()
    {
        TerranUnit unit;
        String unitName;
        for (int i = 0; i < Terrans.Length; i++)
        {
            unit = Terrans[i];
            if(unit != null && unit.gameObject != null)
            {
                unitName = unit.type.ToString();
                _terranUnits.Add(unitName, unit.gameObject);
            }
        }
    }

    public bool isUnitRegistered(string type)
    {
        return _terranUnits.ContainsKey(type);
    }

    public MonoBehaviour createTerranUnit(string type)
    {
        GameObject result = (GameObject)Instantiate(_terranUnits[type]);
        result.transform.parent = UnitsContainer;
        return (MonoBehaviour)result.GetComponent(type);
    }
    
    
}

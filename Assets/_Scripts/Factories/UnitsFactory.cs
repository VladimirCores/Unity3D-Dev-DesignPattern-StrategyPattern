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
        public TerranUnitTypes type;
        public GameObject gameObject;
    }

    public enum TerranUnitTypes
    {
        Marine,
        Goliath,
        Valkyrie,
        Battlecruiser,
        Medik
    }

    public Transform UnitsContainer;
    public TerranUnit[] Terrans;

    private Dictionary<TerranUnitTypes, GameObject> _terranUnits = new Dictionary<TerranUnitTypes, GameObject>();

    void Awake()
    {
        TerranUnit unit;
        TerranUnitTypes unitType;
        for (int i = 0; i < Terrans.Length; i++)
        {
            unit = Terrans[i];
            if(unit != null && unit.gameObject != null)
            {
                unitType = unit.type;
                _terranUnits.Add(unitType, unit.gameObject);
            }
        }
    }

    public bool isUnitRegistered(TerranUnitTypes type)
    {
        return _terranUnits.ContainsKey(type);
    }

    public MonoBehaviour createTerranUnit(TerranUnitTypes type)
    {
        GameObject result = (GameObject)Instantiate(_terranUnits[type]);
        result.transform.parent = UnitsContainer;
        return (MonoBehaviour)result.GetComponent(type.ToString());
    }
    
    
}

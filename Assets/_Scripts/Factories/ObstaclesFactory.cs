using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ObstaclesFactory : MonoBehaviour {

    [Serializable]
    public class Obstacle
    {
        [HideInInspector]
        public String name;
        public ObstaclesTypes type;
        public GameObject gameobject;
    }

    public enum ObstaclesTypes
    {
        CircleObstacle
    }

    public Transform ObstaclesContainer;
    public Obstacle[] Obstacles;

    private Dictionary<string, GameObject> _obstacles = new Dictionary<string, GameObject>();

    void Awake()
    {
        Obstacle obst;
        String unitName;
        for (int i = 0; i < Obstacles.Length; i++)
        {
            obst = Obstacles[i];
            unitName = obst.type.ToString();
            _obstacles.Add(unitName, obst.gameobject);
        }
    }

    public MonoBehaviour createObstacle(Type obstType)
    {
        string type = obstType.ToString();
        GameObject result = (GameObject)Instantiate(_obstacles[type]);
        result.transform.parent = ObstaclesContainer;
        return (MonoBehaviour)result.GetComponent(type);
    }
}

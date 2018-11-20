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
        public GameObject gameObject;
    }

    public enum ObstaclesTypes
    {
        CircleObstacle
    }

    public Transform ObstaclesContainer;
    public Obstacle[] Obstacles;

	private Dictionary<ObstaclesTypes, GameObject>
		_registeredObstacles = new Dictionary<ObstaclesTypes, GameObject>();

    void Awake()
    {
        Obstacle obst;
		ObstaclesTypes obstType;
        for (int i = 0; i < Obstacles.Length; i++)
        {
            obst = Obstacles[i];
			if (obst != null && obst.gameObject != null) {
				obstType = obst.type;
				_registeredObstacles.Add(obstType, obst.gameObject);
			}
        }
    }

	public bool isObstacleRegistered(ObstaclesTypes type)
	{
		return _registeredObstacles.ContainsKey(type);
	}

	public MonoBehaviour createObstacle(ObstaclesTypes type)
    {
		GameObject result = (GameObject)Instantiate(_registeredObstacles[type]);
		result.transform.parent = ObstaclesContainer;
		return (MonoBehaviour)result.GetComponent(type.ToString());
    }
}

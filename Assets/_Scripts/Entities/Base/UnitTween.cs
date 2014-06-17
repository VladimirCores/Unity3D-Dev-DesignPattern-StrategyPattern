using UnityEngine;
using System.Collections;

public class UnitTween : MonoBehaviour
{

    protected string Name = "unit";
    
    public Vector2 position { set { _positionCurrent = value; } }

    private SimpleTweener _tweener;
    
    private Vector2 _positionCurrent;
    private Vector2 _positionTarget;

	// Use this for initialization
	void Start () {
	   _tweener = new SimpleTweener(0, 1, moveTime, SimpleTweener.EaseType.linear);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void move(Vector2 position)
    {
        Debug.Log("");
    }

    public float moveTime
    {
        get { return 10.0f; }
    }
}

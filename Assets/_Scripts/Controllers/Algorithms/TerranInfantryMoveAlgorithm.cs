using UnityEngine;
using System.Collections;
using System.Timers;

public class TerranInfantryMoveAlgorithm : MonoBehaviour, IMovable
{
    private SimpleTweener _tweener;
    private Vector2 _position;

    private float _speed = 0.0f;

    public TerranInfantryMoveAlgorithm(float speed = 10.0f)
    {
        _speed = speed;
    }

    public void move(Vector2 position)
    {
        _position = position;
        _tweener = new SimpleTweener(0, 1, time, SimpleTweener.EaseType.linear);
        Debug.Log(string.Format("Terran Infantry : is moving by going"));
    }
}

using UnityEngine;
using System.Collections;
using System.Timers;
using System;

public class TerranInfantryMoveAlgorithm : MonoBehaviour, IMovable
{
    private SimpleTweener _tweener = new SimpleTweener(0, 1, 0, SimpleTweener.EaseType.linear);
    private Vector2 _moveTo;

    public float _speed = 10.0f;

    public bool isTweenFinished = true;

    private float _currentTweenValue = 0f;
    private float _moveTime = 0f;
    private Vector2 _positionCurrent;
    private Vector2 _positionTarget;
    
    public void move(Vector2 position)
    {
        float distance = Vector3.Distance(transform.position, new Vector3(position.x, position.y));
        float time = distance / _speed;

        Debug.Log(string.Format("Terran Infantry : is moving by going : " + time));
        
        //StopCoroutine(Action());

        _moveTime = Time.time;

        _moveTo = position;
        _positionCurrent = transform.position;
        
        _tweener.Reset();
        _tweener.NewTime(time);
        _currentTweenValue = 0;
        
        isTweenFinished = false;
        
        //StartCoroutine(Action());
    }

    void FixedUpdate()
    {
        if(!isTweenFinished)
        {
            isTweenFinished = _tweener.UpdateTime(Time.fixedDeltaTime, ref _currentTweenValue);
            _positionTarget = Vector2.LerpUnclamped(_positionCurrent, _moveTo, _currentTweenValue);
            transform.position = _positionTarget;
            if(isTweenFinished)
            {
                Camera camera = Camera.main;
                move(new Vector2(UnityEngine.Random.Range(-camera.orthographicSize, camera.orthographicSize - 2) + 2, UnityEngine.Random.Range(-camera.orthographicSize, camera.orthographicSize - 2) + 2));
            }
        }
    }

    public void changeSpeed(float value)
    {
        _speed = value;
        move(_moveTo);
    }

    //private IEnumerator Action()
    //{
    //    while(!isTweenFinished)
    //    {
    //        isTweenFinished = _tweener.UpdateTime(Time.fixedDeltaTime, ref _currentTweenValue);
    //        _positionTarget = Vector2.LerpUnclamped(_positionCurrent, _moveTo, _currentTweenValue);
    //        transform.position = new Vector3(_positionTarget.x, _positionTarget.y);
    //        yield return null;
    //    }
    //    transform.position = _moveTo;
    //    Debug.Log("Move Time : " + (Time.time - _moveTime));
    //}
}

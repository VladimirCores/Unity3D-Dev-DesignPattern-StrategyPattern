using UnityEngine;
using System.Collections;
using System.Timers;

public class TerranInfantryMoveAlgorithm : MonoBehaviour, IMovable
{
    private SimpleTweener _tweener;
    private Vector2 _moveTo;

   [SerializeField] private float _speed = 10.0f;

    public bool isTweenFinished = false;

    private float _currentTweenValue = 0f;
    private Vector2 _positionCurrent;
    private Vector2 _positionTarget;

    public void move(Vector2 position)
    {
        float distance = Vector2.Distance(transform.position, position);
        float time = distance / _speed;

        _moveTo = position;
        _positionCurrent = transform.position;
        
        _tweener = new SimpleTweener(0, 1, time, SimpleTweener.EaseType.linear);
        isTweenFinished = false;
        Debug.Log(string.Format("Terran Infantry : is moving by going : " + time));
        StopCoroutine("Action");
        StartCoroutine(Action());
    }

    void Update()
    {
        //if (_tweener != null)
        //{
        //    isTweenFinished = _tweener.UpdateTime(Time.deltaTime, ref _currentTweenValue);
        //    transform.position = Vector2.LerpUnclamped(_positionCurrent, _moveTo, _currentTweenValue);
            
        //    if (isTweenFinished)
        //    {
        //        _tweener = null;
        //    }
        //}
    }

    private IEnumerator Action()
    {
        while(!isTweenFinished)
        {
            isTweenFinished = _tweener.UpdateTime(Time.deltaTime, ref _currentTweenValue);
            transform.position = Vector2.LerpUnclamped(_positionCurrent, _moveTo, _currentTweenValue);
            yield return null;
        }
    }
}

using UnityEngine;
using System.Collections;

public class TerranJumpMoveAlgorithm : MonoBehaviour, IMovable
{

    public bool continiousJumps = false;

    private SimpleTweener _tweenerJumpOut = new SimpleTweener(1, 0, 1, SimpleTweener.EaseType.easeInBounce);
    private SimpleTweener _tweenerJumpIn = new SimpleTweener(0, 1, 1, SimpleTweener.EaseType.easeInOutBounce);

    private bool isTweenOutFinished = true;
    private bool isTweenInFinished = true;
    private bool isTweenInAvailable = true;

    private float _currentTweenValue;
    private Vector2 _currentScale;

    private Queue _path = new Queue();
    private Vector2 _destinationPosition;

    public void changeSpeed(float value)
    {
        
    }

    public void move(Vector2 position)
    {
        _path.Enqueue(position);
        if (isTweenInAvailable)
        {
            MoveToDestination();
        } 
        
        Debug.Log(string.Format("Terran Infantry : is moving by jumping" ));
    }

    void FixedUpdate()
    {
        if (!isTweenOutFinished)
        {
            isTweenOutFinished = _tweenerJumpOut.UpdateTime(Time.fixedDeltaTime, ref _currentTweenValue);
            transform.localScale = new Vector3(_currentTweenValue, _currentTweenValue, _currentTweenValue);
            if (isTweenOutFinished)
            {
                transform.position = _destinationPosition;
            }
        }
        else if(isTweenOutFinished && !isTweenInFinished)
        {
            isTweenInFinished = _tweenerJumpIn.UpdateTime(Time.fixedDeltaTime, ref _currentTweenValue);
            transform.localScale = new Vector3(_currentTweenValue, _currentTweenValue, _currentTweenValue);
            if(isTweenInFinished)
            {
                isTweenInAvailable = true;
                MoveToDestinationIfPossible();
            }
        }
    }
    
    private void ResetTweeners()
    {
        _tweenerJumpOut.Reset();
        _tweenerJumpIn.Reset();

        isTweenOutFinished = false;
        isTweenInFinished = false;
    }

    private void GetNewDestinationIfAvailable()
    {
        _destinationPosition = (Vector2)_path.Dequeue();
    }

    private void MoveToDestinationIfPossible()
    {
        if (isTweenInAvailable && _path.Count > 0)
        {
            MoveToDestination();
        }
        else
        {
            if(continiousJumps)
            {
                Camera camera = Camera.main;
                move(new Vector2(UnityEngine.Random.Range(-camera.orthographicSize, camera.orthographicSize - 2) + 2, UnityEngine.Random.Range(-camera.orthographicSize, camera.orthographicSize - 2) + 2));
            }
        }
    }

    private void MoveToDestination()
    {
        isTweenInAvailable = false;
        GetNewDestinationIfAvailable();
        ResetTweeners();
    }
 }



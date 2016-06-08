using UnityEngine;
using System.Collections;
using System;

public class TerranWiggleMoveAlgorithm : MonoBehaviour, IMovable {

    private SimpleTweener _tweener = new SimpleTweener(0, 1, 0, SimpleTweener.EaseType.linear);
    private Vector2 _moveTo;

    public float _speed = 10.0f;

    public bool isTweenFinished = true;

    private float _currentTweenValue = 0f;
    private float _moveTime = 0f;
    private Vector2 _positionCurrent;
    private Vector2 _positionTarget;

    private float _distance;
    private float _currentDistance;
    private float _offYValue;
    private float _offXValue;

    private Vector2 _alphaRotationOffset = new Vector2();

    private float alphaRad;
    private float alphaDeg;
    private int _directionX;
    private int _directionY;
    
    public void move(Vector2 position)
    {
        _distance = Vector3.Distance(transform.position, new Vector3(position.x, position.y));
        float time = _distance / _speed;

        float dX = position.x - transform.position.x;
        float dY = position.y - transform.position.y;

        _positionCurrent = transform.position;

        alphaRad = Mathf.Atan2(dY, dX);
        alphaDeg = Mathf.Rad2Deg * alphaRad;
        
        alphaDeg = Math.Abs(alphaDeg) > 90 ? alphaDeg - 180 * (dY > 0 ? -1 : 1) : alphaDeg;

        transform.rotation = Quaternion.Euler(0, 0, alphaDeg);

        Debug.Log(string.Format("Terran Infantry : is moving by wiggling : " + alphaDeg + "; distance: " + _distance));

        //StopCoroutine(Action());

        _moveTime = Time.time;
        _moveTo = position;
        
        _directionX = (-90 < alphaDeg && alphaDeg < 90) ? 1 : -1;
        _directionY = (0 < alphaRad && alphaRad < 180) ? -1 : 1;
        
        _tweener.Reset();
        _tweener.NewTime(time);
        _currentTweenValue = 0;
        
        //transform.rotation = Quaternion.FromToRotation(_positionCurrent, _moveTo);
        
        isTweenFinished = false;

        //StartCoroutine(Action());
    }

    void FixedUpdate()
    {
        if (!isTweenFinished)
        {
            isTweenFinished = _tweener.UpdateTime(Time.fixedDeltaTime, ref _currentTweenValue);

            _currentDistance = _distance * _currentTweenValue;
            _offYValue = Mathf.Sin(_currentTweenValue * (float)Math.PI * 2);

            _positionTarget = new Vector2(
                _positionCurrent.x + _currentDistance * _directionX,
                _positionCurrent.y + _offYValue
            );
            transform.position = _positionTarget;
            transform.RotateAround(_positionCurrent, Vector3.forward, alphaDeg);
            transform.Rotate(Vector3.forward, -alphaDeg);
           
            if (isTweenFinished)
            {
                //Camera camera = Camera.main;
                //move(new Vector2(UnityEngine.Random.Range(-camera.orthographicSize, camera.orthographicSize - 2) + 2, UnityEngine.Random.Range(-camera.orthographicSize, camera.orthographicSize - 2) + 2));
            }
        }
    }

    public Bounds OrthographicBounds(this Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }

    public void changeSpeed(float value)
    {
        _speed = value;
        move(_moveTo);
    }
}

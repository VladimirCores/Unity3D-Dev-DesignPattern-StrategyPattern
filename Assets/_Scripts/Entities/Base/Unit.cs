using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public abstract class Unit : MonoBehaviour
{
    [Serializable]
    public class UnitParams
    {
        public MoveAlgorithms moveAlgorithm;
    }

    public UnitParams parameters;
    public string Name = "unit";

    public enum MoveAlgorithms {
        Null,
        Aviation,
        Infantry,
        Jump,
        Wiggle
    };

    private IMovable _moveAlgorithm = new NullMoveAlgorithm();

    private bool        _selected   = false;
    private Color       _color      = Color.black;
    private int         _zindex     = 0;
    private Material    _material;

    virtual public void move(Vector2 position)
    {
        _moveAlgorithm.move(position);
    }

    void Awake() {
        _material = this.GetComponent<Renderer>().material;
        Camera camera = Camera.main;
        this.transform.position = new Vector2(UnityEngine.Random.Range(-camera.orthographicSize, camera.orthographicSize - 2) + 2, UnityEngine.Random.Range(-camera.orthographicSize, camera.orthographicSize - 2) + 2);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
    }

    public bool isSelected
    {
        set { 
            _selected = value;
            setColor(value ? Color.white : _color);
            setZIndex(value ? -1 : 0);
            if(_selected) Debug.Log("Selected: " + this.GetType().ToString());
        }
        get { return _selected; }
    }

    public void SetMoveAlgorithm(Type value)
    {
        if (_moveAlgorithm != null)
        {
            if (value != _moveAlgorithm.GetType())
                Destroy(gameObject.GetComponent(_moveAlgorithm.GetType()));
            else return;
        }
        _moveAlgorithm = (IMovable)this.gameObject.AddComponent(value);
    }

    public void SetSpeed(float value)
    {
        _moveAlgorithm.changeSpeed(value);
    }

    private void setColor(Color value) {
        if (_material) {
            if (_color == Color.black)
            {
                _color = _material.color;
            }
            _material.color = value;
        }
    }

    private void setZIndex(int value)
    {
        _zindex = value;
        Vector2 tmpPos = this.transform.position;
        this.transform.position = new Vector3(tmpPos.x, tmpPos.y, _zindex);
    }

}

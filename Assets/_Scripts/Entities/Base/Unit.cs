using UnityEngine;
using System.Collections;
using System;

public abstract class Unit : MonoBehaviour {
    
    public string Name = "unit";

    private IMovable _moveAlgorithm = new NullMoveAlgorithm();

    private bool _selected = false;
    private Color _color = Color.black;
    private int _zindex = 0;
    
    virtual public void move(Vector2 position)
    {
        float distance = Vector2.Distance(transform.position, position);
        //this.transform.position = new Vector3(position.x, position.y, _zindex);
        //Debug.Log(string.Format("Unit : {0} > is moving", Name));
        _moveAlgorithm.move(position);
    }

    public bool isSelected
    {
        set { 
            _selected = value;
            setColor(value ? Color.white : _color);
            setZIndex(value ? -1 : 0);
        }
        get { return _selected; }
    }

    public void SetMoveAlgorithm(Type value)
    {
        _moveAlgorithm = (IMovable)this.gameObject.AddComponent(value);
    }

    private void setColor(Color value) {
        if (this.renderer) {
            if (_color == Color.black)
            {
                _color = this.renderer.material.color;
            }
            this.renderer.material.color = value;
        }
    }

    private void setZIndex(int value)
    {
        _zindex = value;
        Vector2 tmpPos = this.transform.position;
        this.transform.position = new Vector3(tmpPos.x, tmpPos.y, _zindex);
    }

}

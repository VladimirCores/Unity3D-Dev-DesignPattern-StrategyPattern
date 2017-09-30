using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public abstract class Unit : MonoBehaviour
{
    static public Type getTypeForMoveAlgorithm(MoveAlgorithm input)
    {
        switch (input)
        {
            default:
            case MoveAlgorithm.Null: 			return typeof(NullMoveAlgorithm);
            case Unit.MoveAlgorithm.Aviation: 	return typeof(TerranAviationMoveAlgorithm);
            case Unit.MoveAlgorithm.Jump: 		return typeof(TerranJumpMoveAlgorithm);
            case Unit.MoveAlgorithm.Infantry: 	return typeof(TerranInfantryMoveAlgorithm);
            case Unit.MoveAlgorithm.Wiggle: 	return typeof(TerranWiggleMoveAlgorithm);
        }
    }


    [Serializable]
    public class UnitParams
    {
        public MoveAlgorithm moveAlgorithm = MoveAlgorithm.Null;
    }

    public UnitParams parameters;
    public string Name = "unit";

    public enum MoveAlgorithm {
        Null,
        Aviation,
        Infantry,
        Jump,
        Wiggle
    };

    private IMovable _moveAlgorithm;

    private bool        _selected   = false;
    private Color       _color      = Color.black;
    private int         _zindex     = 0;
	private MoveAlgorithm _moveAlgorithmEnum;
    private Material    _material;

    virtual public void move(Vector2 position)
    {
		if(_moveAlgorithm != null) _moveAlgorithm.move(position);
    }

    void Awake()
    {
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

	public MoveAlgorithm GetMoveAlgorithm() 
	{
		return _moveAlgorithmEnum;
	}

    public void SetMoveAlgorithm(MoveAlgorithm value)
    {
		Debug.Log("> Unit -> SetMoveAlgorithm: _moveAlgorithm is null = " + (_moveAlgorithm == null));

		Type newMoveAlgorithmType = getTypeForMoveAlgorithm(value);
        
        if (_moveAlgorithm != null)
        {
			Type moveAlgorithmType = _moveAlgorithm.GetType();

			bool IsNewSameAsCurrent = (value.ToString() == moveAlgorithmType.ToString());
			Debug.Log("> Unit -> SetMoveAlgorithm: current move type = " + moveAlgorithmType.ToString());
			Debug.Log("> Unit -> SetMoveAlgorithm: new move type = " + value.ToString());
			Debug.Log("> Unit -> SetMoveAlgorithm: is equals to new = " + IsNewSameAsCurrent);

			if (IsNewSameAsCurrent == false)
			{
				Component moveAlgorithmComponent = this.gameObject.GetComponent(moveAlgorithmType);
				if(moveAlgorithmComponent) {
					_moveAlgorithm = null;
					DestroyImmediate(moveAlgorithmComponent, true);
					moveAlgorithmComponent = null;
				} 
			}
            else return;
        }
		else 
		{
			_moveAlgorithm = (IMovable)this.gameObject.GetComponent(newMoveAlgorithmType);
			if(_moveAlgorithm != null) {
				_moveAlgorithmEnum = value;
				return;
			} else {
				foreach (int v in Enum.GetValues(typeof(MoveAlgorithm)))
				{
					_moveAlgorithmEnum = (MoveAlgorithm) v;
					_moveAlgorithm = (IMovable)this.gameObject.GetComponent(getTypeForMoveAlgorithm(_moveAlgorithmEnum));
					if(_moveAlgorithm != null) return;
				}
			}
		}

		Debug.Log("> Unit -> SetMoveAlgorithm: " + value);
		_moveAlgorithmEnum = value;
		_moveAlgorithm = (IMovable)this.gameObject.AddComponent(newMoveAlgorithmType);
    }

    public void SetSpeed(float value)
    {
		if(_moveAlgorithm != null) _moveAlgorithm.changeSpeed(value);
    }

    private void setColor(Color value) 
	{
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

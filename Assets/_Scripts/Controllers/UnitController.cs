using UnityEngine;
using System.Collections;
using System;

public class UnitController : MonoBehaviour {

    public Unit unit;
    
    private Touch _touch;
    private Vector2 _position;    

    void Update () {
        if (Input.touchCount > 0) {
            AnalizeTouchOnUnit();
        }
        else if(Input.GetMouseButtonUp(0)) {
            AnalizeMouseOnUnit();
            AnalizeMoveUnitToPosition();
        }

        if(unit) 
        {
            if(Input.GetKeyUp(KeyCode.Keypad1))
            unit.SetSpeed(10f);
            else if(Input.GetKeyUp(KeyCode.Keypad2))
            unit.SetSpeed(20f);
        }
	}

    private void AnalizeMoveUnitToPosition()
    {
        if (_position != Vector2.zero) unit.move(_position);
    }

    private void AnalizeTouchOnUnit()
    {
        _touch = Input.GetTouch(0);
        if (_touch.phase == TouchPhase.Began)
        {
            AnalizeHitOnUnit(_touch.position);
        }
    }

    private void AnalizeMouseOnUnit()
    {
        AnalizeHitOnUnit(Input.mousePosition);
    }

    private void AnalizeHitOnUnit(Vector2 position)
    {
        _position = Camera.main.ScreenToWorldPoint(position);
        Collider2D collider = Physics2D.OverlapPoint(_position);
        if (collider)
        {
            unit.isSelected = false;
            unit = collider.transform.GetComponent<Unit>();
            unit.isSelected = true;
            _position = Vector3.zero;
        }
    }
}

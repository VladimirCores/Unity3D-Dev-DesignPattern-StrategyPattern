using UnityEngine;
using System.Collections;
using System;

public class UnitController : MonoBehaviour {

    public Unit selectedUnit;
    
    private Touch _touch;
    private Vector2 _position;    

    void Update () 
	{
        if (Input.touchCount > 0) {
            AnalizeTouchOnUnit();
        }
        else if(Input.GetMouseButtonUp(0)) {
            AnalizeMouseOnUnit();
            AnalizeMoveUnitToPosition();
        }

        if(selectedUnit) 
        {
            if(Input.GetKeyUp(KeyCode.Keypad1))
            	selectedUnit.SetSpeed(10f);
            else if(Input.GetKeyUp(KeyCode.Keypad2))
            	selectedUnit.SetSpeed(20f);
        }
	}

    private void AnalizeMoveUnitToPosition()
    {
        if (_position != Vector2.zero) selectedUnit.move(_position);
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

        if (collider && collider.transform.GetComponent<Unit>())
        {
            selectedUnit.isSelected = false;
            selectedUnit = collider.transform.GetComponent<Unit>();
            selectedUnit.isSelected = true;
            _position = Vector3.zero;
        }
    }
}

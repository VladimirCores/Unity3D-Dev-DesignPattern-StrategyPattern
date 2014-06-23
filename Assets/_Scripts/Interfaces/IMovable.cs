using UnityEngine;
public interface IMovable {
    void move(Vector2 position);
}


public abstract class Vihecle : IMovable
{
    public Vihecle()
    {
        
    }

    public void move(Vector2 move)
    {
        Debug.Log("I'm moving");
    }
}
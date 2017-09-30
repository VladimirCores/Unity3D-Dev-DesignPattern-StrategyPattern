using UnityEngine;
using System.Collections;

public class ExampleInheritance : MonoBehaviour
{
	/*
	void Start () {
	    Car car = new Car();
        Bycicle bycicle = new Bycicle();
        Bird bird = new Bird();
        SpaceShip spaceship = new SpaceShip();

        car.move();
        bycicle.move();
        bird.move();
        spaceship.move();
	}
	*/
}
/*
public abstract class Movable
{
    public Movable()
    {
    }
    public void move() { Debug.Log("I'm moving ..."); }
}
*/
/*
 * Каждый отдельный класс-объект имеет свое собственное поведение
 * Часто это поведение (правило) будет повторятся у схожих объектов (или изменятся незначительно)
 * Также иерархическая структура наследования может стать весьма большой и запутанной
 * Поиск нужного функционала может оказаться затруднительным и занять полезное время
 * Замена функционала или рефакторинг объекта (или одного из его "родителей") может быть длительным и энергозатратным процессом.
 */

/*
public class Car : Movable
{
    public Car()
    {
    }
    //public void move() { Debug.Log("I'm 4 wheel moving"); }
}

public class Bycicle : Movable
{
    public Bycicle()
    {
    }
    //public void move() { Debug.Log("I'm 2 wheel moving"); }
}

public class Bird : Movable
{
    public Bird()
    {
    }
    //public void move() { Debug.Log("I'm fly moving"); }
}

public class SpaceShip : Movable
{
    public SpaceShip()
    {
    }
    //public void move() { Debug.Log("I'm photon engine moving"); }
}

public class Racer : Car
{
    public Racer()
    {
    }
    public void move() { Debug.Log("I'm moving FAST"); }
}

public class Truck : Car
{
    public Truck()
    {
    }
    public void move() { Debug.Log("I'm moving SLOW"); }
}
*/


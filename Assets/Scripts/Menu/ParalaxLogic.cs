using System;

public class ParalaxLogic
{
    private IControllerParallaxView controllerParallaxView;
    private readonly float speed;

    public ParalaxLogic(IControllerParallaxView controllerParallaxView, float speed)
    {
        this.controllerParallaxView = controllerParallaxView;
        this.speed = speed;
    }
    public float MoveParallax(float concurrent, float mltiplicater)
    {
        return concurrent + (speed * mltiplicater * controllerParallaxView.GetDeltaTime());
    }
}
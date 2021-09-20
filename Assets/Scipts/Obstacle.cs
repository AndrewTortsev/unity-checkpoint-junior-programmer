using RunnerApi;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Obstacle : MovableImpl
{
    public override void Update()
    {
        if (!GameManager.INSTANCE.IsGameOver)
        {
            base.Update();
        }
    }
}

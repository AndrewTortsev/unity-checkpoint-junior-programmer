using RunnerApi;
using System;
using UnityEngine;

public abstract class MovableImpl : MonoBehaviour, Movable
{
    public float moveSpeed = 1f;
    public float borderRadius = 100f;
    public Rigidbody Rigidbody { get; private set; }

    public virtual void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void Update()
    {
        
        Move(GetDirection());
        DestroyIfOutOfBorders();
    }

    protected virtual Vector3 GetDirection()
    {
        return Vector3.back;
    }

    private void DestroyIfOutOfBorders()
    {
        if (IsOutByX() || IsOutByY() || IsOutByZ())
        {
            Destroy(gameObject);
        }
    }

    private bool IsOutByY()
    {
        return transform.position.y > borderRadius || transform.position.y < -borderRadius;
    }

    private bool IsOutByZ()
    {
        return transform.position.z > borderRadius || transform.position.z < -borderRadius;
    }

    private bool IsOutByX()
    {
        return transform.position.x > borderRadius || transform.position.x < -borderRadius;
    }

    public void Move(Vector3 direction)
    {
        Rigidbody.transform.Translate(GetMoveSpeed(direction));
    }

    private Vector3 GetMoveSpeed(Vector3 direction)
    {
        return direction * moveSpeed * Time.deltaTime;
    }
}

using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Ground : MovableImpl
{
    private float startZ;
    public BoxCollider Collider { get; private set; }

    public override void Start()
    {
        base.Start();
        Collider = GetComponent<BoxCollider>();
        startZ = transform.position.z;
    }

    public override void Update()
    {
        if (!GameManager.INSTANCE.IsGameOver)
        {
            base.Update();
            MoveByHalf();
        }
    }

    private void MoveByHalf()
    {
        if (startZ - transform.position.z > Collider.size.z / 2f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, startZ);
        }
    }
}

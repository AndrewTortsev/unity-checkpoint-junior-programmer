using RunnerApi;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ControlableImpl : MonoBehaviour, Controlable, Player
{
    public Transform middle;
    public Transform left;
    public Transform right;
    private AudioSource audioPlayer;
    public AudioClip dieClip;
    public AudioClip jumpClip;
    public AudioClip moveClip;
    public float jumpForce = 1f;
    public float moveForce = 1f;
    private float jumpForceMultiplier = 5f;
    private float moveForceMultiplier = 1f;
    private Rigidbody rigidBody;
    [SerializeField]private bool isOnGround;
    private Transform[] targets = new Transform[3];
    [SerializeField] private int targetIndex = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        targetIndex = 1;
        InitializeTargets();
        audioPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        MoveToTarget();
    }

    public void CrouchRoll(Vector3 direction)
    {
        Debug.Log(string.Format("I rolle to {0}", direction));
    }

    public void Jump()
    {
        if (isOnGround)
        {
            isOnGround = false;
            audioPlayer.PlayOneShot(jumpClip);
            rigidBody.AddForce(Vector3.up * GetJumpForce(), ForceMode.Impulse);
        }
    }

    public void Move(Vector3 direction)
    {
        audioPlayer.PlayOneShot(moveClip);
        SetTargetByDirection(direction);
    }

    public void Die()
    {
        audioPlayer.PlayOneShot(dieClip);
        GameManager.INSTANCE.GameOver();
    }

    private void InitializeTargets()
    {
        targets[0] = left;
        targets[1] = middle;
        targets[2] = right;
    }
    private void MoveToTarget()
    {
        Transform target = targets[targetIndex];
        rigidBody.transform.position = Vector3.Lerp(GetCurrentPosition(), GettargetPosition(target), GetMoveSpeed());
    }

    private Vector3 GettargetPosition(Transform target)
    {
        return new Vector3(target.position.x, rigidBody.transform.position.y, target.position.z);
    }

    private Vector3 GetCurrentPosition()
    {
        return rigidBody.transform.position;
    }

    private float GetMoveSpeed()
    {
        return moveForce * moveForceMultiplier * Time.deltaTime;
    }
    private float GetJumpForce()
    {
        return jumpForce * jumpForceMultiplier;
    }
    
    private void SetTargetByDirection(Vector3 direction)
    {
        if (Vector3.left.Equals(direction))
        {
            ChooseLeftTarget();
        }
        if (Vector3.right.Equals(direction))
        {
            ChooseRighttarget();
        }
    }

    private void ChooseRighttarget()
    {
        if (targetIndex < targets.Length - 1)
        {
            targetIndex++;
        }
    }

    private void ChooseLeftTarget()
    {
        if (targetIndex > 0)
        {
            targetIndex--;
        }
    }
}

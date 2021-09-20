using RunnerApi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject controlableOwner;
    public Controlable Controlable { get; private set; }

    private void Start()
    {
        Controlable = controlableOwner.GetComponent<Controlable>();
    }
    private void Update()
    {
        if (!GameManager.INSTANCE.IsGameOver)
        {
            UpdateUserInput();
        }
    }

    private void UpdateUserInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Controlable.Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Controlable.Move(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Controlable.Move(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Controlable.CrouchRoll(Vector3.forward);
        }
    }
}

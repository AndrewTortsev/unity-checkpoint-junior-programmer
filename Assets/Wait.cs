using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    public float waitSeconds = 3;
    void Start()
    {
        SetUseGravityToChieldRigidBodies(false);
        StartCoroutine(WaitUnityLogo());
    }

    private void SetUseGravityToChieldRigidBodies(bool useGravity)
    {
        Rigidbody[] rbs = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody item in rbs)
        {
            item.useGravity = useGravity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitUnityLogo()
    {
        yield return new WaitForSeconds(waitSeconds);
        SetUseGravityToChieldRigidBodies(true);
    }
}

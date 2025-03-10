using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    public float initialLaunchForce = 10f;
    float launchForce;
    Rigidbody rb;
    Vector3 startPos;
    void Start()
    {
        target = GameObject.Find("Cylinder");
        rb = this.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        launchForce = initialLaunchForce;
        Fire();
    }
    void Fire()
    {
        FiringSolution fs = new FiringSolution();
        Nullable<Vector3> aimVector = fs.Calculate(transform.position, target.transform.position, launchForce, Physics.gravity);
        if (aimVector.HasValue)
        {
            rb.isKinematic = false;
            rb.AddForce(aimVector.Value.normalized * launchForce, ForceMode.VelocityChange);
            launchForce = initialLaunchForce;
        }
        else
        {
            launchForce += 5f;
            Fire();
        }
        Debug.Log(aimVector);
    }
}

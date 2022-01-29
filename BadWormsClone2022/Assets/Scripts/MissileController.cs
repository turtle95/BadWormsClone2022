using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;

    private void Start()
    {
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }
}

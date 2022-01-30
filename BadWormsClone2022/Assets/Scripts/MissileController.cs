using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;

    public GameObject hitVFX;
    private bool landed = false;
    public ApplyGravity gravScript;

    public Transform modelRotator;

    private void Start()
    {
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }


    private void Update()
    {
        if (!landed)
            gravScript.Attract();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Planet") && !landed)
            MissileLanded();
    }

    private void MissileLanded()
    {
        InputManager.Instance.SwitchState(InputManager.ControlState.Moving);
        Instantiate(hitVFX, transform.position, Quaternion.identity);
        //call laser
        rb.constraints = RigidbodyConstraints.FreezeAll;
        landed = true;

        LaserJunk.Instance.OnLaserCalled(transform.position);
        Destroy(this.gameObject);
    }
}

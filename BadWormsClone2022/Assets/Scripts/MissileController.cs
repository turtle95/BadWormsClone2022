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


    public AudioSource crash1;
    public AudioSource crash2;
    public AudioSource looper;

    private void Start()
    {
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }


    private void Update()
    {
        if (!landed && !Input.GetMouseButton(0))
            gravScript.Attract();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Planet") && !landed)
            MissileLanded();
    }

    private void MissileLanded()
    {

        crash1.Play();
        crash2.Play();
        looper.Stop();


        Instantiate(hitVFX, transform.position, Quaternion.identity);
        //call laser
        rb.constraints = RigidbodyConstraints.FreezeAll;
        landed = true;

        LaserJunk.Instance.OnLaserCalled(transform.position);

    }
}

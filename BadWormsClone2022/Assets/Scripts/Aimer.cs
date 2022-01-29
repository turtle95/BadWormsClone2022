using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    //take in touch start and current touch, compare the distance and use that to adjust aim power. distance should only be compared in one direction
    //look at the current touch position...maybe copy alberto?
    Vector3 aimTarget;
    Quaternion wantedRotation;
    Vector3 startPos;
    private float power = 0.1f;

    public GameObject missile;


    public void SetStartPos(Vector3 pos)
    {
        startPos = pos;
    }

    public void PowerControl(Vector3 currentPos)
    {
        power = (currentPos - startPos).magnitude;
    }

    public void LaunchMissile()
    {
        //launch with power
        MissileController currentMissile;
        currentMissile = Instantiate(missile, transform.position, transform.rotation).GetComponent<MissileController>();
        currentMissile.speed *= power;
        power = 0.1f;
    }

    public void RotateAimer(Vector3 inputPos)
    {
        inputPos = Camera.main.ScreenToWorldPoint(new Vector3(inputPos.x, inputPos.y, cameraOffset));
        Debug.Log("aim target " + aimTarget);

        aimTarget = new Vector3(transform.position.x, inputPos.y, 0);
        Debug.Log("am target 2 " + aimTarget);
        wantedRotation = Quaternion.LookRotation(inputPos - transform.position);
        //transform.LookAt(inputPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, rotSpeed * Time.deltaTime);
    }
    public float rotSpeed = 18f;
    public float cameraOffset = 5;
}

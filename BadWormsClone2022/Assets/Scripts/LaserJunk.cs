using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserJunk : GenericSingletonClass<LaserJunk>
{

    //find where missile lands call from missile on land
    //move laser
    //tun on laser
    //do raycast into planet
    //do spherecast, grab pieces
    //add explosion force to pieces
    //activate their rigidbodies
    //do damage to player if hit
    //laser from offscreen, at angle outwards from planet from where missile lands

    public float laserSpawnDist = 15f;

    public GameObject laser;
    public LineRenderer laserLine;

    public GameObject exploadVFX;

    private Vector3 hitPos;
    public float exploadScanRadius = 10f;
    public float exloadRad = 100f;
    public float exploadforce = 100f;


    public float laserspawnDelay = 2f;
    public float laserKillDelay = 8f;

    public void OnLaserCalled(Vector3 pos)
    {
        //find angle from center to pos
        hitPos = pos;
        Vector3 dir = (pos - GlobalVariables.Instance.worldCenter).normalized;

        Vector3 laserSpawnPos = dir * laserSpawnDist + GlobalVariables.Instance.worldCenter;


        //spawn thing

        laser.transform.position = laserSpawnPos;

        laser.transform.LookAt(GlobalVariables.Instance.worldCenter);
        StartCoroutine(LaserOnDelay());
        StartCoroutine(LaserKillDelay());
    }

    private IEnumerator LaserOnDelay()
    {
        yield return new WaitForSeconds(laserspawnDelay);
        laser.SetActive(true);
        Instantiate(exploadVFX, hitPos, Quaternion.identity);
        Collider[] hitShit = Physics.OverlapSphere(hitPos, exploadScanRadius);
        foreach(Collider c in hitShit)
        {
            if(c.attachedRigidbody != null)
            {
                c.attachedRigidbody.isKinematic = false;
                c.attachedRigidbody.AddExplosionForce(exploadforce, GlobalVariables.Instance.worldCenter, exloadRad);
            }

            if (c.GetComponent<Enemy>())
            {
                c.GetComponent<Enemy>().KillMe();
            }
        }
    }


    private IEnumerator LaserKillDelay()
    {
        yield return new WaitForSeconds(laserKillDelay);
        laser.SetActive(false);
    }


    public float laserGrowSpeed = -50;
    public float maxZ = 300;
    private void Update()
    {
        if (laser.activeSelf)
        {
            float z = laserLine.GetPosition(1).z;
            if(z < maxZ)
                laserLine.SetPosition(1, new Vector3(0, 0, z + Time.deltaTime * laserGrowSpeed));
        }
    }
}

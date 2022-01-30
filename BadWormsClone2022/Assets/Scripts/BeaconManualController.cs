using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BeaconManualController : MonoBehaviour
{
    private float touchStartYPos = 0f;
    private float moveDir = 0f;
    [SerializeField]
    private LayerMask rayCastMask = default;

    public float rotationSpeed = 1f;
    private bool moving = false;
    private bool noseDive = false;
    public float moveSpeed = 10f;

    public void CheckForPlanet(Vector3 touchPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPos);
        RaycastHit hit;

        moving = true;
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, 5f);


        if (Physics.Raycast(ray, out hit, 1000, rayCastMask)) //touch actually reads, only do this if touch isn't a drag
        {
            if (hit.transform.gameObject.CompareTag("Planet"))
            {
                noseDive = true;

            }
            else
            {
                noseDive = false;
            }
        }
        else
        {
            noseDive = false;
        }


    }

    public void GrabMoveInput(float currentY)
    {
        moveDir = currentY - touchStartYPos;
    }

    private void Update()
    {
        SteerBeacon();
    }

    private void SteerBeacon()
    {
        if (!moving)
            return;
        Debug.Log(GlobalVariables.Instance.currentBeacon.rb.velocity);

        Vector3 targetRot;
        if (noseDive)
        {
            GlobalVariables.Instance.currentBeacon.rb.AddForce((GlobalVariables.Instance.worldCenter - GlobalVariables.Instance.currentBeacon.transform.position).normalized * moveSpeed, ForceMode.VelocityChange);
            //GlobalVariables.Instance.currentBeacon.rb.velocity = (GlobalVariables.Instance.worldCenter - transform.position).normalized * moveSpeed;
            //targetRot = (GlobalVariables.Instance.worldCenter - GlobalVariables.Instance.currentBeacon.modelRotator.position).normalized;
        }
        else
        {
            //GlobalVariables.Instance.currentBeacon.rb.velocity = -(GlobalVariables.Instance.worldCenter - transform.position).normalized * moveSpeed;

            GlobalVariables.Instance.currentBeacon.rb.AddForce(-(GlobalVariables.Instance.worldCenter - GlobalVariables.Instance.currentBeacon.transform.position).normalized * moveSpeed, ForceMode.VelocityChange);
            //targetRot = (GlobalVariables.Instance.currentBeacon.modelRotator.position - GlobalVariables.Instance.worldCenter).normalized;
        }

        GlobalVariables.Instance.currentBeacon.transform.rotation = Quaternion.LookRotation(GlobalVariables.Instance.currentBeacon.rb.velocity);
        //GlobalVariables.Instance.currentBeacon.rb.AddForce(GlobalVariables.Instance.currentBeacon.transform.up);
        //GlobalVariables.Instance.currentBeacon.rb.AddForce(GlobalVariables.Instance.currentBeacon.transform.forward * moveSpeed);

        //Quaternion targetRotation = Quaternion.FromToRotation(GlobalVariables.Instance.currentBeacon.modelRotator.forward, targetRot) * GlobalVariables.Instance.currentBeacon.modelRotator.rotation;
        //GlobalVariables.Instance.currentBeacon.modelRotator.rotation = Quaternion.Slerp(GlobalVariables.Instance.currentBeacon.modelRotator.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void StopMoving()
    {
        moving = false;
    }
}

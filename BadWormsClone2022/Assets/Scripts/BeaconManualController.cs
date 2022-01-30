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

        if (Physics.Raycast(ray, out hit, 1000, rayCastMask)) //touch actually reads, only do this if touch isn't a drag
        {
            if (hit.transform.gameObject.CompareTag("Planet"))
            {
                noseDive = true;
                Debug.Log("hti planet");
            }
            else
                noseDive = false;
        }
        else
            noseDive = false;
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


        Vector3 targetRot;
        if (noseDive)
        {
            targetRot = (GlobalVariables.Instance.worldCenter - GlobalVariables.Instance.currentBeacon.transform.position).normalized;
        }
        else
        {
            targetRot = (GlobalVariables.Instance.currentBeacon.transform.position - GlobalVariables.Instance.worldCenter).normalized;
        }


        GlobalVariables.Instance.currentBeacon.rb.AddForce(GlobalVariables.Instance.currentBeacon.transform.forward * moveSpeed);

        Quaternion targetRotation = Quaternion.FromToRotation(GlobalVariables.Instance.currentBeacon.transform.forward, targetRot) * GlobalVariables.Instance.currentBeacon.transform.rotation;
        GlobalVariables.Instance.currentBeacon.transform.rotation = Quaternion.Slerp(GlobalVariables.Instance.currentBeacon.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void StopMoving()
    {
        moving = false;
    }
}

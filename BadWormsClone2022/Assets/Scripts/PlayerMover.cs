using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public MissileController currentBeacon;

    private float touchStartYPos = 0f;
    private float moveDir = 0f;

    public void AssignTapStart(float yPos)
    {
        touchStartYPos = yPos;
    }

    public void GrabMoveInput(float currentY)
    {
        moveDir = currentY - touchStartYPos;
    }


    private void SteerBeacon()
    {

    }
}

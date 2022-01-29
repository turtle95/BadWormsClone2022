///
///Manages all in game input
///

using UnityEngine;
using UnityEngine.EventSystems;




public class InputManager : MonoBehaviour
{
    private Vector3 touchPos;
    private Vector3 touchPosStart;
    private Vector3 touchPosEnd;


    public Aimer aimerScript;


    private void Update()
    {
        MobileControls();
        PCControls();
    }




    #region Input
    private void MobileControls()
    {
        if (Input.touchCount < 1)
            return;

        if (!EventSystem.current.IsPointerOverGameObject()) //assures you're not currently selecting any UI
        {
            touchPos = Input.GetTouch(0).position;
            aimerScript.PowerControl(touchPos);
            aimerScript.RotateAimer(touchPos);


            if (Input.GetTouch(0).phase == TouchPhase.Began) //touch something
            {
                aimerScript.SetStartPos(touchPos);
            }
        }
        
        if(Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            aimerScript.LaunchMissile();
        }

    }


    private void PCControls()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                aimerScript.SetStartPos(Input.mousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                touchPos = Input.mousePosition;
                aimerScript.PowerControl(touchPos);
                aimerScript.RotateAimer(touchPos);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            aimerScript.LaunchMissile();
        }
    }
    #endregion
}

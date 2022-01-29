///
///
///

using UnityEngine;
using UnityEngine.EventSystems;




public class InputManager : MonoBehaviour
{
    private Vector3 touchPos;
    private Vector3 touchPosStart;
    private Vector3 touchPosEnd;





    void Update()
    {
        MobileControls();
        PCControls();
    }




    #region Input
    private void MobileControls()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && Input.touchCount > 0) //assures you're not currently selecting any UI
        {
            touchPos = Input.GetTouch(0).position;

            if (Input.GetTouch(0).phase == TouchPhase.Began) //touch something
            {
                touchPosStart = touchPos;
            }
        }
        else if(Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchPosEnd = Input.GetTouch(0).position;
        }

    }


    private void PCControls()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchPosStart = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                touchPos = Input.mousePosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            touchPosEnd = Input.mousePosition;
        }
    }
    #endregion
}

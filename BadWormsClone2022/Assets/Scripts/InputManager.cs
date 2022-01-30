///
///Manages all in game input
///

using UnityEngine;
using UnityEngine.EventSystems;




public class InputManager : GenericSingletonClass<InputManager>
{
    private Vector3 touchPos;
    private Vector3 touchPosStart;
    private Vector3 touchPosEnd;


    public Aimer aimerScript;
    public BeaconManualController beaconScript;

    public enum ControlState
    {
        Aiming,
        Flying,
        Moving
    }
    public ControlState currentState = ControlState.Aiming;


    private void Update()
    {
        MobileControls();
        PCControls();
    }

    public void SwitchState(ControlState newState)
    {
        currentState = newState;
    }


    #region Input
    private void MobileControls()
    {
        if (Input.touchCount < 1)
            return;

        if (!EventSystem.current.IsPointerOverGameObject()) //assures you're not currently selecting any UI
        {
            touchPos = Input.GetTouch(0).position;

            switch (currentState)
            {
                case ControlState.Aiming:
                    aimerScript.PowerControl(touchPos);
                    aimerScript.RotateAimer(touchPos);
                    break;
                case ControlState.Flying:
                    break;
                case ControlState.Moving:
                    break;
            }





            if (Input.GetTouch(0).phase == TouchPhase.Began) //touch something
            {
                switch (currentState)
                {
                    case ControlState.Aiming:
                        aimerScript.SetStartPos(touchPos);
                        break;
                    case ControlState.Flying:
                        beaconScript.CheckForPlanet(touchPos);
                        break;
                    case ControlState.Moving:
                        break;
                }
            }
        }
        
        if(Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            switch (currentState)
            {
                case ControlState.Aiming:
                    aimerScript.LaunchMissile();
                    break;
                case ControlState.Flying:
                    beaconScript.StopMoving();
                    break;
                case ControlState.Moving:
                    break;
            }
        }

    }


    private void PCControls()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                aimerScript.SetStartPos(Input.mousePosition);

                switch (currentState)
                {
                    case ControlState.Aiming:
                        aimerScript.SetStartPos(touchPos);
                        break;
                    case ControlState.Flying:
                        beaconScript.CheckForPlanet(Input.mousePosition);
                        break;
                    case ControlState.Moving:
                        break;
                }
            }

            if (Input.GetMouseButton(0))
            {
                touchPos = Input.mousePosition;

                switch (currentState)
                {
                    case ControlState.Aiming:
                        aimerScript.PowerControl(touchPos);
                        aimerScript.RotateAimer(touchPos);
                        break;
                    case ControlState.Flying:
                        break;
                    case ControlState.Moving:
                        break;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {

            switch (currentState)
            {
                case ControlState.Aiming:
                    aimerScript.LaunchMissile();
                    break;
                case ControlState.Flying:
                    beaconScript.StopMoving();
                    break;
                case ControlState.Moving:
                    break;
            }
        }
    }
    #endregion
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR;

public class PhysicsController : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    void Start () {

        // Get reference to controller
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	void Update () {

        var Controller = SteamVR_Controller.Input((int)trackedObj.index);

        GameManager.physManager.DetectKeys(DPadUp(), DPadDown());
	}

    // Returns true if up is pressed on controller D-Pad
    bool DPadUp()
    {
        var Controller = SteamVR_Controller.Input((int)trackedObj.index);

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            var axis = Controller.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

            if (axis.y > 0f)
                return true;
        }

        return false;
    }

    // Returns true if down is pressed on controller D-Pad
    bool DPadDown()
    {
        var Controller = SteamVR_Controller.Input((int)trackedObj.index);

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            var axis = Controller.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

            if (axis.y < 0f)
                return true;
        }

        return false;
    }
}

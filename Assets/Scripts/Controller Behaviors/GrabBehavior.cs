using UnityEngine;
using System.Collections;

public class GrabBehavior : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    private GameObject savedGO;
    private Transform prevParent;

    void Awake()
    {
        // Get reference to controller
        trackedObj = transform.parent.GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    void OnTriggerStay(Collider other)
    {
        // Grab object
        if (other.gameObject.tag == "movable" && device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            prevParent = other.transform.parent;
            savedGO = other.gameObject;
            savedGO.transform.SetParent(transform);
        }

        // Release object
        else if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger) && savedGO != null)
        {
            savedGO.transform.SetParent(prevParent);
            savedGO = null;
        }
    }
}

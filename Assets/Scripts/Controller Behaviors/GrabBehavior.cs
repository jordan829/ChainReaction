using UnityEngine;
using System.Collections;

public class GrabBehavior : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private PhysicsController physController;
    private GameObject savedGO;
    private Transform prevParent;

    void Awake()
    {
        // Get reference to controller
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        // Get reference to physics controller
        physController = GameObject.FindObjectOfType<PhysicsController>();
    }

    void OnTriggerStay(Collider other)
    {
        var Controller = SteamVR_Controller.Input((int)trackedObj.index);

        // Make sure physics are not already initiated (player cannot move objects while paused in the middle of a simulation)
        if (physController.paused && !physController.started)
        {
            // Grab object
            if (other.gameObject.tag == "movable" && Controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                prevParent = other.transform.parent;
                savedGO = other.gameObject;
                savedGO.GetComponent<Rigidbody>().useGravity = false;
                savedGO.transform.SetParent(transform);
            }

            // Release object
            else if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Trigger) && savedGO != null)
            {
                if (savedGO != null)
                {
                    savedGO.GetComponent<Rigidbody>().useGravity = true;
                    savedGO.transform.SetParent(prevParent);
                    savedGO = null;
                }
            }
        }
    }
}

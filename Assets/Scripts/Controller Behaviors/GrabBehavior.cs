using UnityEngine;
using System.Collections;

public class GrabBehavior : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private PhysicsController physController;
    public GameObject savedGO;
    private Transform prevParent;
    public bool grabbing = false;

    void Awake()
    {
        // Get reference to controller
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        // Get reference to physics controller
        physController = FindObjectOfType<PhysicsController>();
    }

    void OnTriggerStay(Collider other)
    {
        var Controller = SteamVR_Controller.Input((int)trackedObj.index);

        // Make sure physics are not already initiated (player cannot move objects while paused in the middle of a simulation)
        if (GameManager.instance.paused && !GameManager.instance.started)
        {
            // Grab object
            if (other.gameObject.tag.Contains("movable") && Controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && !grabbing) //&& savedGO == null)
            {
                Debug.Log("Grabbing");
                grabbing = true;
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                GetComponent<FixedJoint>().connectedBody = other.gameObject.GetComponent<Rigidbody>();

                //prevParent = other.transform.parent;
                //savedGO = other.gameObject;
                //savedGO.GetComponent<Rigidbody>().useGravity = false;
                //savedGO.transform.SetParent(transform);
            }

            // Release object
            else if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Trigger) && grabbing) //&& savedGO != null)
            {
                grabbing = false;
                GetComponent<FixedJoint>().connectedBody = null;
                other.gameObject.GetComponent<Rigidbody>().useGravity = true;

                //savedGO.GetComponent<Rigidbody>().useGravity = true;
                //savedGO.transform.SetParent(prevParent);
                //savedGO = null;
            }
        }
    }
}

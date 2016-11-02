using UnityEngine;
using System.Collections;

public class GrabBehavior : MonoBehaviour {

    public GameObject RotController;
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
        physController = GameObject.FindObjectOfType<PhysicsController>();
    }

    void OnTriggerStay(Collider other)
    {
        var Controller = SteamVR_Controller.Input((int)trackedObj.index);

        // Make sure physics are not already initiated (player cannot move objects while paused in the middle of a simulation)
        if (GameManager.instance.paused && !GameManager.instance.paused)
        {
            // Grab object
            if (other.gameObject.tag.Contains("movable") && Controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                grabbing = true;
                prevParent = other.transform.parent;
                savedGO = other.gameObject;
                savedGO.GetComponent<Rigidbody>().useGravity = false;

                if (!other.gameObject.tag.Contains("limitrot"))
                    savedGO.transform.SetParent(transform);
            }

            // Release object
            else if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Trigger) && savedGO != null)
            {
                if (savedGO != null)
                {
                    grabbing = false;
                    savedGO.GetComponent<Rigidbody>().useGravity = true;

                    if (!other.gameObject.tag.Contains("limitrot"))
                        savedGO.transform.SetParent(prevParent);

                    savedGO = null;
                }
            }

            if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip) && savedGO != null && savedGO.tag.Contains("limitrot"))
            {
                RotController.SetActive(true);
            }

            else if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip) && savedGO != null && savedGO.tag.Contains("limitrot"))
            {
                RotController.SetActive(false);
            }
        }
    }
}

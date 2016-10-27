using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_LaserPointer laserPointer;

    public GameObject player;
    public GameObject destination;
    private GameObject destinationInstance;
    private bool triggerHeld = false;

    void Awake()
    {
        // Get reference to controller
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        laserPointer = GetComponent<SteamVR_LaserPointer>();
    }

    void Update()
    {
        var Controller = SteamVR_Controller.Input((int)trackedObj.index);

        if (triggerHeld)
            ReadyDestination();

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            triggerHeld = true;

        else if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            triggerHeld = false;
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        if (laserPointer.hitFloor)
            player.transform.position = new Vector3(laserPointer.hitPosition.x, player.transform.position.y, laserPointer.hitPosition.z);

        HideDestination();
    }

    void ReadyDestination()
    {
        if (laserPointer.hitFloor)
            ShowDestination();

        else
            HideDestination();
    }

    void ShowDestination()
    {
        if (destinationInstance == null)
            destinationInstance = Instantiate(destination);

        destinationInstance.transform.position = new Vector3(laserPointer.hitPosition.x, -0.075f, laserPointer.hitPosition.z);
    }

    void HideDestination()
    {
        if (destinationInstance != null)
            Destroy(destinationInstance);
    }
}

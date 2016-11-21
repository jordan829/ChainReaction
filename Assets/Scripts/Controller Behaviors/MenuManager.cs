using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    public GameObject Menu;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Update ()
    {
        var Controller = SteamVR_Controller.Input((int)trackedObj.index);

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            if (Menu.activeInHierarchy)
                Menu.SetActive(false);

            else
                Menu.SetActive(true);
        }
    }
}

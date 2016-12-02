using UnityEngine;
using System.Collections;

public class NextLevelCheat : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
	
	void Update () {

        var Controller = SteamVR_Controller.Input((int)trackedObj.index);

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            GameManager.instance.NextLevel();

    }
}

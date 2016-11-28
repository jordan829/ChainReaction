using UnityEngine;
using System.Collections;
using VRTK;

public class GrabManager : MonoBehaviour {

    VRTK_InteractGrab grabScript;
    VRTK_InteractTouch touchScript;

	// Use this for initialization
	void Start () {

        grabScript = GetComponent<VRTK_InteractGrab>();
        touchScript = GetComponent<VRTK_InteractTouch>();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager.instance.started && !GameManager.instance.levelComplete)
        {
            grabScript.enabled = false;
            touchScript.enabled = false;
        }

        else
        {
            grabScript.enabled = true;
            touchScript.enabled = true;
        }
	}
}

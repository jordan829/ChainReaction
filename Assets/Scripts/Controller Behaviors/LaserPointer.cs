using UnityEngine;
using System.Collections;
using Valve.VR;

public class LaserPointer : MonoBehaviour {

    private GameObject hit = null;
    private Color defaultColor;
    private float scaleFactor = 1.1f;
    private SteamVR_TrackedObject trackedObj;

    void Awake()
    {
        trackedObj = transform.parent.GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);

        RaycastHit hitinfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitinfo) && hitinfo.transform.tag == "MenuItem")
        {
            gameObject.GetComponent<LineRenderer>().SetPosition(1, (hitinfo.transform.position - transform.position));
        }

        else
        {
            gameObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(0, 0, 1));
        }
    }
}

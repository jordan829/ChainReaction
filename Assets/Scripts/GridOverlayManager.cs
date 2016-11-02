using UnityEngine;
using System.Collections;

public class GridOverlayManager : MonoBehaviour {

    private GridOverlay go;

    void Awake()
    {
        go = GetComponent<GridOverlay>();
    }
	// Update is called once per frame
	void Update () {
	
        if (go != null)
        {
            if (GameManager.instance.paused && !GameManager.instance.started)
                go.enabled = true;
           else
                go.enabled = false;
        }
	}
}

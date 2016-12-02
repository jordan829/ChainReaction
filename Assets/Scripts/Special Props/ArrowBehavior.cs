using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour {

    private GameObject arrow;
    Vector3 position;

    // Use this for initialization
    void Start () {

        position = transform.position;
        arrow = transform.GetChild(0).gameObject;	
	}
	
	// Update is called once per frame
	void Update () {

        BobAndRotate();

        if (GameManager.instance.started)
            arrow.SetActive(false);

        else
            arrow.SetActive(true);
	}

    void BobAndRotate()
    {
        float bobScale = 5f;
        Vector3 bob = new Vector3(position.x, position.y + (Mathf.Sin(Time.time) / bobScale), position.z);

        float rotScale = 0.5f;
        Vector3 rot = new Vector3(0, 1, 0) * rotScale;


        transform.position = bob;
        transform.Rotate(rot);
    }
}

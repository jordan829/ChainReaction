using UnityEngine;
using System.Collections;

public class SnapBehavior : MonoBehaviour {

    public bool isBeingMoved = false;

    void Awake()
    {
        GetComponent<Rigidbody>().constraints ^= RigidbodyConstraints.FreezeRotationZ;
    }
	void Update () {

        if (GameManager.instance.paused && !GameManager.instance.started)
        {
            float roundedX = Mathf.Round(transform.position.x * 10f) / 10f;
            float roundedZ = Mathf.Round(transform.position.z * 10f) / 10f;

            transform.position = new Vector3(roundedX, transform.position.y, roundedZ);
        }
    }
}

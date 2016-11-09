using UnityEngine;
using System.Collections;

public class BalloonBehavior : MonoBehaviour {

	// Update is called once per frame
	void Update () {

        //Vector3 force = new Vector3(0, 1, 0) * -10f;
        if (!GameManager.instance.paused && GameManager.instance.started)
            GetComponent<Rigidbody>().AddForce(Vector3.up * Physics.gravity.magnitude * 0.5f);
    }
}

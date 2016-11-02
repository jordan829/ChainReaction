using UnityEngine;
using System.Collections;

public class Rotationcontroller : MonoBehaviour {

    public float RotateBy; // TODO: Set specifically for each object
    public Vector3 RotVector;
    private bool triggered = false;
    private GrabBehavior gb;

    void Start()
    {
        gb = GetComponent<GrabBehavior>();
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Controller (right)")
        {
            triggered = true;
            gb.transform.Rotate(RotVector * RotateBy);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Controller (right)")
            triggered = false;
    }
}

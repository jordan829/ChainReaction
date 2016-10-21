using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR;

public class PhysicsController : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    public Transform PropsParent;
    public List<Transform> Balls;
    private Vector3 originalPos;
    private List<GameObject> Props = new List<GameObject>();
    private List<Vector3> Positions = new List<Vector3>();
    private List<Quaternion> Rotations = new List<Quaternion>();
    public bool paused = true;
    public bool started = false;

    void Start () {

        // Get reference to controller
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        Pause();
        GetOriginals();
	}
	
	void Update () {

        var Controller = SteamVR_Controller.Input((int)trackedObj.index);

        if (Input.GetKeyDown(KeyCode.Space) || DPadUp())
        {
            if (paused)
            {
                if (started)
                    UnpausePhysics();
                else
                    Unpause();
            }

            else if (!paused)
                PausePhysics();
        }

        if (Input.GetKeyDown(KeyCode.R) || DPadDown())
            ResetProps();
	}

    // Returns true if up is pressed on controller D-Pad
    bool DPadUp()
    {
        var Controller = SteamVR_Controller.Input((int)trackedObj.index);

        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            var axis = Controller.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

            if (axis.y > 0f)
                return true;
        }

        return false;
    }

    // Returns true if down is pressed on controller D-Pad
    bool DPadDown()
    {
        var Controller = SteamVR_Controller.Input((int)trackedObj.index);

        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            var axis = Controller.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

            if (axis.y < 0f)
                return true;
        }

        return false;
    }

    void GetOriginals()
    {
        foreach (Transform prop in PropsParent)
        {
            Props.Add(prop.gameObject);
            Positions.Add(prop.position);
            Rotations.Add(prop.rotation);
        }
    }

    void ResetProps ()
    {
        UnpausePhysics();
        Pause();
        started = false;

        for (int i = 0; i < Props.Count; i++)
        {
            Props[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            Props[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            Props[i].transform.position = Positions[i];
            Props[i].transform.rotation = Rotations[i];
        }
    }

    // Pauses movement of ball objs only (velocity not conserved)
    public void Pause()
    {
        paused = true;

        foreach (Transform ball in Balls)
        {
            ball.gameObject.GetComponent<Rigidbody>().useGravity = false;
            ball.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // Unpauses movement of ball objs
    void Unpause()
    {
        started = true;
        paused = false;

        foreach (Transform ball in Balls)
        {
            ball.gameObject.GetComponent<Rigidbody>().useGravity = true;
            ball.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    // Stops all physics (velocity is conserved)
    void PausePhysics()
    {
        paused = true;
        Time.timeScale = 0f;
    }

    // Resumes physics
    void UnpausePhysics()
    {
        paused = false;
        Time.timeScale = 1f;
    }
}

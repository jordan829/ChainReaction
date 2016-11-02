using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsManager : MonoBehaviour {

    public Transform PropsParent;
    public List<Transform> Balls;
    private Vector3 originalPos;
    private List<GameObject> Props;
    private List<Vector3> Positions;
    private List<Quaternion> Rotations;

    void Start()
    {
        Pause();
        GetOriginals();
    }

    void Update()
    {
        DetectKeys(Input.GetKeyDown(KeyCode.Space), Input.GetKeyDown(KeyCode.R));
    }

    public void DetectKeys(bool PlayPauseKey, bool ResetKey)
    {
        if (!GameManager.instance.waiting)
        {
            if (PlayPauseKey)
            {
                if (GameManager.instance.paused)
                {
                    if (GameManager.instance.started)
                        UnpausePhysics();
                    else
                    {
                        FreeRotations();
                        GetOriginals();
                        Unpause();
                    }
                }

                else if (!GameManager.instance.paused)
                    PausePhysics();
            }

            if (ResetKey)
            {
                ResetProps();
                FreezeRotations();
            }
        }
    }

    public void Reset()
    {
        ResetProps();
    }

    void GetOriginals()
    {
        Debug.Log("Getting originals");
        Props = new List<GameObject>();
        Positions = new List<Vector3>();
        Rotations = new List<Quaternion>();

        foreach (Transform prop in PropsParent)
        {
            Props.Add(prop.gameObject);
            Positions.Add(prop.position);
            Rotations.Add(prop.rotation);
        }
    }

    void ResetProps()
    {
        UnpausePhysics();
        Pause();
        GameManager.instance.started = false;

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
        GameManager.instance.paused = true;

        foreach (Transform ball in Balls)
        {
            ball.gameObject.GetComponent<Rigidbody>().useGravity = false;
            ball.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // Unpauses movement of ball objs
    public void Unpause()
    {
        GameManager.instance.started = true;
        GameManager.instance.paused = false;

        foreach (Transform ball in Balls)
        {
            ball.gameObject.GetComponent<Rigidbody>().useGravity = true;
            ball.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    // Stops all physics (velocity is conserved)
    public void PausePhysics()
    {
        GameManager.instance.paused = true;
        Time.timeScale = 0f;
    }

    // Resumes physics
    public void UnpausePhysics()
    {
        GameManager.instance.paused = false;
        Time.timeScale = 1f;
    }

    public void FreezeRotations()
    {
        for (int i = 0; i < Props.Count; i++)
            Props[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
    }

    public void FreeRotations()
    {
        for (int i = 0; i < Props.Count; i++)
            Props[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}

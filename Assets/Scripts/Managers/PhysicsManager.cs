﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsManager : MonoBehaviour {

    public Transform PropsParent;
    public List<Transform> Balls;
    private Vector3 originalPos;
    private List<GameObject> Props = new List<GameObject>();
    private List<Vector3> Positions = new List<Vector3>();
    private List<Quaternion> Rotations = new List<Quaternion>();
    public bool paused = true;
    public bool started = false;

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
        if (PlayPauseKey)
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

        if (ResetKey)
            ResetProps();
    }

    public void PlayPause()
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

    public void Reset()
    {
        ResetProps();
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

    void ResetProps()
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

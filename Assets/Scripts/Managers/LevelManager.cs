using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    private Vector3 originalPos;
    private List<GameObject> Props;
    private List<Vector3> Positions;
    private List<Quaternion> Rotations;
    public GameObject curLevel;

    public void LoadNewLevel()
    {
        Debug.Log("meow");
        Destroy(curLevel);

        GameManager.instance.starsAchieved = 0;

        curLevel = GameObject.Instantiate(GameManager.instance.Levels[GameManager.instance.currentLevel].Props);

        FindBalls();
        Pause();
        GetOriginals();
        FreezeRotations();
        Reset();
    }

    void Update()
    {
        DetectKeys(Input.GetKeyDown(KeyCode.Space), Input.GetKeyDown(KeyCode.R));
    }

    public void DetectKeys(bool PlayPauseKey, bool ResetKey)
    {
        //if (!GameManager.instance.waiting)
       // {
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
            Reset();
        }
        //}
    }

    public void Reset()
    {
        GameManager.instance.starsAchieved = 0;
        ResetProps();
    }

    public void GetOriginals()
    {
        Debug.Log("Getting originals");
        Props = new List<GameObject>();
        Positions = new List<Vector3>();
        Rotations = new List<Quaternion>();

        foreach (Transform prop in curLevel.transform) //GameManager.instance.Levels[GameManager.instance.currentLevel].Props.transform)
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
            if (Props[i].GetComponent<Rigidbody>())
            {
                Props[i].gameObject.SetActive(true);
                Props[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                Props[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                Props[i].transform.position = Positions[i];
                Props[i].transform.rotation = Rotations[i];
            }
        }

        FreezeRotations();
    }

    // Pauses movement of ball objs only (velocity not conserved)
    public void Pause()
    {
        GameManager.instance.paused = true;

        foreach (GameObject ball in GameManager.instance.Levels[GameManager.instance.currentLevel].Balls)
        {
            ball.GetComponent<Rigidbody>().useGravity = false;
            ball.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // Unpauses movement of ball objs
    public void Unpause()
    {
        GameManager.instance.started = true;
        GameManager.instance.paused = false;

        foreach (GameObject ball in GameManager.instance.Levels[GameManager.instance.currentLevel].Balls)
        {
            ball.GetComponent<Rigidbody>().useGravity = true;
            ball.GetComponent<Rigidbody>().isKinematic = false;
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
        Debug.Log("Freeze rotations");
        for (int i = 0; i < Props.Count; i++)
        {
            if (Props[i].GetComponent<Rigidbody>() && (Props[i].name.Contains("Book") || Props[i].name.Contains("Race")))
                Props[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            if (Props[i].gameObject.name.Contains("Balloon"))
                Props[i].GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void FreeRotations()
    {
        Debug.Log("Free rotations");
        for (int i = 0; i < Props.Count; i++)
        {
            if (Props[i].GetComponent<Rigidbody>())
                Props[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            if (Props[i].gameObject.name.Contains("Balloon"))
                Props[i].GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public void FindBalls()
    {
        GameManager.instance.Levels[GameManager.instance.currentLevel].Balls = new List<GameObject>();

        foreach (Transform prop in curLevel.transform)
        {
            if (prop.name.Contains("Ball") && !prop.name.Contains("Balloon"))
                GameManager.instance.Levels[GameManager.instance.currentLevel].Balls.Add(prop.gameObject);
        }
    }
}


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsController : MonoBehaviour {

    public GameObject ParentGO;
    private Vector3 originalPos;
    private List<GameObject> Props = new List<GameObject>();
    private List<Vector3> Positions = new List<Vector3>();
    private List<Quaternion> Rotations = new List<Quaternion>();

    void Start () {

        Time.timeScale = 0.0f;
        GetOriginals();
	}
	
	void Update () {
	    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 0.0f)
                Time.timeScale = 1.0f;

            else if (Time.timeScale == 1.0f)
                Time.timeScale = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.R))
            ResetProps();
	}

    void GetOriginals()
    {
        Debug.Log("Getting originals");
        foreach (Transform prop in ParentGO.transform)
        {
            Props.Add(prop.gameObject);
            Positions.Add(prop.position);
            Rotations.Add(prop.rotation);
        }

        Debug.Log("Stored " + Props.Count + " Props");
    }

    void ResetProps ()
    {
        Debug.Log("Resetting " + Props.Count + " Props");
        Time.timeScale = 0.0f;

        for (int i = 0; i < Props.Count; i++)
        {
            Props[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            Props[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            Props[i].transform.position = Positions[i];
            Props[i].transform.rotation = Rotations[i];
        }
    }
}

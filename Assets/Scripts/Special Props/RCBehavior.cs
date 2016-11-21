using UnityEngine;
using System.Collections;

public class RCBehavior : MonoBehaviour {

    private bool hit = false;
    private bool halt = false;
    public float acceleration;
    public float maxSpeed;
    private float speed;
    private LineRenderer line;

    void Start()
    {
        speed = acceleration;
        line = GetComponent<LineRenderer>();
    }

	void Update () {

        if (!GameManager.instance.started)
        {
            hit = false;
            halt = false;
            speed = 0f;
        }

        if (hit && !halt)
            Accelerate();

        if (GameManager.instance.started)
            line.enabled = false;

        else
            line.enabled = true;
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Contains("trigger"))
            hit = true;

        else if (other.gameObject.tag == "wall")
            halt = true;
    }

    void Accelerate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (acceleration < maxSpeed)
            speed += acceleration;
    }
}

using UnityEngine;
using System.Collections;

public class RCBehavior : MonoBehaviour {

    private bool hit = false;
    private bool halt = false;
    public float acceleration;
    public float maxSpeed;
    private float speed;

    void Start()
    {
        speed = acceleration;
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

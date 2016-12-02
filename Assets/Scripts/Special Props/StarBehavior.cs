using UnityEngine;
using System.Collections;

public class StarBehavior : MonoBehaviour {

    Vector3 position;

    void Start()
    {
        position = transform.position;
    }

	void Update()
    {
        BobAndRotate();
    }
	
    void OnTriggerEnter(Collider other)
    {
        if (!GameManager.instance.started)
        {
            if (other.gameObject.tag.Contains("prop"))
                Destroy(other.gameObject);
        }

        else
        {
            if (other.gameObject.tag.Contains("trigger"))
            {
                GameManager.instance.starsAchieved++;
                gameObject.SetActive(false);
            }
        }
    }

    void BobAndRotate()
    {
        float bobScale = 20f;
        Vector3 bob = new Vector3(position.x, position.y + (Mathf.Sin(Time.time) / bobScale), position.z);

        float rotScale = 0.5f;
        Vector3 rot = new Vector3(0, 1, 0) * rotScale;


        transform.position = bob;
        transform.Rotate(rot);
    }
}

using UnityEngine;
using System.Collections;

public class GoalBehavior : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("goal"))
        {
            GetComponent<Renderer>().material.color = Color.green;
            other.gameObject.SetActive(false);
            GameManager.instance.LevelComplete();
        }
    }
}

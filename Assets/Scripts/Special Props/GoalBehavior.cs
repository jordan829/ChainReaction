using UnityEngine;
using System.Collections;

public class GoalBehavior : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("goal"))
            GameManager.instance.LevelComplete();
    }
}

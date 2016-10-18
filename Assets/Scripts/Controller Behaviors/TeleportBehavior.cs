using UnityEngine;
using System;
using System.Collections;

public class TeleportBehavior : MonoBehaviour {

	private GameObject player;
	public bool isDelayed = false;
	public bool isOnGround = false;

	void OnCollisionEnter(Collision other) {

		if (!isDelayed) 
			if (OnTopOf(other))
				Teleport ();
	}

	// For "Delayed" teleporter. Make sure the teleporter is on top of an object
	void OnCollisionStay (Collision other) {

		isOnGround = OnTopOf(other);
	}

	void OnCollisionExit (Collision other) {
		
		isOnGround = false;
	}

	void Update() {

		// Delete if tele falls below certain threshold. Might want to change to calculate lifetime
		if (transform.position.y < -30.0f)
			Destroy (gameObject);
	}

	public void Teleport () {
		
		player = GameObject.Find ("FPSController");
		player.transform.position = transform.position;
		Destroy (gameObject);
	}

	private bool OnTopOf (Collision other) {

		// Make sure we only teleport ontop of an object. Ignore collisions with sides
		Vector3 normal = other.contacts [0].normal;
		if (normal.y > 0)
			return true;
		else
			return false;
	}
}

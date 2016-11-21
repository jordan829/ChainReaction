using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {

    public GameObject play;
    public GameObject pause;

    void Update () {

        if (GameManager.instance.paused)
        {
            play.SetActive(true);
            pause.SetActive(false);
        }

        else
        {
            play.SetActive(false);
            pause.SetActive(true);
        }
	}
}

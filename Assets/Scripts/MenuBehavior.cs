using UnityEngine;
using System.Collections;

public class MenuBehavior : MonoBehaviour {

	void Awake()
    {
        GameObject star1 = transform.FindChild("Star1").gameObject;
        GameObject star2 = transform.FindChild("Star2").gameObject;
        GameObject star3 = transform.FindChild("Star3").gameObject;

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        if (GameManager.instance.starsAchieved >= 1)
            star1.SetActive(true);

        if (GameManager.instance.starsAchieved >= 2)
            star2.SetActive(true);

        if (GameManager.instance.starsAchieved == 3)
            star3.SetActive(true);
    }
}

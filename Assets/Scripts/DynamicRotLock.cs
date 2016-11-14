using UnityEngine;
using System.Collections;

public class DynamicRotLock : MonoBehaviour {

    void LateUpdate()
    {
        if (transform.parent && transform.parent.gameObject.name.Contains("Controller"))
            transform.eulerAngles = new Vector3(0, transform.parent.transform.eulerAngles.y, 0);
    }
}

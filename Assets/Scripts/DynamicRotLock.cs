using UnityEngine;
using System.Collections;

public class DynamicRotLock : MonoBehaviour {

    Quaternion rotation;

    void OnEnable()
    {
        rotation = transform.parent.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}

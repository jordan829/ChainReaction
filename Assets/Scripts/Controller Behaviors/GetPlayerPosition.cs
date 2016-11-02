using UnityEngine;
using System.Collections;

public class GetPlayerPosition : MonoBehaviour {

    private Transform PlayerPosition;

    void Awake()
    {
        PlayerPosition = GameObject.Find("Camera (head)").transform;
    }

    void Update()
    {
        transform.position = new Vector3(PlayerPosition.position.x, 0f, PlayerPosition.position.y);
    }
}

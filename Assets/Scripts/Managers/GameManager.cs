using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour{

    public static GameManager instance;
    public static PhysicsManager physManager;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);

        else
            instance = this;

        physManager = GetComponent<PhysicsManager>();
    }
}

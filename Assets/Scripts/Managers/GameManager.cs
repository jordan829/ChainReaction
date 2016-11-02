using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour{

    public static GameManager instance;
    public static PhysicsManager physManager;

    public bool levelComplete = false;
    public bool paused = true;
    public bool started = false;
    public bool waiting = false;
    public float waitTime = 3f;
    private float pauseEndTime = 0f;
    public int currentLevel = 0;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);

        else
            instance = this;

        physManager = GetComponent<PhysicsManager>();
    }

    void Update()
    {
        if (levelComplete)
            NextLevel();
    }

    public void LevelComplete()
    {
        Debug.Log("LEVEL COMPLETE");
        physManager.PausePhysics();
        levelComplete = true;
        pauseEndTime = Time.realtimeSinceStartup + waitTime;
       
    }

    public void NextLevel()
    {
        waiting = true;

        Debug.Log("Waiting: " + (pauseEndTime - Time.realtimeSinceStartup));

        if (Time.realtimeSinceStartup >= pauseEndTime)
        {
            waiting = false;

            //////////////////////////////
            physManager.Reset(); // TODO: Go to next level or reset completely
            //////////////////////////////
            levelComplete = false;
        }
    }
}

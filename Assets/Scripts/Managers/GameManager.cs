using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour{

    public static GameManager instance;
    public static PhysicsManager physManager;

    public List<Level> Levels;

    [System.Serializable]
    public class Level
    {
        public GameObject Props;
        public GameObject[] Balls;
    }
    
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

        Levels[currentLevel].Props.SetActive(true);

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

            // Reset current level props and set inactive before loading next level
            physManager.Reset();
            Levels[currentLevel].Props.SetActive(false);

            // Increment level counter and load next set of props
            currentLevel++;
            Levels[currentLevel].Props.SetActive(true);

            // Tell physManager a new level has been loaded so new obj originals can be stored
            physManager.LoadNewLevel(); 

            levelComplete = false;
        }
    }
}

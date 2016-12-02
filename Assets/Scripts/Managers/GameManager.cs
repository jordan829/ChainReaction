using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour{

    public static GameManager instance;
    public static LevelManager LevelMan;
    

    public List<Level> Levels;

    [System.Serializable]
    public class Level
    {
        public GameObject Props;
        public List<GameObject> Balls;
    }

    public GameObject Menu;
    private GameObject MenuInstance;
    public GameObject MainMenu;
    private GameObject MainMenuInstance;

    public bool levelComplete = true;
    public bool paused = true;
    public bool started = false;
    //public bool waiting = false;
    //public float waitTime = 3f;
    //private float pauseEndTime = 0f;
    public int currentLevel = -1;
    public int starsAchieved = 0;

    void Awake()
    {
        currentLevel = -1;
        starsAchieved = 0;
        MainMenuInstance = GameObject.Instantiate(MainMenu);

        if (instance != null)
            Destroy(gameObject);

        else
            instance = this;

        LevelMan = GetComponent<LevelManager>();
        //LevelMan.LoadNewLevel();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            NextLevel();
    }

    public void LevelComplete()
    {
        Debug.Log("LEVEL COMPLETE");
        levelComplete = true;
        MenuInstance = GameObject.Instantiate(Menu);
    }

    public void NextLevel()
    {
        Destroy(MenuInstance);
        Destroy(MainMenuInstance);
        currentLevel++;

        if (currentLevel >= Levels.Capacity)
        {
            currentLevel = -1;
            Destroy(LevelMan.curLevel);
            MainMenuInstance = GameObject.Instantiate(MainMenu);
        }

        else
        {
            LevelMan.LoadNewLevel();
            levelComplete = false;
        }
    }
}

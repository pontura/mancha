using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Levels : MonoBehaviour {

    public GameObject board;

    public Level[] levels;
    private Level currentLevel;
    public int currentLevelScore = 1000;
    public int levelId = 1;
    private ManchasManager manchasManager;

    void Start()
    {
        manchasManager = GetComponent<ManchasManager>();
        Events.OnLevelComplete += OnLevelComplete;
    }
    void OnDestroy()
    {
        Events.OnLevelComplete -= OnLevelComplete;
    }
    public void Init()
    {
        StartLevel();
    }
    void OnLevelComplete()
    {
        print("OnLevelComplete");

        if(levels.Length > levelId)
            levelId++;
        
        currentLevel = levels[levelId - 1];
        StartLevel();

        Events.OnSetTotalManchas(currentLevel.totalManchas);
        
    }
    void StartLevel()
    {
        currentLevel = levels[levelId-1];
        Transform[] transforms = currentLevel.GetComponentsInChildren<Transform>(true);
        
        foreach (Transform tr in transforms)
        {
            Mancha mancha = tr.GetComponent<Mancha>();
            ManchaZone manchaZone = tr.GetComponent<ManchaZone>();
            Pill pill = tr.GetComponent<Pill>();
            if (mancha) 
            {
                Events.OnAddMancha(mancha);
            } else  if (pill) 
            {
                Events.OnAddPill(pill);
            }
            else if (manchaZone)
            {
                Events.OnAddManchaZone(manchaZone);
            }
        }
        
        currentLevelScore = 6;
    }
   
}

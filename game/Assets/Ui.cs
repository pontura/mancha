using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Ui : MonoBehaviour {

    [SerializeField]
    Text scoreTXT;
    [SerializeField]
    Text timeTXT;
    [SerializeField]
    Text levelTXT;
    public Image bar;

    public float score = 0;
    private double currentScore = 0;
    private Levels levels;

	void Start () {
        Events.OnPillCarried += OnPillCarried;
        Events.OnHeroAttacked += OnHeroAttacked;
        Events.OnLevelComplete += OnLevelComplete;
        levels = Game.I.GetComponent<Levels>();
	}
    void OnDestroy()
    {
        Events.OnPillCarried -= OnPillCarried;
        Events.OnHeroAttacked -= OnHeroAttacked;
        Events.OnLevelComplete -= OnLevelComplete;
    }
    void OnHeroAttacked()
    {
        score -= 0.5f;
        if (score < 0)
            score = 0;
    }
    void OnPillCarried()
    {
        score += 1;
    }
    void OnLevelComplete()
    {
        levelTXT.text = "Level: " + (levels.levelId+1).ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (currentScore < score)
            currentScore = System.Math.Round(currentScore + 0.05f, 2);
        else if (currentScore > score)
            currentScore = System.Math.Round(currentScore - 0.05f, 2);
        else
        {
            if (currentScore >= levels.currentLevelScore)
            {
                currentScore = 0;
                score = 0;
                Events.OnLevelComplete();
                scoreTXT.text = currentScore.ToString();
            }
        }
        if (currentScore != levels.currentLevelScore)
        {
            if (currentScore > score) bar.color = Color.red;
            else if (currentScore <= score)  bar.color = Color.white;
            scoreTXT.text = currentScore.ToString();
            bar.fillAmount = ((float)currentScore / levels.currentLevelScore);
        }

	}
}

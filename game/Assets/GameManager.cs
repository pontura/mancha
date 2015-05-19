using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Mancha mancha;
    public Pill pill;

    void Start()
    {
        Events.OnLevelComplete += OnLevelComplete;
    }
    void OnDestroy()
    {
        Events.OnLevelComplete -= OnLevelComplete;
    }
    void OnLevelComplete()
    {
       //
    }
}

using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    static Game mInstance = null;
    [HideInInspector]
    public CharactersManager charactersManager;
   [HideInInspector]
    public Levels levels;

    public static Game I
    {
        get
        {
            return mInstance;
        }
    }
    void Awake()
    {
        mInstance = this;
    }
    void Start()
    {
        GetComponent<ManchasManager>().Init();
        GetComponent<PillsManager>().Init();
        GetComponent<ManchaZoneManager>().Init();

        levels = GetComponent<Levels>();
        levels.Init();

        charactersManager = GetComponent<CharactersManager>();
        charactersManager.Init();

        
    }
}

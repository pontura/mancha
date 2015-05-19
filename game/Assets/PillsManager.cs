using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PillsManager : MonoBehaviour {

    [SerializeField]
    Mancha mancha;
    CharactersManager charactersManager;

    public GameObject container;
    public List<Pill> pills;
    private Pill currentPill;
    private int currentPillId = 0;
    int timePill = 0;
    int timeToPill = 150;

    public void Init()
    {
        charactersManager = GetComponent<CharactersManager>();
        Events.OnAddPill += OnAddPill;
        Events.OnPillCarried += OnPillCarried;

        Pill[] pillsInScene = container.GetComponentsInChildren<Pill>();
        foreach (Pill pill in pillsInScene)
            pills.Add(pill);
    }
    void OnDestroy()
    {
        Events.OnAddPill -= OnAddPill;
        Events.OnPillCarried -= OnPillCarried;
    }
    void Update()
    {
        timePill++;
        if (timePill > timeToPill) ActivePill();
    }
    void OnAddPill(Pill _pill)
    {
        Pill pill = Instantiate(_pill) as Pill;
        pill.transform.SetParent(container.transform);
        pill.transform.localScale = pill.transform.localScale;
        pill.transform.localPosition = pill.transform.localPosition;
        pills.Add(pill);
        pill.gameObject.SetActive(false);
        //ActivePill();
    }
    void OnPillCarried()
    {
        
        ActivePill();
    }
    void ActivePill()
    {
        if (currentPillId == pills.Count)
            currentPillId = 0;

        timePill = 0;
        currentPill = pills[currentPillId];
        currentPill.gameObject.SetActive(true);
        currentPillId++;
    }
    
}

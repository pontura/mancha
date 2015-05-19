using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManchasManager : MonoBehaviour {

    [SerializeField] Mancha mancha;
    CharactersManager charactersManager;
    public List<Mancha> manchas;

    public GameObject container;

    public void Init()
    {
        charactersManager = GetComponent<CharactersManager>();

        Events.OnAddMancha += OnAddMancha;
        Events.OnSetTotalManchas += OnSetTotalManchas;

        Mancha[] manchasInScene = container.GetComponentsInChildren<Mancha>();
        foreach (Mancha mancha in manchasInScene)
            manchas.Add(mancha);

    }
    void OnDestroy()
    {
        Events.OnAddMancha -= OnAddMancha;
        Events.OnSetTotalManchas -= OnSetTotalManchas;
    }
    void OnAddMancha(Mancha _manchas)
    {
        Mancha newMancha = Instantiate(_manchas) as Mancha;
        newMancha.transform.SetParent(container.transform);
        newMancha.transform.localScale = newMancha.transform.localScale;
        newMancha.transform.localPosition = newMancha.transform.localPosition;
        manchas.Add(newMancha);
    }
    public void OnSetTotalManchas(int total)
    {
        if (total>GetTotalManchas())
        {
            for (int a = 0; a < total - GetTotalManchas(); a++)
            {
                OnAddMancha( manchas[0] );
            }
        }
        else if (total < GetTotalManchas())
        {
            for (int a = 0; a > total - GetTotalManchas(); a--)
            {
                Mancha manchaToRemove = manchas[0];
                manchas.Remove(manchaToRemove);
                GameObject.Destroy(manchaToRemove.gameObject);
            }
        }
    }
    public int GetTotalManchas()
    {
        return manchas.Count;
    }
	void Update () {
        if (Game.I.levels.levelId == 1) return;
        Hero[] heroes = charactersManager.GetHeroes();
        foreach (Mancha mancha in manchas)
        {
            foreach (Hero hero in heroes)
            {
                if (hero.state == Hero.states.SAFE)
                {
                    mancha.OnManchaChangeBehavior(Mancha.behaviors.PULULA);
                }
                else
                {
                    mancha.OnManchaChangeBehavior(Mancha.behaviors.FOLLOW);
                }
            }
        }
	}
}

using UnityEngine;
using System.Collections;

public class ManchaZoneManager : MonoBehaviour {

    public GameObject container;

    public void Init()
    {
        Events.OnAddManchaZone += OnAddManchaZone;

    }
    void OnDestroy()
    {
        Events.OnAddManchaZone -= OnAddManchaZone;
    }
    void OnAddManchaZone(ManchaZone _manchas)
    {
        ManchaZone newMancha = Instantiate(_manchas) as ManchaZone;
        newMancha.transform.SetParent(container.transform);
        newMancha.transform.localScale = newMancha.transform.localScale;
        newMancha.transform.localPosition = newMancha.transform.localPosition;
        //manchas.Add(newMancha);
    }

}

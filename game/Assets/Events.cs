using UnityEngine;
using System.Collections;

public static class Events {

    public static System.Action OnLevelComplete = delegate { };
    public static System.Action OnPillCarried = delegate { };
   // public static System.Action<Mancha.behaviors> OnManchaChangeBehavior = delegate { };      
    public static System.Action<Pill> OnAddPill = delegate { };
    public static System.Action<int> OnSetTotalManchas = delegate { };
    public static System.Action<Mancha> OnAddMancha = delegate { };
    public static System.Action<ManchaZone> OnAddManchaZone = delegate { };
    public static System.Action OnHeroAttacked = delegate { };
}
